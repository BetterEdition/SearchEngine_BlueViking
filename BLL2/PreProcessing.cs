using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using DAL;
namespace BLL
{

   
    class PreProcessing {


        public static Dictionary<string, List<string>> invertedIndex;
        public static RetrieveTextFiles RTF = new RetrieveTextFiles();

        public static Dictionary<string, List<string>> readFiles() {

            invertedIndex = new Dictionary<string, List<string>>();
            List<string> files = RTF.findFiles();

            foreach (string file in files)
            {


                List<string> content = System.IO.File.ReadAllText(file).Split(' ').Distinct().ToList();
                List<string> removedSpaceContent = cleanWord.noSpacingNorSpecialChar(content);
                
                
                addToIndex(removedSpaceContent, file.Replace("C:\\Users\\Jespe\\Desktop\\DocumentsforIndex\\", ""));
                
                
                Console.ReadLine();
            }
            
            return invertedIndex;
           
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