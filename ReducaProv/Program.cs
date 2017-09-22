using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace ReducaProv
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {         
                int[][] intArray =
                {
                    new int[] {1,2,3,4,5},
                    new int[] {6,7,8,9},
                    new int[] {10,11}
                };

                List<string> result= new List<string>();
                FlattenArray(intArray, ref result);
                foreach (var item in result)
                {
                    Console.Write(item.ToString() + ",");
                }
                Console.WriteLine();

            }
            catch (Exception)
            {

                throw;
            }

            try
            {
                //input
                Console.WriteLine("Skriv en mening eller lämna tom för att använda defaultsträngen 'Ni talar bra latin':");
                string inputString = Console.ReadLine();

                if (inputString.Equals(""))
                {
                    inputString = "Ni talar bra latin";
                }

                string result = CheckIfPalindrom(inputString);

                Console.WriteLine(result);
            }
            catch (Exception)
            {

                throw;
            }

        }

        private static string CheckIfPalindrom(string inputString)
        {
            //remove punctuation
            inputString = string.Join("", inputString.Where(char.IsLetter));

            //reverse input
            string reversedInputString = "";
            for (int i = inputString.Length - 1; i >= 0; i--)
            {
                reversedInputString += inputString[i];
            }

            //compare input
            string resultMessage = "";
            if (string.Equals(inputString, reversedInputString, StringComparison.OrdinalIgnoreCase))
            {
                resultMessage = "Strängen {0} blir baklänges {1} och är ett palindrom";
            }
            else
            {
                resultMessage = "Strängen {0} blir baklänges {1} och är inte ett palindrom";
            }

            return string.Format(resultMessage, inputString, reversedInputString);
        }
      
        private static void FlattenArray(Array array, ref List<string> result)
        {
            
            foreach (var item in array)
            {
                if (item.GetType().BaseType.Equals(typeof(Array)))
                {
                    FlattenArray(item as Array, ref result);
                }
                else
                {
                    result.Add(item.ToString());
                }
                
            }

        }

    }
}
