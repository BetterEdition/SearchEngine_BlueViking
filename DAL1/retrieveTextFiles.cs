using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DAL
{
    public class RetrieveTextFiles
    {

        public List<string> findFiles()
        {
            List<string> content = new List<string>();
            string folder = "C:\\Users\\Jespe\\Desktop\\DocumentsforIndex\\";

            foreach (string file in Directory.EnumerateFiles(folder, "*.txt"))
            {
                content.Add(file);
            }
            
            return content;
        }
    }
}
