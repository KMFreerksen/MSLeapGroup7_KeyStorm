using System;
using System.IO;

namespace KeyStorm
{
    public class LoadText
    {
        private List<string>? textPhraseStrings;

        /// <summary>
        /// Load the phrases from a file
        /// </summary>
        /// <param name="filePath"></param>
        /// <exception cref="FileNotFoundException"></exception>
        public void Load(string filePath)
        {
            // Combine the base directory with the relative path
            string? baseDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent?.Parent?.FullName;
            if (baseDirectory == null)
            {
                throw new InvalidOperationException("Base directory could not be determined.");
            }

            filePath = Path.Combine(baseDirectory, filePath);

            // Check if the file exists
            if (File.Exists(filePath))
            {
                textPhraseStrings = new List<string>(File.ReadAllLines(filePath));
            }
            else throw new FileNotFoundException("Puzzle file not found.");
        }

        /// <summary>
        /// Gets a random phrases from the list of phrases
        /// </summary>
        /// <returns></returns>
        public string GetRandomPhrase()
        {
            if (textPhraseStrings == null || textPhraseStrings.Count == 0)
            {
                throw new InvalidOperationException("No phrases loaded.");
            }
            Random random = new Random();
            return textPhraseStrings![random.Next(0, textPhraseStrings.Count)];
        }
    }
}
