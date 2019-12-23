using System.Collections.Generic;

namespace ApiClientSample.Models
{
    public class ThinkSpeakResponse
    {
        public Channel Channel { get; set; }
        public IEnumerable<Feed> Feeds { get; set; }
    }
}