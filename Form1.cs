using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace Number_to_Sound
{
    public partial class Form1 : Form
    {
        private int numToRead;
        private string numStr;

        private List<string> FilesToPlay = new List<string>();

        private AudioFileReader audio;
        private IWavePlayer player;

        public Form1()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HandleSingleDigit(char digit)
        {
            switch (digit)
            {
                case '1':
                    FilesToPlay.Add(@"C:\Users\User\Desktop\1_Cut.mp3");
                    break;
                case '2':
                    FilesToPlay.Add(@"C:\Users\User\Desktop\2_Cut.mp3");
                    break;
                case '3':
                    FilesToPlay.Add(@"C:\Users\User\Desktop\3_Cut.mp3");
                    break;
                case '4':
                    FilesToPlay.Add(@"C:\Users\User\Desktop\4_Cut.mp3");
                    break;
                case '5':
                    FilesToPlay.Add(@"C:\Users\User\Desktop\5_Cut.mp3");
                    break;
                case '6':
                    FilesToPlay.Add(@"C:\Users\User\Desktop\6_Cut.mp3");
                    break;
                case '7':
                    FilesToPlay.Add(@"C:\Users\User\Desktop\7_Cut.mp3");
                    break;
                case '8':
                    FilesToPlay.Add(@"C:\Users\User\Desktop\8_Cut.mp3");
                    break;
                case '9':
                    FilesToPlay.Add(@"C:\Users\User\Desktop\9_Cut.mp3");
                    break;
                case '0':
                    FilesToPlay.Add(@"C:\Users\User\Desktop\0_Cut.mp3");
                    break;
            }
        }

        private void HandleTens(string dblDigit)
        {
            switch (dblDigit)
            {
                case "11":
                    FilesToPlay.Add(@"C:\Users\User\Desktop\11_Cut.mp3");
                    break;
                case "12":
                    FilesToPlay.Add(@"C:\Users\User\Desktop\12_Cut.mp3");
                    break;
                case "13":
                    FilesToPlay.Add(@"C:\Users\User\Desktop\13_Cut.mp3");
                    break;
                case "14":
                    FilesToPlay.Add(@"C:\Users\User\Desktop\14_Cut.mp3");
                    break;
                case "15":
                    FilesToPlay.Add(@"C:\Users\User\Desktop\15_Cut.mp3");
                    break;
                case "16":
                    FilesToPlay.Add(@"C:\Users\User\Desktop\16_Cut.mp3");
                    break;
                case "17":
                    FilesToPlay.Add(@"C:\Users\User\Desktop\17_Cut.mp3");
                    break;
                case "18":
                    FilesToPlay.Add(@"C:\Users\User\Desktop\18_Cut.mp3");
                    break;
                case "19":
                    FilesToPlay.Add(@"C:\Users\User\Desktop\19_Cut.mp3");
                    break;
                case "10":
                    FilesToPlay.Add(@"C:\Users\User\Desktop\10_Cut.mp3");
                    break;
            }
        }

        private void HandleDoubleDigit(char digit)
        {
            switch (digit)
            {
                case '1':
                    FilesToPlay.Add(@"C:\Users\User\Desktop\10_Cut.mp3");
                    break;
                case '2':
                    FilesToPlay.Add(@"C:\Users\User\Desktop\20_Cut.mp3");
                    break;
                case '3':
                    FilesToPlay.Add(@"C:\Users\User\Desktop\30_Cut.mp3");
                    break;
                case '4':
                    FilesToPlay.Add(@"C:\Users\User\Desktop\40_Cut.mp3");
                    break;
                case '5':
                    FilesToPlay.Add(@"C:\Users\User\Desktop\50_Cut.mp3");
                    break;
                case '6':
                    FilesToPlay.Add(@"C:\Users\User\Desktop\60_Cut.mp3");
                    break;
                case '7':
                    FilesToPlay.Add(@"C:\Users\User\Desktop\70_Cut.mp3");
                    break;
                case '8':
                    FilesToPlay.Add(@"C:\Users\User\Desktop\80_Cut.mp3");
                    break;
                case '9':
                    FilesToPlay.Add(@"C:\Users\User\Desktop\90_Cut.mp3");
                    break;
            }
        }

        private void readButton_Click(object sender, EventArgs e)
        {
            /*
            SpeechSynthesizer speaker = new SpeechSynthesizer
            {
                Rate = 1,
                Volume = 100
            };
            speaker.Speak(numberTextBox.Text);
            */

            /*
            FilesToPlay.Add(@"C:\Users\User\Desktop\1_Cut.mp3");
            FilesToPlay.Add(@"C:\Users\User\Desktop\hundred_Cut.mp3");
            FilesToPlay.Add(@"C:\Users\User\Desktop\and_Cut.mp3");
            FilesToPlay.Add(@"C:\Users\User\Desktop\2_Cut.mp3");
            */

            int index = 0;
                          
            if (int.TryParse(numberTextBox.Text, out numToRead))
            {
                numStr = numberTextBox.Text;
                
                if (numToRead > 999)
                {
                    if (numStr[index] != '0')
                    {
                        HandleSingleDigit(numStr[index]);
                        FilesToPlay.Add(@"C:\Users\User\Desktop\thousand_Cut.mp3");
                    }
                    ++index;
                }

                if (numToRead > 99)
                {
                    if (numStr[index] != '0')
                    {
                        HandleSingleDigit(numStr[index]);
                        FilesToPlay.Add(@"C:\Users\User\Desktop\hundred_Cut.mp3");

                        if (numStr[index + 1] != '0' || numStr[index + 2] != '0')
                            FilesToPlay.Add(@"C:\Users\User\Desktop\and_Cut.mp3");
                    }
                    ++index;
                }

                if (numToRead > 19)
                {
                    if (numStr[index] != '0' && numStr[index] > '1') 
                    {
                        HandleDoubleDigit(numStr[index]);
                    }
                }

                if (numToRead > 9)
                {
                    if (numStr[index] != '0' && numStr[index] == '1')
                    {
                        HandleTens(numStr.Substring(index, 2));
                    }
                }
                ++index;

                if (numToRead >= 0)
                {
                    if (numStr[index] != '0')
                    {
                        HandleSingleDigit(numStr[index]);
                    }
                    ++index;
                }
            }
            else
                MessageBox.Show("Please enter a number!");

            // Play .mp3 files 
            foreach (var file in FilesToPlay)
            {
                audio = new AudioFileReader(file);
                audio.Volume = 1;
                player = new WaveOut(WaveCallbackInfo.FunctionCallback());
                player.Init(audio);
                player.Play();
                System.Threading.Thread.Sleep(audio.TotalTime);

                player.Stop();
                player.Dispose();
                audio.Dispose();
                player = null;
                audio = null;
            }

            // Reset list 
            FilesToPlay.Clear();
        }
    }
}
