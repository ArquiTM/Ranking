using System;
using System.IO;
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
                string[] file = File.ReadAllLines(@"ranking.txt");
                string[,] mat = new string[26, 2];
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
                    }
                    status = true;
                    countIgual = 1;
                }

                for (int i = 0; i < v.Length; i++)
                {
                    if (mat[i, 0] != null)
                        Console.WriteLine(mat[i, 0] + " = " + mat[i, 1]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}