using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WordUnscrambler.Data;
using WordUnscrambler.Workers;

namespace WordUnscrambler
{
    class Program
    {
        // declare static values / objects for methods
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();

        static void Main(string[] args)
        {
            // wrap the entire thing in a try/catch otherwise exceptions in main won't be handled
            try
            {
                // set starting condtion for unscramble to run
                bool continueWordUnscramble = true;

                // do while
                do
                {
                    Console.WriteLine(Constants.OptionsHowToEnterScrambledWords);
                    // if no entry from user, then empty string
                    var option = Console.ReadLine() ?? string.Empty;

                    // normalize input to uppercase to match cases
                    switch (option.ToUpper())
                    {
                        case Constants.File:
                            Console.Write(Constants.EnterScrambledWordsFile);
                            ExecuteUnscrambleFromFile();
                            break;
                        case Constants.Manual:
                            Console.Write(Constants.EnterScrambledWordsManually);
                            ExecuteUnscrambleFromManual();
                            break;
                        default:
                            Console.Write(Constants.EnterScrambledWordsInputNotRecognized);
                            break;
                    }

                    // ask user at least once if they want to continue
                    // keep asking until you get a yes or a no, and ignore case
                    var continueDecision = string.Empty;
                    do
                    {
                        Console.WriteLine(Constants.OptionsContinuingProgram);
                        continueDecision = Console.ReadLine() ?? string.Empty;
                    } while (!continueDecision.Equals(Constants.Yes, StringComparison.OrdinalIgnoreCase) &&
                             !continueDecision.Equals(Constants.No, StringComparison.OrdinalIgnoreCase));

                    // check continueWordUnscramble is yes will change true/false
                    continueWordUnscramble = continueDecision.Equals(Constants.Yes, StringComparison.OrdinalIgnoreCase);
                } while (continueWordUnscramble);
            }
            catch (Exception ex)
            {
                Console.WriteLine(Constants.ErrorProgramWillTerminate + ex.Message);
            }

        }
        private static void ExecuteUnscrambleFromManual()
        {
            // if no input, then string is empty
            // split the user input at commas and add to the string[]
            // call a method to display results
            var manualInput = Console.ReadLine() ?? string.Empty;
            string[] scrambledWords = manualInput.Split(",");
            DisplayMatchedUnscrambledWords(scrambledWords);
        }

        private static void ExecuteUnscrambleFromFile()
        {
            // empty string if no user input
            // add text from file to string[]
            // call method to display results
            try
            {
                var filename = Console.ReadLine() ?? string.Empty;
                string[] scrambledWords = _fileReader.Read(filename);
                DisplayMatchedUnscrambledWords(scrambledWords);
            }
            catch (Exception ex)
            {
                Console.WriteLine(Constants.ErrorScrambledWordsCannotBeLoaded + ex.Message);
            }
        }

        private static void DisplayMatchedUnscrambledWords(string[] scrambledWords)
        {
            // use read method on custom fileReader object
            // create a list of matched words using match method on custom wordMatcher object
            // if there are any matched words in list, then show matches, otherwise display message
            string[] wordList = _fileReader.Read(Constants.WordListFilename);

            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordList);

            if (matchedWords.Any()) {
                foreach (var matchedWord in matchedWords) {
                    Console.WriteLine(Constants.MatchFound, matchedWord.ScrambledWord, matchedWord.Word);
                }
            } else {
                Console.WriteLine(Constants.MatchNotFound);
            }
        }
    }
}
