using System;
namespace WordUnscrambler
{
    public class Constants
    {
        public const string OptionsHowToEnterScrambledWords = "Enter scrambled word(s) manually or as a file: F - File / M - Manual: ";
        public const string OptionsContinuingProgram = "Would you like to continue? (Y/N): ";

        public const string EnterScrambledWordsFile = "Enter full path including filename: ";
        public const string EnterScrambledWordsManually = "Enter scrambled word(s), separated by comma: ";
        public const string EnterScrambledWordsInputNotRecognized = "Option was not recognized.";

        public const string ErrorScrambledWordsCannotBeLoaded = " Scrambled words were not loaded because there was an error";
        public const string ErrorProgramWillTerminate = " The program will be terminated";

        public const string MatchFound = "Match found for {0}: {1}";
        public const string MatchNotFound = "No matches found.";

        public const string Yes = "Y";
        public const string No = "N";
        public const string File = "F";
        public const string Manual = "M";

        public const string WordListFilename = "wordlist.txt";

    }
}
