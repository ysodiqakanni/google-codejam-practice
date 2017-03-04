using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Jam
{
    public class FileAccess
    {
        public static string ReadTextFIle(string path)
        {
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(path))
                {
                    String line = sr.ReadToEnd();
                    return line;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);

                return String.Empty;
            }
        }

        public static void WriteOutputToFile(string v, string path)
        {
            System.IO.File.WriteAllText(path, v);
        }
    }
}
