using System;
using System.Collections.Generic;
using System.IO;

namespace ExoAlgo
{
    class Program
    {
        // Calcul de la distance de Levenshtein
        public static int ComputeLevenshteinDistance(string str1, string str2)
        {
            if (string.IsNullOrEmpty(str1))
            {
                return str2.Length;
            }
            else if (string.IsNullOrEmpty(str2))
            {
                return str1.Length;
            }
            else
            {
                int replace = ComputeLevenshteinDistance(str1.Substring(1), str2.Substring(1)) + NumOfReplacement(str1[0], str2[0]);
                int insert = ComputeLevenshteinDistance(str1, str2.Substring(1)) + 1;
                int delete = ComputeLevenshteinDistance(str1.Substring(1), str2) + 1;
                return MinEdits(replace, insert, delete);
            }
        }

        public static int NumOfReplacement(char c1, char c2)
        {
            return c1 == c2 ? 0 : 1;
        }

        public static int MinEdits(params int[] nums)
        {
            return nums.Min();
        }

        // Recherche de mot dans le fichier texte
        public static bool IsWordInFile(string word, string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);
            return Array.Exists(lines, line => line.Equals(word));
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Begin");

            string vocabs;

            string fileName = "liste_francais.txt";

            try
            {
                string[] lines = File.ReadAllLines(fileName);
                List<string> mots = new List<string>(lines);
                Console.WriteLine(mots[100]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Entrez un mot : ");
            vocabs = Console.ReadLine();

            if (!string.IsNullOrEmpty(vocabs))
            {
                Console.WriteLine(vocabs);
                if (IsWordInFile(vocabs, fileName))
                {
                    Console.WriteLine("Appartenant");
                }
                else
                {
                    Console.WriteLine("Non trouvé dans le fichier.");
                }
            }
            else
            {
                Console.WriteLine("Fin de la console.");
            }

            // Calcul de la distance de Levenshtein
            string s1 = "papa";
            string s2 = "maman";
            Console.WriteLine("Distance de Levenshtein : " + ComputeLevenshteinDistance(s1, s2));
        }
    }
}
