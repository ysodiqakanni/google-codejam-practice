using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Jam
{
    public class AlienWord
    {
        static bool endProcess = false;
        static List<List<int>> listOfLists = new List<List<int>>();
        static List<string> wordAsList = new List<string>();
        static List<int> currentIndeces = new List<int>();
        public static void Solve()
        {
            string inputPath = "C:/Users/Akin/Downloads/A-small-practice (3).in";
            string outputPath = "C:/Users/Akin/Desktop/Google/Code Jam/Alien Word.txt";
            string[] allInput = FileAccess.ReadTextFIle(inputPath).Split('\n');
            string[] lineOne = allInput[0].Split(' ');
            
            int numberOfTokens = int.Parse(lineOne[0]); int totalNumberOfWords = int.Parse(lineOne[1]); int N = int.Parse(lineOne[2]);     //number of cases

            //getting all the valid words
            string[] allValidWordsInTheLanguage = new string[totalNumberOfWords];
            int lineIndex = 1;
            for (int i = 0; i < totalNumberOfWords; i++)
            {
                allValidWordsInTheLanguage[i] = allInput[lineIndex++];
            }
           
            //getting all test cases
            string pattern = String.Empty;
            for (int i = 0; i < N; i++)
            {
                pattern = allInput[lineIndex++];
                wordAsList = ExtractWordUnitsFromPattern(pattern);  //wordAsList.count must be == numberOfTokens
                //initialize the index array to zeros
                int tokenLength = wordAsList.Count();
                for (int j = 0; j < tokenLength; j++)
                {
                    currentIndeces.Add(0);
                }
                //process the word
                string s = "";
                while (!endProcess)
                {
                    //var sds = wordAsList[3];
                    Increment(wordAsList[tokenLength - 1], tokenLength - 1, currentIndeces[tokenLength - 1]);
                    
                   // s += currentIndeces[0] + " " + currentIndeces[1] + " " + currentIndeces[2]+"\n";
                    for (int k = 0; k < tokenLength; k++)
                    {
                        s += currentIndeces[i] + " ";
                    }
                    s += "\n";
                }
            }

            //assume that all known words provided are unique.
            /*/
            listOfLists.Add(new List<int>() { 1, 2, 3 });
            listOfLists.Add(new List<int>() { 4, 5, 6, 7 });
            listOfLists.Add(new List<int>() { 8, 9 });
            listOfLists.Add(new List<int>() { 1, 2, 3 });
            listOfLists.Add(new List<int>() { 4, 5, 6, 7 });
            listOfLists.Add(new List<int>() { 8, 9 });
            listOfLists.Add(new List<int>() { 8, 9 });
            listOfLists.Add(new List<int>() { 1, 2, 3 });
            listOfLists.Add(new List<int>() { 4, 5, 6, 7 });
            listOfLists.Add(new List<int>() { 8, 9 });
            */

            //int N = listOfLists.Count();

            

            //converts each word(per line) as a list of xters

            

         
            
       
        
        }

        private static List<string> ExtractWordUnitsFromPattern(string pattern)
        {
            var result = new List<string>();
            string wordUnit = String.Empty;
            int lastIndex = pattern.Count() - 1;
            int count = 0;
            foreach (var character in pattern)
            {
                if (character == '(' || character == ')')
                {
                    //the beginning or end of a token
                    if (!String.IsNullOrEmpty(wordUnit))    //the current wordunit is already being formed
                    {
                        result.Add(wordUnit);       //save it and create a new one
                        wordUnit = String.Empty;
                    }
                }
                else
                {
                    wordUnit += character;
                    if (count == lastIndex)
                        result.Add(wordUnit);
                }
                count++;
            }
            return result;
        }

        private static int Increment(List<int> list, int lposition, int currentIndex)
        {            
            currentIndex++;
            if (currentIndex >= list.Count())
            {
                if (lposition == 0)
                {
                    endProcess = true;
                    currentIndex--;     //subtract the just added 1s
                    return -1;      //use this or endProcess to stop the combination process
                }

                currentIndex = 0;
                currentIndeces[lposition] = currentIndex;
                Increment(listOfLists[lposition - 1], lposition - 1, currentIndeces[lposition - 1]);
            }
            currentIndeces[lposition] = currentIndex;
            return currentIndex;
        }
        private static int Increment(string list, int lposition, int currentIndex)
        {
            currentIndex++;
            if (currentIndex >= list.Count())
            {
                if (lposition == 0)
                {
                    endProcess = true;
                    currentIndex--;     //subtract the just added 1s
                    return -1;      //use this or endProcess to stop the combination process
                }

                currentIndex = 0;
                currentIndeces[lposition] = currentIndex;
                Increment(listOfLists[lposition - 1], lposition - 1, currentIndeces[lposition - 1]);
            }
            currentIndeces[lposition] = currentIndex;
            return currentIndex;
        }
    }
}
