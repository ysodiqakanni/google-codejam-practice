using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Jam
{
    public class ReverseWords
    {
        public static void Solve()
        {
            //get all the strings
            //make each line a 
            string path = "C:/Users/Akin/Downloads/B-large-practice.in";
            //string path = "C:/Users/Akin/Desktop/B-small-practice (2).in";
            string outputPath = "C:/Users/Akin/Desktop/Google/Code Jam/Reversed Word output.txt";
            //int.Parse(Console.ReadLine());     //reads the number of test cases


            string s = FileAccess.ReadTextFIle(path);
            string[] allInput = s.Split('\n');
            int N = int.Parse(allInput[0]);

            StringBuilder outputString = new StringBuilder();       
            string output = "";
            for (int i = 1; i <= N; i++)
            {
                s = allInput[i];    // Console.ReadLine();
                string[] sa = s.Split(' ');
                IEnumerable<string> reversedList = sa.Reverse();
                //Console.Write("Case #" + i + ": ");
                //output += "Case #" + i + ": ";
                //string temp = "Case #" + i + ": ";
                string temp = "";
                foreach (var item in reversedList)
                {
                    //output += item + " ";
                     temp += item + " ";
                }
                outputString.AppendLine("Case #" + i + ": " +temp.Trim());
                //output += "\n";
            }
            //WriteOutputToFile(output.Trim(), outputPath);
            FileAccess.WriteOutputToFile(outputString.ToString().Trim(), outputPath);
            // string s = "This is a cool nice guy";

            //LinkedList<string> textList = new LinkedList<string>(sa);
            //IEnumerable<string> reversedList = textList.Reverse();             
        }
    }
}
