using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Exchanger_Client
{
    public partial class Form1 : Form
    {
        private TcpClient client;
        private StreamWriter sw;
        private StreamReader sr;
        public Form1()
        {
            InitializeComponent();
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (client == null || !client.Connected)
                {
                    IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(IpTextBox.Text), Convert.ToInt32(PortTextBox.Text));
                    client = new TcpClient();
                    client.Connect(endPoint);

                    NetworkStream nstream = client.GetStream();
                    sw = new StreamWriter(nstream, Encoding.Unicode) { AutoFlush = true };
                    sr = new StreamReader(nstream, Encoding.Unicode);
                }

                sw.WriteLine(MessageTextBox.Text);
                string response = sr.ReadLine();

                if (!string.IsNullOrEmpty(response))
                {
                    OutputListBox.Items.Add($"{response}");
                }
                else
                {
                    OutputListBox.Items.Add("Сервер не вернул ответ или ответ пустой.");
                }
                MessageTextBox.Clear();
            }
            catch (SocketException sockEx)
            {
                MessageBox.Show("Ошибка сокета:" + sockEx.Message);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка:" + Ex.Message);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (client != null)
            {
                sw?.Close();
                sr?.Close();
                client.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
