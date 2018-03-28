using System;
using System.IO;
using System.Net;

namespace AsyncProgramming
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // Use async anytime we have blocking operations like web, files, databases, images
            // Async replaces multi-threading and callbacks

            DownloadHtml("http://www.google.com");
        }

        public static void DownloadHtml(string url)
        {
            var webClient = new WebClient();
            var html = webClient.DownloadString(url);

            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "test.html");

            try
            {
                using (var sw = new StreamWriter(path))
                {
                    sw.Write(html);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
