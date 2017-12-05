using System;
using System.Collections.Generic;
using WordUnscrambler.Data;

namespace WordUnscrambler.Workers
{
    public class WordMatcher
    {
     
        public List<MatchedWord> Match(string[] scrambledWords, string[] wordList)
        {
            var matchedWords = new List<MatchedWord>();

            foreach (var scrambledWord in scrambledWords) {

                foreach (var word in wordList) {
                    // if characters and order of characters match
                    if (scrambledWord.Equals(word, StringComparison.OrdinalIgnoreCase)) {
                        matchedWords.Add(BuildMatchedWord(scrambledWord, word));
                    }
                    else {
                        // turn string into array of char
                        // sort the array
                        // turn sorted array back into string
                        var scrambledWordArray = scrambledWord.ToCharArray();
                        var wordArray = word.ToCharArray();

                        Array.Sort(scrambledWordArray);
                        Array.Sort(wordArray);

                        var sortedScrambledWord = new string(scrambledWordArray);
                        var sortedWord = new string(wordArray);

                        if (sortedScrambledWord.Equals(sortedWord, StringComparison.OrdinalIgnoreCase)) {
                            matchedWords.Add(BuildMatchedWord(scrambledWord, word));
                        }
                    }
                }
            }

            return matchedWords;
        }

        private MatchedWord BuildMatchedWord(string scrambledWord, string word) {
            MatchedWord matchedWord = new MatchedWord
            {
                ScrambledWord = scrambledWord,
                Word = word
            };
            return matchedWord;
        }
    }
}
