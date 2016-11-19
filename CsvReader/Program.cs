using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvReader
{
    class Program
    {

        static IEnumerable<string[]> ReadCsv1(string filename)
        {
            using (var stream = new StreamReader(filename))
                while (true)
                {
                    var buf = stream.ReadLine();
                    if (buf == null)
                    {
                        stream.Close();
                        yield break;
                    }
                    var str = buf.Split(',');
                    for (var i = 0; i < str.Length; i++)
                        str[i] = (str[i] == "NA") ? null : str[i].Replace("\"", null);

                    yield return str;
                }
        }

        static void Main(string[] args)
        {
            foreach (var i in ReadCsv1("C:\\Users\\Евгений\\Desktop\\airquality.csv"))
            {
                foreach (var j in i)
                {
                    Console.Write("{0} ", j);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
