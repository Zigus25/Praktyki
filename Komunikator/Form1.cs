using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Komunikator
{
    public partial class Form1 : Form
    {
        EndPoint epRemote;
        IPEndPoint epLocal;
        Socket sck;
        IPHostEntry host;

        public Form1()
        {
            InitializeComponent();

            sck = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            TIP.Text = GetLocalIP();
            ZIP.Text = GetLocalIP();
        }

        private string GetLocalIP()
        {
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "127.0.0.1";
        }

        private void Polaczenie_Click(object sender, EventArgs e)
        {
            try
            {
                epLocal = new IPEndPoint(IPAddress.Parse(TIP.Text),
                    Convert.ToInt32(TPO.Value));
                sck.Bind(epLocal);

                epRemote = new IPEndPoint(IPAddress.Parse(ZIP.Text),
                    Convert.ToInt32(ZPO.Value));
                sck.Connect(epRemote);

                Byte[] buffer = new byte[1500];
                sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote,
                    new AsyncCallback(MessageCallBack), buffer);

                text.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MessageCallBack(IAsyncResult aResult)
        {
            try
            {
                int size = sck.EndReceiveFrom(aResult, ref epRemote);
                byte[] receivedData = new byte[1464];
                receivedData = (byte[])aResult.AsyncState;

                ASCIIEncoding eEncoding = new ASCIIEncoding();
                string receivedMessage = eEncoding.GetString(receivedData);

                Messages.Items.Add("Friend: " + receivedMessage);

                byte[] buffer = new byte[1500];
                sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None,
                    ref epRemote, new AsyncCallback(MessageCallBack), buffer);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void wyslij_Click(object sender, EventArgs e)
        {
            try
            {
                ASCIIEncoding enc = new ASCIIEncoding();
                byte[] msg = new byte[1500];
                msg = enc.GetBytes(text.Text);
                sck.Send(msg);
                Messages.Items.Add("You: " + text.Text);
                text.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
