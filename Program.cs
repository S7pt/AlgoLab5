using System;
using System.Collections.Generic;

namespace AlgoLaba5
{
    public class Program
    {
        const int characters = 256;
        public static List<(int, int)> rabinKarpAlgorithm(string inputString, string pattern, int binary)
        {
            int patternHash = 0;
            int textHash = 0;
            int h = 1;
            for (int i = 0; i < pattern.Length; i++)
            {
                patternHash = (characters * patternHash + pattern[i]) % binary;
                textHash = (characters * textHash + inputString[i]) % binary;
            }
            for (int i = 0; i < pattern.Length - 1; i++)
                h = (h * characters) % binary;
            int leftEdge = 0;
            List<(int, int)> indicesOfSubstring = new List<(int, int)>();

            for (int i = 0; i < inputString.Length - pattern.Length; i++)
            {
                if (textHash == patternHash)
                {
                    for (int j = 0; j < pattern.Length; j++)
                    {
                        if (inputString[i + j] != pattern[j])
                        {
                            break;
                        }
                        if (j == pattern.Length - 1)
                        {
                            indicesOfSubstring.Add((leftEdge, leftEdge + pattern.Length - 1));
                        }
                    }
                }
                if (i < inputString.Length - pattern.Length)
                {
                    textHash = ((characters * (textHash - inputString[i] * h) + inputString[i + pattern.Length]) % binary);
                    if (textHash < 0)
                    {
                        textHash += binary;
                    }
                }
                leftEdge++;
            }
            return indicesOfSubstring;
        }
        static void Main(string[] args)
        {
            (string text, string pattern) data = FileInteractor.readStringsFromFile("../../../data_input.txt");
            int prime = 101;
            List<(int, int)> result = rabinKarpAlgorithm(data.text, data.pattern, prime);
            FileInteractor.writeToFile(result, "../../../data_output.txt");
        }
    }
}
