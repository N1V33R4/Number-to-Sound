using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;

namespace Number_to_Sound
{
    public partial class Form1 : Form
    {
        private decimal numToRead;
        private string numStr;

        private List<string> FilesToPlay = new List<string>();
        private string NumInStr;

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
                    FilesToPlay.Add(@"\1.mp3");
                    NumInStr += "One";
                    break;
                case '2':
                    FilesToPlay.Add(@"\2.mp3");
                    NumInStr += "Two";
                    break;
                case '3':
                    FilesToPlay.Add(@"\3.mp3");
                    NumInStr += "Three";
                    break;
                case '4':
                    FilesToPlay.Add(@"\4.mp3");
                    NumInStr += "Four";
                    break;
                case '5':
                    FilesToPlay.Add(@"\5.mp3");
                    NumInStr += "Five";
                    break;
                case '6':
                    FilesToPlay.Add(@"\6.mp3");
                    NumInStr += "Six";
                    break;
                case '7':
                    FilesToPlay.Add(@"\7.mp3");
                    NumInStr += "Seven";
                    break;
                case '8':
                    FilesToPlay.Add(@"\8.mp3");
                    NumInStr += "Eight";
                    break;
                case '9':
                    FilesToPlay.Add(@"\9.mp3");
                    NumInStr += "Nine";
                    break;
                case '0':
                    FilesToPlay.Add(@"\0.mp3");
                    NumInStr += "Zero";
                    break;
            }
        }

        // handle 10-19
        private void HandleTens(string dblDigit)
        {
            switch (dblDigit)
            {
                case "11":
                    FilesToPlay.Add(@"\11.mp3");
                    NumInStr += "Eleven";
                    break;
                case "12":
                    FilesToPlay.Add(@"\12.mp3");
                    NumInStr += "Twelve";
                    break;
                case "13":
                    FilesToPlay.Add(@"\13.mp3");
                    NumInStr += "Thirteen";
                    break;
                case "14":
                    FilesToPlay.Add(@"\14.mp3");
                    NumInStr += "Fourteen";
                    break;
                case "15":
                    FilesToPlay.Add(@"\15.mp3");
                    NumInStr += "Fifteen";
                    break;
                case "16":
                    FilesToPlay.Add(@"\16.mp3");
                    NumInStr += "Sixteen";
                    break;
                case "17":
                    FilesToPlay.Add(@"\17.mp3");
                    NumInStr += "Seventeen";
                    break;
                case "18":
                    FilesToPlay.Add(@"\18.mp3");
                    NumInStr += "Eighteen";
                    break;
                case "19":
                    FilesToPlay.Add(@"\19.mp3");
                    NumInStr += "Nineteen";
                    break;
                case "10":
                    FilesToPlay.Add(@"\10.mp3");
                    NumInStr += "Ten";
                    break;
            }
        }

        // handle 20-99
        private void HandleDoubleDigit(char digit)
        {
            switch (digit)
            {
                case '2':
                    FilesToPlay.Add(@"\20.mp3");
                    NumInStr += "Twenty";
                    break;
                case '3':
                    FilesToPlay.Add(@"\30.mp3");
                    NumInStr += "Thirty";
                    break;
                case '4':
                    FilesToPlay.Add(@"\40.mp3");
                    NumInStr += "Fourty";
                    break;
                case '5':
                    FilesToPlay.Add(@"\50.mp3");
                    NumInStr += "Fifty";
                    break;
                case '6':
                    FilesToPlay.Add(@"\60.mp3");
                    NumInStr += "Sixty";
                    break;
                case '7':
                    FilesToPlay.Add(@"\70.mp3");
                    NumInStr += "Seventy";
                    break;
                case '8':
                    FilesToPlay.Add(@"\80.mp3");
                    NumInStr += "Eighty";
                    break;
                case '9':
                    FilesToPlay.Add(@"\90.mp3");
                    NumInStr += "Ninety";
                    break;
            }
        }

        // handle 100-999
        private bool HandleHundred(ref int index, string max)
        {
            bool add_sound = false;
            bool is_tens = false;

            if (numToRead >= decimal.Parse(max))
            {
                if (numStr[index] != '0')
                {
                    HandleSingleDigit(numStr[index]);
                    FilesToPlay.Add(@"\hundred.mp3");
                    NumInStr += "-Hundred";

                    if (numStr[index + 1] != '0' || numStr[index + 2] != '0')
                    { 
                        FilesToPlay.Add(@"\and.mp3");
                        NumInStr += " and ";
                    }

                    add_sound = true;
                }
                ++index;
            }

            if (numToRead >= decimal.Parse(max = '2' + max.Substring(2)) && numStr[index] > '1')
            { 
                if (numStr[index] != '0')
                {
                    HandleDoubleDigit(numStr[index]);
                    add_sound = true;
                }
                ++index;
            }
            else if (numToRead >= decimal.Parse(max = '1' + max.Substring(1))) // handle 11-19
            {
                if (numStr[index] != '0' && numStr[index] == '1')
                {
                    HandleTens(numStr.Substring(index, 2));
                    add_sound = true;
                    is_tens = true;
                }
                ++index;
            }
            
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

            return add_sound;
        }
       public static string NumbersToWords(long number)
       {
            if (number == 0) return "Zero";

            if (number < 0) return "minus " + NumbersToWords(Math.Abs(number));

            string words = "";


            if ((number / 100000000000) > 0)
            {
                words += NumbersToWords(number / 100000000) + "trillion";
                number %= 1000000000000;
            }

            if ((number / 1000000000) > 0)
            {
                words += NumbersToWords(number / 1000000000) + "billion";
                number %= 1000000000;
            }

            if ((number / 10000000) > 0)
            {
                words += NumbersToWords(number / 10000000) + "million";
                number %= 10000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumbersToWords(number / 1000) + "thousand";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumbersToWords(number / 100) + "hundred";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "") words += "and ";
                var belowTwenty = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirdteen", "fourteen", "fifthteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var doubleDigits = new[] { "zero", "ten", "twenty", "thiry", "fourty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                {
                    words += belowTwenty[number];
                }
                else
                {
                    words += doubleDigits[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + doubleDigits[number % 10];

                }
            }
            return words;

        }

            // async so that it lets us stop 
        private async void readButton_Click(object sender, EventArgs e)
        {
            // readLabel.Text = NumbersToWords(Int64.Parse(numberTextBox.Text));
            NumInStr = "";
            stop = false;
            int index = 0;

            speakerGif.Visible = true;
                          
            if (decimal.TryParse(numberTextBox.Text, out numToRead))
            {
                numStr = numberTextBox.Text;

                if (numToRead >= 1000000000000) // one trillion
                {
                    if (HandleHundred(ref index, "100000000000000")) // 100 trillion 
                    { 
                        FilesToPlay.Add(@"\trillion.mp3");
                        NumInStr += "-Trillion ";
                    }
                }

                if (numToRead >= 1000000000) // one billion
                {
                    if (HandleHundred(ref index, "100000000000")) // 100 billion
                    { 
                        FilesToPlay.Add(@"\billion.mp3");
                        NumInStr += "-Billion ";
                    }
                }

                if (numToRead >= 1000000) // one million
                {
                    if (HandleHundred(ref index, "100000000")) // 100 million
                    { 
                        FilesToPlay.Add(@"\million.mp3");
                        NumInStr += "-Million ";
                    }
                }
                
                if (numToRead >= 1000)
                {
                    if (HandleHundred(ref index, "100000")) // 100 thousand 
                    { 
                        FilesToPlay.Add(@"\thousand.mp3");
                        NumInStr += "-Thousand ";
                    }
                }

                HandleHundred(ref index, "100");

                readLabel.Text = NumInStr;

                string fname = "Satya Voice";
                // Play .mp3 files 
                foreach (string file in FilesToPlay)
                {
                    audio = new AudioFileReader(fname + file);
                    audio.Volume = 1;
                    player = new WaveOut(WaveCallbackInfo.FunctionCallback());
                    player.Init(audio);
                    player.Play();

                    // reduces interval between .mp3 files 
                    int delay = (int)(audio.TotalTime.TotalMilliseconds / 1.3);
                    
                    if (index == numStr.Length - 1)
                        // full duration for last item 
                        await Task.Delay(audio.TotalTime);
                    else
                        await Task.Delay(delay);

                    if (stop)
                        break;
                    ClearPlayer();
                }

                // Reset list 
                FilesToPlay.Clear();
                speakerGif.Visible = false;
            }
            else
                MessageBox.Show("Please enter a number!");
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            stop = true;
            player?.Stop();
            ClearPlayer();
            speakerGif.Visible = false;
            readLabel.Text = "";
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
