using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace BLL
{

    public static class Extensions
    {
        public static IEnumerable<string> And(this Dictionary<string, List<string>> index, string firstTerm, string secondTerm)
        {

            return (from d in index
                    where d.Key.Equals(firstTerm)
                    select d.Value).SelectMany(x => x).Intersect
                            ((from d in index
                              where d.Key.Equals(secondTerm)
                              select d.Value).SelectMany(x => x));
        }

        public static IEnumerable<string> Or(this Dictionary<string, List<string>> index, string firstTerm, string secondTerm)
        {
            return (from d in index
                    where d.Key.Equals(firstTerm) || d.Key.Equals(secondTerm)
                    select d.Value).SelectMany(x => x).Distinct();
        }

    }

    class EntryPoint
    {

        public static Dictionary<string, List<string>> invertedIndex;


        private static void addToIndex(List<string> words, string document)
        {
            foreach (var word in words)
            {
                if (!invertedIndex.ContainsKey(word))
                {
                    invertedIndex.Add(word, new List<string> { document });
                }
                else
                {
                    invertedIndex[word].Add(document);
                }
            }
        }
    }
}