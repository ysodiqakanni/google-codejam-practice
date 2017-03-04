using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Jam
{
    public class MinimumScalarProduct
    {
        public static void Solve()
        {
            #region Comments
            /// <summary>
            /// You are given two vectors v1=(x1,x2,...,xn) and v2=(y1,y2,...,yn). The scalar product of these vectors is a single number, calculated as x1y1+x2y2+...+xnyn.
            ///Suppose you are allowed to permute the coordinates of each vector as you wish.Choose two permutations such that the scalar product of your two new vectors is the smallest possible, and output that minimum scalar product.
            /// </summary>


            //IMPORTANT
            ///<summary>
            ///the danger of using int instead of long
            ///using List<int>for the large input, I got:
            ///Case #1: -1104693507808
            /// Case #2: 1127254038483
            ///Case #3: -175262903407
            /// Case #4: -89730309090
            ///  Case #5: -82026144220
            ///  Case #6: -30692194449
            ///  Case #7: -40249058421
            ///  Case #8: -101871000026
            ///  Case #9: -106048747428
            ///  Case #10: -44214501611
            ///  
            /// while using List<long> gave the below result
            /// Case #1: -7839202227936
            /// Case #2: 7999201712083
            /// Case #3: -1313429236847
            /// Case #4: -3710387739618
            /// Case #5: -3414920765916
            /// Case #6: -1271937742993
            /// Case #7: -1964394407029
            /// Case #8: -1884282427866
            /// Case #9: -4044533757860
            /// Case #10: -838783451371
            /// 
            ///</summary>
            #endregion

            string inputPath = "C:/Users/Akin/Downloads/A-large-practice (1).in";
            string outputPath = "C:/Users/Akin/Desktop/Google/Code Jam/Minimum Scalar Product.txt";
            string[] allInput = FileAccess.ReadTextFIle(inputPath).Split('\n');
            int N = int.Parse(allInput[0]);     //number of cases
            StringBuilder outPutString = new StringBuilder();
            //length, V1, V2
            int vectorLength = 0;
            long scalarProduct = 0;
            List<long> vector1 = new List<long>();
            List<long> vector2 = new List<long>();
            int lineIndex = 1;
            for (int i = 1; i <= N; i++)
            {
                vectorLength = int.Parse(allInput[lineIndex++]);
                vector1 = ConvertToIntegerList(allInput[lineIndex++]);
                vector2 = ConvertToIntegerList(allInput[lineIndex++]);
                scalarProduct = GetScalarProduct(vector1, vector2);

                outPutString.AppendLine("Case #" + i + ": " + scalarProduct);
            }
            FileAccess.WriteOutputToFile(outPutString.ToString().Trim(), outputPath);
        }

        private static long GetScalarProduct(List<long> vector1, List<long> vector2)
        {
            //To get the min scalar product, I discovered that the two lists should be sorted and one of them reversed befor multiplying them
            vector1.Sort();
            vector2.Sort(); vector2.Reverse();
            long product = 0;
            for (int i = 0; i < vector1.Count(); i++)
            {
                product += vector1[i] * vector2[i];
            }
            return product;
        }

        private static List<long> ConvertToIntegerList(string v)
        {
            var result = new List<long>();
            string[] tempStrArray = v.Split(' ');   //getting the coordinates as elements of an array of strings
            foreach (var numberStr in tempStrArray)
            {
                result.Add((int.Parse(numberStr)));
            }
            return result;
        }
    }
}
