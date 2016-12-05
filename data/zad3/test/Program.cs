using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Net;

namespace test
{
    class Program
    {
        public static List<String[]> get_regions(String site)
        {
            List<String[]> regions = new List<String[]>();
            WebClient client = new WebClient();
            HtmlDocument document = new HtmlDocument();

            String source = client.DownloadString(site + "hidden_main_page/info_ekuz");
            document.LoadHtml(source);

            HtmlNode main_node = document.DocumentNode;

            for (int i = 1; i <= 16; i++)
            {
                HtmlNode node = main_node.SelectSingleNode("//*[@id='pl" + i + "']");
                String name = node.InnerText;
                String link = node.InnerHtml;

                link = link.Remove(0, link.IndexOf('\"') + 1);
                link = link.Remove(link.IndexOf('\"'));
                link = site + link;

                byte[] bytes = Encoding.Default.GetBytes(name);
                name = Encoding.UTF8.GetString(bytes);

                regions.Add(new String[]{name, link});
            }

            return regions;
        }

        public static List<String[]> get_branches(String site)
        {
            List<String[]> branches = new List<String[]>();
            WebClient client = new WebClient();
            HtmlDocument document = new HtmlDocument();

            String source = client.DownloadString(site);
            document.LoadHtml(source);

            HtmlNode main_node = document.DocumentNode;

            for (int i = 1; i <= 16; i++)
            {
                HtmlNode node = main_node.SelectSingleNode("//*[@id='pl" + i + "']");
                String name = node.InnerText;
                String link = node.InnerHtml;

                link = link.Remove(0, link.IndexOf('\"') + 1);
                link = link.Remove(link.IndexOf('\"'));
                link = site + link;

                byte[] bytes = Encoding.Default.GetBytes(name);
                name = Encoding.UTF8.GetString(bytes);

            }

            return branches;
        }

        static void Main(string[] args)
        {
            int i = 1;
            String site = "https://www.ekuz.nfz.gov.pl/";

            List<String[]> regions = get_regions(site);

            foreach (String[] region in regions)
            {
                Console.WriteLine(i + ": " + region[0]);
                i++;
            }

            Console.Write("\nChoose number: ");

            int key = -1;
            bool result = Int32.TryParse(Console.ReadLine(), out key);

            while (result == false || (key < 1 || key > 16))
            {
                Console.Write("Wrong number, type new: ");
                result = Int32.TryParse(Console.ReadLine(), out key);
            }

            List<String[]> branches = get_branches(regions[key-1][1]);
        }
    }
}
