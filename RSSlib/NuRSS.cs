using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace RSSlib
{
    public class NuRSS
    {
        private const string STR_URL = @"http://www.nu.nl/feeds/rss/algemeen.rss";


        public static IEnumerable<string> GetItems()
        {
            var document = XDocument.Load(STR_URL);

            var items = document.XPathSelectElements("rss/channel/item/title");
            foreach (var item in items)
            {
                yield return item.Value;
            }



        }

    


}
}
