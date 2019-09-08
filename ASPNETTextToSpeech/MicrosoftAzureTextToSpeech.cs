using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;

namespace ASPNETTextToSpeech
{
    public class MicrosoftAzureTextToSpeech
    {
        // Creates an instance of a speech config with specified subscription key and service region.
        // Replace with your own subscription key and service region (e.g., "westus").
        //API Key Path
        //https://azure.microsoft.com/en-us/try/cognitive-services/ 
        SpeechSynthesizer _synthesizer;
        public MicrosoftAzureTextToSpeech()
        {
            SpeechConfig config = SpeechConfig.FromSubscription("YourSubscriptionKey", "YourServiceRegion");
            _synthesizer = new SpeechSynthesizer(config);
        }

        public async Task TextToSpeech(string text)
        {
            using (var result = await _synthesizer.SpeakTextAsync(text))
            {
                if (result.Reason == ResultReason.SynthesizingAudioCompleted)
                {
                    Console.WriteLine($"Speech synthesized to speaker for text [{text}]");
                }
                else if (result.Reason == ResultReason.Canceled)
                {
                    var cancellation = SpeechSynthesisCancellationDetails.FromResult(result);
                    Console.WriteLine($"CANCELED: Reason={cancellation.Reason}");

                    if (cancellation.Reason == CancellationReason.Error)
                    {
                        Console.WriteLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                        Console.WriteLine($"CANCELED: ErrorDetails=[{cancellation.ErrorDetails}]");
                        Console.WriteLine($"CANCELED: Did you update the subscription info?");
                    }
                }
            }
        }
    }
}
