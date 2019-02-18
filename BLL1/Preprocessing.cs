using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.IO;
namespace BLL
{

    class Preprocessing
    {

        public static Dictionary<string, List<string>> invertedIndex;
        public static retrieveTextFiles RTF = new retrieveTextFiles();
        static void Main(string[] args)
        {

            invertedIndex = new Dictionary<string, List<string>>();
            List<string> files = RTF.findFiles();
            foreach (string file in files)
            {


                List<string> content = System.IO.File.ReadAllText(file).Split(' ').Distinct().ToList();

                addToIndex(content, file);

            }



            Console.ReadLine();
        }

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
