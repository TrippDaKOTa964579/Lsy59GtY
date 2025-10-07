// 代码生成时间: 2025-10-07 18:56:46
using System;
using System.IO;
using System.Speech.Synthesis;

namespace TextToSpeech
{
    /// <summary>
    /// A utility class for text-to-speech conversion.
    /// </summary>
    public class TextToSpeechTool
    {
        private readonly SpeechSynthesizer _synthesizer;

        /// <summary>
        /// Initializes a new instance of the TextToSpeechTool class.
        /// </summary>
        public TextToSpeechTool()
        {
            _synthesizer = new SpeechSynthesizer();
        }

        /// <summary>
        /// Converts text to speech and saves the audio to a file.
        /// </summary>
        /// <param name="text">The text to be synthesized.</param>
        /// <param name="outputFilePath">The file path to save the synthesized audio.</param>
        public void SaveToAudioFile(string text, string outputFilePath)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException("Text cannot be null or empty.", nameof(text));
            }

            if (string.IsNullOrEmpty(outputFilePath))
            {
                throw new ArgumentException("Output file path cannot be null or empty.", nameof(outputFilePath));
            }

            try
            {
                using (var stream = new FileStream(outputFilePath, FileMode.Create))
                {
                    _synthesizer.SetOutputToAudioStream(stream, new AudioFormat {
                        WaveFormatTag = 3, // PCM
                        Channels = 1,
                        SamplesPerSecond = 16000,
                        BlockAlign = 2,
                        AverageBytesPerSecond = 32000
                    });

                    _synthesizer.Speak(text);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving the audio file: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Converts text to speech and plays it immediately.
        /// </summary>
        /// <param name="text">The text to be synthesized.</param>
        public void SpeakText(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException("Text cannot be null or empty.", nameof(text));
            }

            try
            {
                _synthesizer.Speak(text);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while synthesizing speech: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Gets or sets the default voice for the synthesizer.
        /// </summary>
        public VoiceInfo DefaultVoice
        {
            get => _synthesizer.Voice;
            set => _synthesizer.Voice = value;
        }
    }

    /// <summary>
    /// Provides information about a voice.
    /// </summary>
    public class VoiceInfo
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public VoiceGender VoiceGender => Gender.ToLower() switch
        {
            "male" => VoiceGender.Male,
            "female" => VoiceGender.Female,
            _ => VoiceGender.NotSpecified
        };
    }
}
