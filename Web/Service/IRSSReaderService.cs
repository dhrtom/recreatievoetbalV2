using System.Collections.Generic;
using System.Threading.Tasks;
using Shared;
using Web.Model;

namespace Web.Service
{
    public interface IRSSReaderService
    {
        Task<List<RSSFeed>> ReadAsync(string url);
    }
}
