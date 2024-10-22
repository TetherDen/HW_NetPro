using System.Text;
using System.Text.Json.Serialization;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;
using System.Net;

namespace HW_06;

internal class Program
{
    static string urlApi = "https://api.random.org/json-rpc/4/invoke";
    static string apiKey = "f06072c0-11c2-44f6-90d1-f1c4c44633b4";
    static HttpClient httpClient = new HttpClient();

    static async Task Main(string[] args)
    {
        //Используя возможности https://api.random.org/ создайте оконное приложение для игры в кости.
        //Реализуйте 2 режима игры: человек-человек, человек — компьютер. 
        //Значения для броска костей нужно генерировать с помощь API.
        //Добавьте к заданию визуальное отображение игровых костей.Также реализуйте анимацию броска кости.
        //    Ключ получаем по этой ссылке:
        //    https://api.random.org/dashboard/details


        while (true)
        {
            Console.WriteLine($"Enter 1 to play Dice or 'exit'");
            string choice = Console.ReadLine().ToLower();
            if (choice == "exit" || choice == "end") break;
            await DiceGame();
        }


        //====================================================


        // Определите сервер, который будет принимать данный пользователя для регистрации в виде JSON.
        // Определите клиента, который с помощью класса HttpClient будет отправлять POST - запрос на сервер для регистрации нового пользователя.
      

        string uri = "https://localhost:7101/auth";

        // Типа запросили данные пользователя
        Dictionary<string, string> data = new Dictionary<string, string>   
        {
            ["name"] = "John",
            ["email"] = "John@gmail.com",
            ["password"] = "qwerty"
        };

        HttpContent contentForm = new FormUrlEncodedContent(data);
        using (var response = await httpClient.PostAsync(uri, contentForm))
        {
            string responseText = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Response from server: {responseText}");
        }

        Console.WriteLine("Press Enter to Next Task");
        Console.ReadLine();


        // ====================================================


        //Создайте консольное приложение на C#, которое отправляет запросы на публичное API для получения случайной цитаты, а затем выводит цитату в консоль.
        //Используйте HttpClient для отправки GET-запроса на публичное API.Пример API: https://zenquotes.io/api/random, которое возвращает случайную цитату.
        //Реализуйте обработку ошибок, если запрос не удастся выполнить (например, если API недоступно).

        string quotesApiUrl = "https://zenquotes.io/api/random";

        try
        {
            using(var response = await httpClient.GetAsync(quotesApiUrl))
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var quote = await response.Content.ReadFromJsonAsync<Quote[]>();

                    if (quote != null && quote.Length > 0)
                    {
                        Console.WriteLine($"Random Quote: \"{quote[0].Text}\" — {quote[0].Author}");
                    }
                }
            }
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Http Request Error {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error {ex.Message}");

        }
        Console.ReadLine();
    }


    public class Quote
    {
        [JsonPropertyName("q")]
        public string Text { get; set; }

        [JsonPropertyName("a")]
        public string Author { get; set; }

    }


    static async Task DiceGame()
    {
        Console.WriteLine("Dice Game Started!");
        Console.WriteLine("Player 1: Press 'Enter' to roll dice");
        Console.ReadLine();
        int player1 = await RollDice();
        Console.WriteLine($"Player 1 rolled: {player1}\n");


        Console.WriteLine("Player 2: Press 'Enter' to roll dice");
        Console.ReadLine();
        int player2 = await RollDice();
        Console.WriteLine($"Player 2 rolled: {player2}\n");

        if (player1 > player2)
        {
            Console.WriteLine("Player 1 won!\n");
        }
        else if (player1 < player2)
        {
            Console.WriteLine("Player 2 won!\n");
        }
        else
        {
            Console.WriteLine("Draw!\n");
        }
    }

    static async Task<int> RollDice()
    {
        using (var client = new HttpClient())
        {
            string requestBody = $@"
            {{
                ""jsonrpc"": ""2.0"",
                ""method"": ""generateIntegers"",
                ""params"": {{
                    ""apiKey"": ""{apiKey}"",
                    ""n"": 1,
                    ""min"": 1,
                    ""max"": 6,
                    ""replacement"": true
                }},
                ""id"": 42
            }}";

            var content = new StringContent(requestBody, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(urlApi, content);

            if (response.IsSuccessStatusCode)
            {
                var responseJsonString = await response.Content.ReadAsStringAsync();

                dynamic result = Newtonsoft.Json.JsonConvert.DeserializeObject(responseJsonString);
                return result.result.random.data[0];
            }
            else
            {
                throw new Exception("Error request to API.");
            }
        }
    }


}


