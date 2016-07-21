using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace ProcessesFileIO
{
    class Program
    {
        List<string> upload(string nameOfFile)
        {
            List<string> sentences = new List<string>();
            if (File.Exists(nameOfFile))
            {
                using (StreamReader sr = File.OpenText(nameOfFile))
                {
                    string s = "";
                    char currentLetter = ' ';
                    while (sr.Peek() >= 0)
                    {
                        currentLetter = (char)sr.Read();
                        if (currentLetter == 65533)
                        {
                            currentLetter = '\'';
                        }

                        if (currentLetter == '.' || currentLetter == '\n')
                        {
                            s += currentLetter;
                            Console.WriteLine(s);
                            sentences.Add(s);
                            s = "";
                        }
                        else
                        {
                            s += currentLetter;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Error, the selected file was not found");
            }
            return sentences;
        }

        //List<string[]> parseIntoWords(List<string> sentences)
        //{
        //    List<string[]> words = new List<string[]>();
        //    //List<string> result = new List<string>();
        //    string[] result;
            
        //    foreach (string s in sentences)
        //    {
        //        result = s.Split(' ');
        //        words.Add(result);
        //    }
        //    return words;
        //}
        static void Main(string[] args)
        {
            string path = "../../Files/DeclarationOfIndependence.txt";
            List<string> sentences = new List<string>();
            List<string[]> words = new List<string[]>();
            Program p = new Program();
            sentences = p.upload(path);
            //words = p.parseIntoWords(sentences);
            //FileStream file = new FileStream("../../Files/StarSpangledBanner.parse", FileMode.Create);
            FileStream file = new FileStream("../../Files/DeclarationOfIndependence.parse", FileMode.Create);
            file.Close();

            using (StreamWriter sw = new StreamWriter("../../Files/DeclarationOfIndependence.parse"))
            {
                foreach (string s in sentences)
                {
                    sw.WriteLine(s);
                }
            }

            //Console.ReadKey();
        }
    }
}
