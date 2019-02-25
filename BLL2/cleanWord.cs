using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    class cleanWord
    {
        // Method for removing unwanted chars in index
        public static List<String> noSpacingNorSpecialChar(List<string> words)
        {
            // Making a new list
            List<String> newListOfWords = new List<string>();
            foreach (var word in words)
            {
               
                // Replacing the word with a filtered word
                string term = new string(word.Where(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c) || c == '-').ToArray());

                Console.WriteLine("Word: " + term);
                // Adding trimmed terms
                if (term.Trim() != "")
                {
                    newListOfWords.Add(term.Trim().ToLower());
                }


            }


            // Returning the clean list of words
            return newListOfWords;
            
        }
        
    }
}
