using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Jam
{
    public class T9_Spelling
    {
        //static Dictionary<int, string> alphabetEncoder = new Dictionary<int, string>();
        static List<string> alphabetEncoder = new List<string>();
        public static void Solve()
        {
            string inputPath = "C:/Users/Akin/Downloads/C-small-practice.in";
            string outputPath = "C:/Users/Akin/Desktop/Google/Code Jam/T9 Spelling.txt";            
            string[] allInput = FileAccess.ReadTextFIle(inputPath).Split('\n');
            int N = int.Parse(allInput[0]);     //number of cases

            //alphabetEncoder = new Dictionary<int, string> { { 2, "abc" }, { 3, "def" }, { 4, "ghi" }, { 5, "jkl" }, { 6, "mno" }, { 7, "pqrs" }, { 8, "tuv" }, { 9, "wxyz" }, { 0, " " } };
            alphabetEncoder = new List<string> { " ", "", "abc","def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
            StringBuilder sb = new StringBuilder();
            //string t9Code = "";
            for (int i = 1; i <= N; i++)
            {
                //t9Code = allInput[i];
                //ConvertToT9Pattern(t9Code);
                sb.AppendLine("Case #"+i+": "+ConvertToT9Pattern(allInput[i]));
            }

            FileAccess.WriteOutputToFile(sb.ToString().Trim(), outputPath);
        }

        private static string ConvertToT9Pattern(string sentence)
        {
            if (String.IsNullOrEmpty(sentence) || String.IsNullOrWhiteSpace(sentence))
                return "0";
            string result = "";
            int previousKey = -1;
            foreach (var letter in sentence)
            {
                string value = alphabetEncoder.Where(v => v.Contains(letter)).SingleOrDefault();
                if (value == null)
                    return value;
                //int key = alphabetEncoder.Keys.Where(k => alphabetEncoder.TryGetValue(k, out value) == true).First();
                int key = alphabetEncoder.IndexOf(value);
                if (key == previousKey)
                    result += " ";
                int numberOfPresses = int.Parse(value.IndexOf(letter).ToString()) + 1;
                for (int i = 0; i < numberOfPresses; i++)
                {
                    result += key;
                }
                previousKey = key;
            }
            
            return result;
        }
    }
}
