using Google.Cloud.TextToSpeech.V1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETTextToSpeech
{
    public class GoogleCloudTextToSpeech
    {
        static TextToSpeechClient client;
        public GoogleCloudTextToSpeech()
        {
            //https://cloud.google.com
            //As the google api needs to get my own cred path(which I apply from google) from Environment variable. Therefore we need to add 'GOOGLE_APPLICATION_CREDENTIALS' variable to system path during the application running til it ends.
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Credentials", "[YOUR CREDENTIALS].json"));
            client = TextToSpeechClient.Create();

            
        }


        static int ListVoices(string desiredLanguageCode = "")
        {
            ListVoicesResponse response = client.ListVoices(new ListVoicesRequest
            {
                LanguageCode = desiredLanguageCode
            });

            foreach (Voice voice in response.Voices)
            {
                //Display the voices's name.
                Console.WriteLine($"Name: {voice.Name}");

                //Display the supported language codes for this voice.
                foreach (string language in voice.LanguageCodes)
                {
                    Console.WriteLine($"Supported language(s): {language}");
                }

                //Display the SSML Voice Gender
                Console.WriteLine($"SSML Voice Gender: {(SsmlVoiceGender)voice.SsmlGender}");

                //Display the natural sample rate hertz for this voice.
                Console.WriteLine($"Natural Sample Rate Hertz: {voice.NaturalSampleRateHertz}");

                Console.WriteLine("");
            }

            return 0;
        }

        public static Stream CreаteStreаmAudiо(string text)
        {


            SynthesisInput input = new SynthesisInput
            {
                Text = text
            };

            VoiceSelectionParams voiceSelection = new VoiceSelectionParams
            {
                LanguageCode = "en-US",
                SsmlGender = SsmlVoiceGender.Female
            };

            AudioConfig audioConfig = new AudioConfig
            {
                AudioEncoding = AudioEncoding.Linear16
            };

            var response = client.SynthesizeSpeech(input, voiceSelection, audioConfig);

            //SynthesizeSpeechRequest request = new SynthesizeSpeechRequest();
            //request.Input = new SynthesisInput();
            //request.Input.Text = text;

            //request.AudioConfig = new AudioConfig();
            //request.AudioConfig.AudioEncoding = AudioEncoding.Linear16;
            //request.AudioConfig.SampleRateHertz = 44100;


            //request.Voice = new VoiceSelectionParams();
            //request.Voice.LanguageCode = "yue-Hant-HK";
            //request.Voice.SsmlGender = SsmlVoiceGender.Female;
            //SynthesizeSpeechResponse respоnse = client.SynthesizeSpeech(request);

            Stream streаm = new MemoryStream();
            response.AudioContent.WriteTo(streаm);
            streаm.Position = 0;

            return streаm;
        }

    }
}
