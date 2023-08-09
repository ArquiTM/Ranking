using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace uDemy
{
    class Program
    {
        static void Main(string[] args)
        {
            string teste = string.Empty;

            try
            {
                Dictionary<string, int> myDict = new Dictionary<string, int> { };
                string[] file = File.ReadAllLines(@"ranking.txt");
                string sTemp = string.Empty;

                int countIgual = 1;
                int countM = 0;
                bool status = true;

                foreach (string s in file)
                {
                    sTemp += s;
                }
                sTemp = sTemp.Replace(" ", "");

                char[] v = sTemp.ToCharArray();
                string[,] mat = new string[v.Length, 2];

                for (int i = 0; i < v.Length; i++)
                {
                    for (int j = i + 1; j < v.Length; j++)
                    {
                        if (v[i] == v[j])
                            countIgual++;
                    }

                    for (int z = 0; z < countM; z++)
                    {
                        if (mat[z, 0] == v[i].ToString())
                            status = false;
                    }

                    if (status)
                    {
                        mat[countM, 0] = v[i].ToString();
                        mat[countM, 1] = countIgual.ToString();
                        countM++;
                        myDict.Add(v[i].ToString(), countIgual);
                    }
                    status = true;
                    countIgual = 1;
                }

                foreach (KeyValuePair<string, int> item in myDict.OrderByDescending(key => key.Value))
                {
                    Console.WriteLine((item));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}