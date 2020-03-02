using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cw1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //int tmp1 = 1;
            //double tmp2 = 2.4;
            //string tmp3 = "abcd";
            //bool tmp4 = true;
            //var tmp5 = "nCov";
            //string tmp6 = "nCov";
            //string tmp7 = "2019";
            //int tmp8 = 2;

            //Console.WriteLine($"{tmp6} {tmp7} {tmp1 + tmp8}");

            //var path = @"Z:\SEM4\SBD\cw1";

            //var newPerson = new Person { FirstName = "Rafał" };

            var url = args.Length>0? args[0] : "https://www.pja.edu.pl";

            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(url);

            // zwraca 503, 404 itd.
            if (response.IsSuccessStatusCode)
            {
                var htmlContent = await response.Content.ReadAsStringAsync();

                var regex = new Regex("[a-z]+[a-z0-9]+@[a-z0-9]+\\.[a-z]", RegexOptions.IgnoreCase);

                var matches = regex.Matches(htmlContent);

                foreach (var match in matches)
                {
                    Console.WriteLine(match.ToString());
                }

            }
                                                      
        }
    }
}
