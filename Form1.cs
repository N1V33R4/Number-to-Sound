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

namespace Number_to_Sound
{
    public partial class Form1 : Form
    {
        private decimal numToRead;
        private string numStr;

        private List<string> FilesToPlay = new List<string>();
        bool stop = false;

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

        // handle 0-9
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

        // handle 10-19
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

        // handle 20-99
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

        // handle 100-999
        private bool HandleHundred(ref int index, string max)
        {
            bool add_sound = false;
            bool is_tens = false;

            if (numToRead > decimal.Parse(max))
            {
                if (numStr[index] != '0')
                {
                    HandleSingleDigit(numStr[index]);
                    FilesToPlay.Add(@"C:\Users\User\Desktop\hundred_Cut.mp3");

                    if (numStr[index + 1] != '0' || numStr[index + 2] != '0')
                        FilesToPlay.Add(@"C:\Users\User\Desktop\and_Cut.mp3");

                    add_sound = true;
                }
                ++index;
            }

            if (numToRead > decimal.Parse(max = '1' + max.Substring(1)) && numStr[index] > '1')
            {
                if (numStr[index] != '0')
                {
                    HandleDoubleDigit(numStr[index]);
                    add_sound = true;
                }
                ++index;
            }
            else if (numToRead > decimal.Parse(max = max.Remove(0, 1))) // handle 11-19
            {
                if (numStr[index] != '0' && numStr[index] == '1')
                {
                    HandleTens(numStr.Substring(index, 2));
                    add_sound = true;
                    is_tens = true;
                }
                ++index;
            }

            // prevent empty string 
            if (max.Length != 1)
                max = max.Remove(0, 1);
            else
                max = "0";

            if (numToRead >= decimal.Parse(max))
            {
                if (numStr[index] != '0' && !is_tens)
                {
                    HandleSingleDigit(numStr[index]);
                    add_sound = true;
                }
                else if (numStr.Length == 1) // handle 0 
                {
                    HandleSingleDigit(numStr[index]);
                }
                ++index;
            }

            return add_sound;
        }

        // async so that it lets us stop 
        private async void readButton_Click(object sender, EventArgs e)
        {
            /*
            SpeechSynthesizer speaker = new SpeechSynthesizer
            {
                Rate = 1,
                Volume = 100
            };
            speaker.Speak(numberTextBox.Text);
            */

            stop = false;
            int index = 0;
                          
            if (decimal.TryParse(numberTextBox.Text, out numToRead))
            {
                numStr = numberTextBox.Text;

                if (numToRead > 999999999999) // nine hundred billion
                {
                    if (HandleHundred(ref index, "99999999999999"))
                        FilesToPlay.Add(@"C:\Users\User\Desktop\trillion_Cut.mp3");
                }

                if (numToRead > 999999999) // nine hundred million
                {
                    if (HandleHundred(ref index, "99999999999"))
                        FilesToPlay.Add(@"C:\Users\User\Desktop\billion_Cut.mp3");
                }

                if (numToRead > 999999) // nine hundred thousand 
                {
                    if (HandleHundred(ref index, "99999999"))
                        FilesToPlay.Add(@"C:\Users\User\Desktop\million_Cut.mp3");
                }
                
                if (numToRead > 999)
                {
                    if (HandleHundred(ref index, "99999"))
                        FilesToPlay.Add(@"C:\Users\User\Desktop\thousand_Cut.mp3");
                }

                HandleHundred(ref index, "99");
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
                
                // reduces interval between .mp3 files 
                int delay = (int)(audio.TotalTime.TotalMilliseconds / 1.5);
                await Task.Delay(delay);

                // no delay for last item 
                if (index == numStr.Length - 1)
                    await Task.Delay(audio.TotalTime);

                if (stop)
                    break;
                ClearPlayer();
            }

            // Reset list 
            FilesToPlay.Clear();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            stop = true;
            player?.Stop();
            ClearPlayer();
        }

        private void ClearPlayer()
        {
            if (player != null && audio != null)
            {
                player.Dispose();
                audio.Dispose();
                player = null;
                audio = null;
            }
        }
    }
}
