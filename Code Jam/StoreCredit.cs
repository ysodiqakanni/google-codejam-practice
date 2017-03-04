using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Jam
{
    public class StoreCredit
    {        
        public static void Solve()
        {
            string path = "C:/Users/Akin/Downloads/A-large-practice.in";
            string outputPath = "C:/Users/Akin/Desktop/Google/Code Jam/Store Credit.txt";
            //string s = FileAccess.ReadTextFIle(path);
            string[] allInput = FileAccess.ReadTextFIle(path).Split('\n');
            int N = int.Parse(allInput[0]);     //number of cases

            
            decimal amountOfCredit = 0;
            List<decimal> prices = new List<decimal>();
            int numberOfItems = 0;

            string[] strList;
            int lineIndex = 1;

            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= N; i++)
            {
                amountOfCredit = Convert.ToDecimal(allInput[lineIndex++]);
                numberOfItems = int.Parse(allInput[lineIndex++]);
                strList = allInput[lineIndex++].Split(' ');
                foreach (string item in strList)
                {
                    prices.Add(Convert.ToDecimal(item));
                }

                string the2Indeces = "";
                bool stop = false;
                int index1 = 0;
                while (index1 < prices.Count())
                {
                    if (stop)
                        break;
                    for (int index2 = 0; index2 < prices.Count(); index2++)
                    {
                        if (index1 == index2)
                            continue;
                        if (prices[index1] + prices[index2] == amountOfCredit)
                        {
                            the2Indeces = index1 + " " + index2;
                            stop = true;        //to also stop the outer loop since an answer has been found
                            break;
                        }
                    }
                    index1++;
                }
                sb.AppendLine("Case #" + i + ": " + the2Indeces);
                prices.Clear();
            }
            FileAccess.WriteOutputToFile(sb.ToString().Trim(), outputPath);
        }
    }

}
