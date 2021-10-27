using System.Collections.Generic;

namespace Samurai.Api.Models
{
    public class Samurai
    {
        public string Name { get; set; }
        public List<Battle> Battles { get; set; }
        public List<Quote> Quotes { get; set; }
    }
}
