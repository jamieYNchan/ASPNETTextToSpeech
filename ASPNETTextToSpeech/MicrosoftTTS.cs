using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETTextToSpeech
{
    public class MicrosoftTTS
    {
        public int Volume { get => synthesizer.Volume; set => synthesizer.Volume = value; }
        public int Rate { get => synthesizer.Rate; set => synthesizer.Rate = value; }
        static SpeechSynthesizer synthesizer;
        public MicrosoftTTS()
        {
            synthesizer = new SpeechSynthesizer();
            synthesizer.Volume = 100;  // 0...100
            synthesizer.Rate = -2;     // -10...10
        }

        public void TextToSpeech(string text)
        {
            synthesizer.SpeakAsync(text);
        }
    }
}
