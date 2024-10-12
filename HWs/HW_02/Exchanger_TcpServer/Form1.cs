using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.IO;

namespace Exchanger_TcpServer
{
    public partial class Form1 : Form
    {
        private TcpListener list;
        private string logPath = "log.txt";
        Dictionary<string, double> rates = new Dictionary<string, double>
        {
            { "USD EURO", 0.91 },
            { "EURO USD", 1.09 },
            { "USD UAH", 41.12 },
            { "UAH USD", 0.027 },
            { "BTC USD", 63132 },
            { "ETH USD", 2475.06 },
            { "USDT USD", 0.9999 },
            { "GBP UAH", 53.75 },
            { "UAH GBP", 0.019 },
        };
        public Form1()
        {
            InitializeComponent();
        }

        private void StartServerButton_Click(object sender, EventArgs e)
        {
            try
            {
                //�������� ���������� ������ TcpListener
                //������ � ����� � ����� �������� /�� ��������� ����
                list = new TcpListener(IPAddress.Parse(IpTextBox.Text), Convert.ToInt32(PortTextBox.Text));
                //������ ������������� ��������
                list.Start();
                //�������� ���������� ������ ��� ������ ���������
                Thread thread = new Thread(new ThreadStart(ThreadFun));
                thread.IsBackground = true;
                thread.Start();
            }

            catch (SocketException sockEx)
            {
                MessageBox.Show("������ ������:" + sockEx.Message);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("������:" + Ex.Message);
            }

        }

        private void ThreadFun()
        {
            while (true)
            {
                TcpClient client = list.AcceptTcpClient();

                StreamReader sr = new StreamReader(client.GetStream(), Encoding.Unicode);
                StreamWriter sw = new StreamWriter(client.GetStream(), Encoding.Unicode) { AutoFlush = true };

                // ������� EndPoint �������
                IPEndPoint clientEndPoint = client.Client.RemoteEndPoint as IPEndPoint;
                string clientInfo = clientEndPoint != null ? $"{clientEndPoint.Address}:{clientEndPoint.Port}" : "����������� ������";

                this.Invoke(new EventHandler(delegate
                {
                    MessagesList.Items.Add($"����� ������ ��������� {clientInfo},  DateTime: {DateTime.Now}");
                }));
                LogToFile($"����� ������ ��������� {clientInfo},  DateTime: {DateTime.Now}");

                while(true)
                {
                    string request = sr.ReadLine();
                    if(string.IsNullOrEmpty(request) || request.ToUpper() == "EXIT")
                    {
                        this.Invoke(new EventHandler(delegate
                        {
                            MessagesList.Items.Add($"������ {clientInfo} ����������. {DateTime.Now}");
                        }));
                        break;
                    }

                    string response = GetExchangeRate(request);
                    LogToFile($"{clientInfo} requested: {request}, and get response {response}");
                    sw.WriteLine($"{request}: {response}");

                    this.Invoke(new EventHandler(delegate
                    {
                        MessagesList.Items.Add($"������ �� {clientInfo}: [ {request} ]  {DateTime.Now}");
                    }));
                }


                LogToFile($"Disconnection {clientInfo} at {DateTime.Now} ");
                client.Close();
            }
        }

        private string GetExchangeRate(string request)
        {
            // rates ��������� � Program, ������
            if (rates.TryGetValue(request, out double rate))
            {
                return rate.ToString();
            }
            return "���� �� ������";
        }
        
        private void LogToFile(string message)
        {
            using (StreamWriter sw = new StreamWriter(logPath, true))
            {
                sw.WriteLine(message);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (list != null)
            {
                list.Stop();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
