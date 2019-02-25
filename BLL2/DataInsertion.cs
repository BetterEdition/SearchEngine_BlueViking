using BLL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BLL
{

    

        class DataInsertion
        {

            static void Main(string[] args)
            {
                Dictionary<string, List<string>> invertedIndex = PreProcessing.readFiles();
                var context = new BlueVikings2019Entities();


                // Going through keys which are the files
                foreach (var key in invertedIndex.Values.SelectMany(x => x).ToList().Distinct())
                {
                    // Creating a document based on the distinct key from dictionary
                    Document doc = new Document { Doc = key };

                    // Add the document to the context
                    context.Documents.Add(doc);

                    Document doc1 = context.Documents.Where(d => d.Doc == doc.Doc).FirstOrDefault();
                    Console.WriteLine(doc1);
                }
                context.SaveChanges();


            // Go through all the words
            foreach (var word in invertedIndex.Keys)
                {
                
               
                    // Create and add the word to term table
                    Term term = new Term { Word = word };
                    context.Terms.Add(term);
                    

                    foreach (var item in invertedIndex[word])
                    {
                    try
                    {

                        Document returnedDoc = context.Documents.Where(d => d.Doc == item).FirstOrDefault();
                        returnedDoc.Terms.Add(term);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                       
                    
                    }
                }
            Console.ReadLine();
            // Save it to the database
            Console.WriteLine("end");
                context.SaveChanges();

                context.Dispose();
                Console.ReadLine();




            }


        }
    
   
}
