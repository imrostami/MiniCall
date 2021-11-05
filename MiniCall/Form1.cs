using EasyTcp4;
using EasyTcp4.ClientUtils;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MiniCall
{
    public partial class Form1 : Form
    {
        static WaveIn waveIn;
        static WaveOut waveOut;
        static BufferedWaveProvider provider;
        static EasyTcpClient _client;
        public Form1()
        {
            InitializeComponent();

            waveIn = new WaveIn();
            waveIn.WaveFormat = new WaveFormat(10000,1);
            waveOut = new WaveOut();
            provider = new BufferedWaveProvider(waveIn.WaveFormat);
            _client = new EasyTcpClient();
            _client.OnConnect += _client_OnConnect;
            _client.OnDisconnect += _client_OnDisconnect;
            _client.OnDataReceive += _client_OnDataReceive;
            _client.OnDataSend += _client_OnDataSend;


            waveIn.DataAvailable += WaveIn_DataAvailable;
        }

        private void _client_OnDataReceive(object sender, EasyTcp4.Message e)
        {

            if (Encoding.UTF8.GetString(e.Data).StartsWith("msg:"))
            {
                var message = Encoding.UTF8.GetString(e.Data).Split(':')[1];
                MiniCall.BalloonTipTitle = "Notfication";
                MiniCall.BalloonTipText = message;
                MiniCall.ShowBalloonTip(1000);
            }
            else
            {
                provider.AddSamples(e.Data, 0, e.Data.Length);
            }
        }

        private void _client_OnDataSend(object sender, EasyTcp4.Message e)
        {
            
        }

       

        private void _client_OnDisconnect(object sender, EasyTcpClient e)
        {
           
        }

        private void _client_OnConnect(object sender, EasyTcpClient e)
        {
           
        }

        private void WaveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            Task.Factory.StartNew(new Action(() => _client.Send(e.Buffer)));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            for (int i = 0; i < WaveIn.DeviceCount; i++)
            {
                var inProd = WaveIn.GetCapabilities(i).ProductName;
                inDeviceList.Items.Add(inProd);
            }

            for (int i = 0; i < WaveOut.DeviceCount; i++)
            {
                var outProd = WaveOut.GetCapabilities(i).ProductName;
                OutDeviceList.Items.Add(outProd);
            }
            inDeviceList.SelectedIndex = 0;
            OutDeviceList.SelectedIndex = 0;
            SetDeviceNumber();
        }

        private void SetDeviceNumber()
        {
            waveIn.DeviceNumber = inDeviceList.SelectedIndex;
            waveOut.DeviceNumber = OutDeviceList.SelectedIndex;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (_client.Connect("91.198.77.182", 89))
            {
                MuteBox.Enabled = true;  
                start_btn.Enabled = false;
                inDeviceList.Enabled = false;
                OutDeviceList.Enabled = false;


                Text = "Connected Sucsses";
                waveIn.StartRecording();

                waveOut.Init(provider);
                await Task.Delay(500).ContinueWith(f => waveOut.Play());
            }
            
        }

        private void inDeviceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDeviceNumber();
        }

        private void OutDeviceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDeviceNumber();
        }

        

        private void MuteBox_CheckedChanged(object sender, EventArgs e)
        {
            if (MuteBox.Checked)
            {
                waveIn.StopRecording();
                _client.Send($"msg:{Environment.UserName} Muted Microphone");
            }
            else
            {
                waveIn.StartRecording();
                _client.Send($"msg:{Environment.UserName} UnMuted Microphone");
            }
        }

        private void InputVolome_Scroll(object sender, EventArgs e)
        {
          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            provider.ClearBuffer();
        }
    }
}
