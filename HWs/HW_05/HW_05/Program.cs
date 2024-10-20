using System;
using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;

namespace HW_05;

internal class Program
{
    static HttpClient httpClient = new HttpClient();

    [DllImport("user32.dll")]
    public static extern IntPtr SendMessage(IntPtr hwnd, uint Msg, int wParam, [MarshalAs(UnmanagedType.LPStr)] string lParam);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

    const uint WM_SETTEXT = 0x000C;

    static async Task Main(string[] args)
    {

        //Скачайте любое изображение из интернета и сохраните в локальной папке на компьютере.

        string url = "https://png.pngtree.com/thumb_back/fh260/background/20230720/pngtree-blue-and-purple-neon-star-3d-art-background-with-a-cool-image_3705286.jpg";
        string filePath = @"C:\logs\Test.jpg";
        using (WebClient client = new())
        {
            await client.DownloadFileTaskAsync(new Uri(url), filePath);
            Console.WriteLine($"Download finished\n");
        }


        //=====================================================


        //Считайте «Заголовки» и «Статус код», отправив запрос на любой сайт.

        using (HttpResponseMessage response = await httpClient.GetAsync("https://www.google.com"))
        {
            string content = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"StatusCode: {response.StatusCode}");

            foreach (var header in response.Headers)
            {
                Console.Write($"{header.Key}:");
                foreach (var headerValue in header.Value)
                {
                    Console.WriteLine(headerValue);
                }
            }
        }


        //=====================================================

        //Создайте приложение, читающее Html страницу и отображающую ее в текстовом редакторе в виде текста.
        //Пользователь ввод Url адрес запрашиваемой страницы.

        string url2 = "https://www.google.com";

        using (HttpResponseMessage response = await httpClient.GetAsync(url2))
        {
            string content2 = await response.Content.ReadAsStringAsync();

            using Process process = new();
            process.StartInfo.FileName = "notepad.exe";
            process.Start();

            //Ждедм пока откроет блокнот 1сек
            await Task.Delay(1000); 

            IntPtr hWnd = FindWindow("Notepad", null);
            if (hWnd != IntPtr.Zero)
            {
                IntPtr hEdit = FindWindowEx(hWnd, IntPtr.Zero, "Edit", null);
                if (hEdit != IntPtr.Zero)
                {
                    // доблавяет текст в текстовое поле
                    SendMessage(hEdit, WM_SETTEXT, (int)IntPtr.Zero, content2);
                    //process.WaitForExit(); //  Ждем пока закроют блокнот, можно убрать                   
                }
            }
            else
            {
                Console.WriteLine("Окно Notepad не найдено.");
            }
        }


    }
}

