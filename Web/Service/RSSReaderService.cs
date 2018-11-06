using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Xml.Linq;
using Shared;
using Web.Model;

namespace Web.Service
{
    public class RSSReaderService : IRSSReaderService
    {
        public async Task<List<RSSFeed>> ReadAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {

                MediaTypeWithQualityHeaderValue contentType =
new MediaTypeWithQualityHeaderValue("application/xml");
                client.DefaultRequestHeaders.Accept.Add(contentType);

                HttpResponseMessage response = await client.GetAsync(url);
                var stringData = await response.Content.ReadAsStringAsync();

                XDocument doc = XDocument.Parse(stringData);

                var items = (from r in doc.Root.Elements("channel").Elements("item")
                             select new RSSFeed()
                             {
                                 Title = (string)r.Element("title"),
                                 Description = (string)r.Element("description"),
                                 Link = (string)r.Element("link")
                             }).ToList();

                return items;

            }
        }
    }
}
