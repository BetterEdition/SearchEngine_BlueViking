using BLL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        class DataInsertion
        {

            static void Main(string[] args)
            {
                Dictionary<string, List<string>> invertedIndex = PreProcessing.readFiles();
                var context = new BlueVikings2019Entities();
                List<String> value = invertedIndex["arrival"];
                var document = new document()
                {
                    doc = value[0]
                };
                context.documents.Add(document);
                context.SaveChanges();
                Console.ReadLine();
            }
        }


    }
}
