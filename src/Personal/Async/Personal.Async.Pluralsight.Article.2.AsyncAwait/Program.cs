using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Async.Pluralsight.Article._2.AsyncAwait
{
    public class Program
    {
        public static async Task Main()
        {
            Console.InputEncoding = Console.OutputEncoding = Encoding.Unicode;

            var url = "C:/Users/petar.totev/Desktop/readThisFile.txt";

            var text = await DoAsyncThing(url);

            Console.WriteLine(text);
        }

        public static async Task<string> DoAsyncThing(string url)
        {
            StreamReader myReader = new StreamReader(url);
            return await myReader.ReadToEndAsync();
        }
    }
}
