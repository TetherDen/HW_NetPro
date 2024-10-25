using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace HW_08;

internal class Program
{
    // https://t.me/Qwerty770Bot
    // t.me/Qwerty770Bot

    // 7956448467:AAGoUVSDakdpI5Uy3Xyst064u6UqRGECxis


    private static List<Question> questions = new List<Question>
    {
        new Question("Что делает GetAwaiter?", new[] { "Управляет потоками.", "Создает новую задачу.", "Ждёт завершение async операции", "Сериализация Данных." }, "Ждёт завершение async операции"),
        new Question("Что такое Task?", new[] { "Асинхронный результат.", "Поток.", "Исключение.", "Рекурсия." }, "Асинхронный результат."),
        new Question("Какой метод используется для сериализации объекта в C#?", new[] { "ToString.", "Parse.", "Convert.", "Serialize." }, "Serialize."),
        new Question(" Какой код корректно использует оператор ?.?", new[] { "var name = obj?.ToString();", "var name = obj?.Name();", "var name = obj?.Name;", "var name = obj?.GetName;" }, "var name = obj?.Name;"),
        new Question("Что такое сборка (assembly) в C#?", new[] { "Единица развертывания и версияции кода.", "Единица развертывания и версияции кода.", "Объект для работы с потоками.", "Объект для работы с потоками." }, "Единица развертывания и версияции кода."),
        new Question("Что произойдет, если попытаться изменить элемент readonly массива?", new[] { "Компилятор выдаст ошибку", "Время выполнения выдаст ошибку", "Ничего не произойдет", "Значение будет изменено" }, "Значение будет изменено"),

    };

    private static Dictionary<long, int> userScores = new Dictionary<long, int>();

    private int score = 0;
    private static int currentQuestionIndex = 0;
    private static long? lastChatId = null;


    static async Task Main()
    {
        var botClient = new TelegramBotClient("7956448467:AAGoUVSDakdpI5Uy3Xyst064u6UqRGECxis");
        using var cts = new CancellationTokenSource();


        //Начало приема не блокирует поток вызова. Прием осуществляется в пуле потоков.
        var receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = Array.Empty<UpdateType>() // получаем все типы обновлений
        };
        botClient.StartReceiving(
            updateHandler: HandleUpdateAsync,
            pollingErrorHandler: HandlePollingErrorAsync,
            receiverOptions: receiverOptions,
            cancellationToken: cts.Token
        );
        var me = await botClient.GetMeAsync();


        Console.WriteLine($"Бот под именем @{me.Username}, запущен.");
        Console.ReadLine();
        cts.Cancel();
    }



    static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Type == Telegram.Bot.Types.Enums.UpdateType.CallbackQuery)
        {
            await HandleCallbackQuery(botClient, update.CallbackQuery);
            return;
        }

        if (update.Message is not { } message)
            return;
        if (message.Text is not { } messageText)
            return;


        var chatId = message.Chat.Id;
        if (lastChatId != chatId)
        {
            currentQuestionIndex = 0;
            lastChatId = chatId;
        }

        await SendQuestion(botClient, chatId, cancellationToken);
    }



    static async Task SendQuestion(ITelegramBotClient botClient, long chatId, CancellationToken cancellationToken)
    {
        if (currentQuestionIndex >= questions.Count)
        {
            await botClient.SendTextMessageAsync(chatId, "Все вопросы пройдены.", cancellationToken: cancellationToken);
            return;
        }

        var question = questions[currentQuestionIndex];

        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
        new[]
        {
            InlineKeyboardButton.WithCallbackData(text: question.Options[0], callbackData: "0"),
            InlineKeyboardButton.WithCallbackData(text: question.Options[1], callbackData: "1"),
        },
        new[]
        {
            InlineKeyboardButton.WithCallbackData(text: question.Options[2], callbackData: "2"),
            InlineKeyboardButton.WithCallbackData(text: question.Options[3], callbackData: "3"),
        }
    });

        await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: question.Text,
            replyMarkup: inlineKeyboard,
            cancellationToken: cancellationToken
        );
    }


    static async Task HandleCallbackQuery(ITelegramBotClient botClient, CallbackQuery callbackQuery)
    {
        var chatId = callbackQuery.Message.Chat.Id;
        var selectedAnswerIndex = int.Parse(callbackQuery.Data);
        var question = questions[currentQuestionIndex];

        var selectedAnswer = question.Options[selectedAnswerIndex];
        bool isCorrect = question.IsCorrect(selectedAnswer);

        if (!userScores.ContainsKey(chatId))
        {
            userScores[chatId] = 0;
        }
        string explanation;
        if (isCorrect)
        {
            explanation = "Правильно!";
            userScores[chatId] += 100;
        }
        else
        {
            explanation = $"Неправильно! Правильный ответ: {question.CorrectAnswer}";

        }

        await botClient.AnswerCallbackQueryAsync(
            callbackQueryId: callbackQuery.Id,
            text: explanation,
            showAlert: false
        );

        await botClient.SendTextMessageAsync(chatId, $"{(isCorrect ? "Правильно!" : "Неправильно!")}");

        currentQuestionIndex++;
        if (currentQuestionIndex < questions.Count)
        {
            await SendQuestion(botClient, chatId, CancellationToken.None);
        }
        else
        {
            await botClient.SendTextMessageAsync(chatId, $"Ваш результат: {userScores[chatId]} очков. \nСпасибо за участие!");
        }
    }


    static Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        var ErrorMessage = exception switch
        {
            ApiRequestException apiRequestException
                => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
            _ => exception.ToString()
        };

        Console.WriteLine(ErrorMessage);
        return Task.CompletedTask;
    }
}

public class Question
{
    public string Text { get; set; }
    public string[] Options { get; set; }
    public string CorrectAnswer { get; set; }

    public Question(string text, string[] options, string correctAnswer)
    {
        Text = text;
        Options = options;
        CorrectAnswer = correctAnswer;
    }

    public bool IsCorrect(string userAnswer)
    {
        return CorrectAnswer == userAnswer;
    }
}