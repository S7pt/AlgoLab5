using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AlgoLaba5
{
    class FileInteractor
    {
        public static (string,string) readStringsFromFile(string path)
        {
            string text;
            string pattern;
            using (StreamReader sr = new StreamReader(path)) {
                text = sr.ReadLine();
                pattern = sr.ReadLine();
                Console.WriteLine("Data successfully extracted");
            }
            return (text,pattern);
                
        }
        public static void writeToFile(List<(int,int)> result,string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                if (result.Count == 0)
                {
                    sw.WriteLine("There are no substrings matching given pattern");
                    return;
                }
                foreach (var unit in result)
                {
                    sw.WriteLine("Found right substring starting at index {0}, ending at {1}", unit.Item1, unit.Item2);
                }
            }
            Console.WriteLine("Data was successfully written to the file");
        }
    }
}
