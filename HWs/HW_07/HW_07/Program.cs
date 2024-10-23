using System.Net.Mail;
using System.Net;
using System.Runtime.InteropServices;
using MailKit.Net.Pop3;
using MimeKit;
using MailKit.Net.Imap;
using MailKit.Security;

namespace HW_07;

internal class Program
{
    private static SecureSocketOptions isSSL;

    [DllImport("Comdlg32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    public static extern bool GetOpenFileName([In, Out] OPENFILENAME ofn);



    static void Main(string[] args)
    {
        // task 1
        //Реализовать приложение по типу «Console Application», с возможность отправки письма нескольким получателям.

        //task 2
        //Используя код из предыдущего задания, реализовать возможно прикреплять вложения, указывая путь к ним.

        // task3
        //Используя протокол «POP3», получить все письма с вашего почтового ящика.

        //Install-Package MailKit
        //Install-Package MimeKit
        //using MailKit.Net.Pop3;


        string messageBody = "Hello SMTP !!!";
        string messageSubject = "Test qwerty";
        List<string> emailsList = new()
        {
            { "730game@gmail.com"},
            { "bigdramashow730@gmail.com" },
        };


        using MailMessage post = new MailMessage();
        post.From = new MailAddress("bigdramashow730@gmail.com");

        foreach (string email in emailsList)
        {
            post.To.Add(email);
        }
        post.Subject = messageSubject;
        post.IsBodyHtml = false;
        post.Body = messageBody;

        string fileToAttach = SelectFile();
        if (!string.IsNullOrEmpty(fileToAttach))
        {
            Attachment attachment = new Attachment(fileToAttach);
            post.Attachments.Add(attachment);
            Console.WriteLine($"File {fileToAttach} added.");
        }
        else { Console.WriteLine("File not added..."); }


        try
        {
            using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
            {
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("bigdramashow730@gmail.com", "vcdp fosa vnvx llov");
                smtp.Send(post);
                Console.WriteLine("Email sent successfully.");
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Sending email error: {ex.Message}");

        }


        //====================================================

        Console.WriteLine($"Task:3");

        string pop3Server = "pop.gmail.com";
        int port = 995; //порт POP3 с SSL
        string username = "bigdramashow730@gmail.com";
        string password = "umcr rcrd udts cenl";

        try
        {
            using (var client = new Pop3Client())
            {
                client.Connect(pop3Server, port, true);  // используем SSL
                client.Authenticate(username, password);

                int count = client.Count;
                Console.WriteLine($"Total Messages: {count}");

                for (int i = 0; i < count; i++)
                {
                    MimeMessage message = client.GetMessage(i);
                    Console.WriteLine($"Subject: {message.Subject}");
                }


                client.Disconnect(true);
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

    }



    // Метод для выбора файла
    static string SelectFile()
    {
        OPENFILENAME ofn = new OPENFILENAME();
        ofn.lpstrFilter = "Text Files (*.txt)\0*.txt\0All Files (*.*)\0*.*\0";
        ofn.nMaxFile = 260;
        ofn.lpstrFile = new string(new char[260]);
        ofn.lpstrFileTitle = new string(new char[260]);
        ofn.lpstrTitle = "Выберите файл";
        ofn.Flags = 0x00080000 | 0x00001000 | 0x00000800 | 0x00000200;

        if (GetOpenFileName(ofn))
        {
            return ofn.lpstrFile;
        }

        return null;
    }
}




[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
public class OPENFILENAME
{
    public int lStructSize = Marshal.SizeOf(typeof(OPENFILENAME));
    public IntPtr hwndOwner = IntPtr.Zero;
    public IntPtr hInstance = IntPtr.Zero;
    public string lpstrFilter = null;
    public string lpstrCustomFilter = null;
    public int nMaxCustFilter = 0;
    public int nFilterIndex = 0;
    public string lpstrFile = null;
    public int nMaxFile = 0;
    public string lpstrFileTitle = null;
    public int nMaxFileTitle = 0;
    public string lpstrInitialDir = null;
    public string lpstrTitle = null;
    public int Flags = 0;
    public short nFileOffset = 0;
    public short nFileExtension = 0;
    public string lpstrDefExt = null;
    public IntPtr lCustData = IntPtr.Zero;
    public IntPtr lpfnHook = IntPtr.Zero;
    public string lpTemplateName = null;
    public IntPtr pvReserved = IntPtr.Zero;
    public int dwReserved = 0;
    public int FlagsEx = 0;
}