﻿using System;
using System.Linq;

namespace Substrate.NetApi.BIP39
{
    /// <summary>
    /// Base class for all wordlists
    /// </summary>
    public abstract class Wordlist
    {
        /// <summary>
        /// The words in the wordlist
        /// </summary>
        private readonly string[] _words;

        /// <summary>
        /// Constructor used by inheritence only
        /// </summary>
        /// <param name="words">The words to be used in the wordlist</param>
        protected Wordlist(string[] words)
        {
            _words = words;
        }

        /// <summary>
        /// Method to determine if word exists in word list, great for auto language detection
        /// </summary>
        /// <param name="word">The word to check for existence</param>
        /// <param name="index"></param>
        /// <returns>Exists (true/false)</returns>
        public bool WordExists(string word, out int index)
        {
            if (_words.Contains(word))
            {
                index = Array.IndexOf(_words, word);
                return true;
            }

            //index -1 means word is not in wordlist
            index = -1;
            return false;
        }

        /// <summary>
        /// Returns a string containing the word at the specified index of the wordlist
        /// </summary>
        /// <param name="index">Index of word to return</param>
        /// <returns>Word</returns>
        public string GetWordAtIndex(int index)
        {
            return _words[index];
        }

        /// <summary>
        /// The number of all the words in the wordlist
        /// </summary>
        public int WordCount
        {
            get
            {
                return _words.Length;
            }
        }

        /// <summary>
        /// Returns all the words in the wordlist
        /// </summary>
        /// <returns></returns>
        public string[] GetWords()
        {
            return _words;
        }
    }
}