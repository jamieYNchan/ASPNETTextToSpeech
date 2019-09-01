using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETTextToSpeech
{
    class Program
    {
        static MicrosoftTTS _microsoftTTS;
        static void Main(string[] args)
        {
            _microsoftTTS = new MicrosoftTTS();
            readText();
        }

        static void readText()
        {
            Console.WriteLine("Type some text that you want to speak...");
            Console.Write("> ");
            string text = Console.ReadLine();
            _microsoftTTS.TextToSpeech(text);
            readText();
        }
    }
}
