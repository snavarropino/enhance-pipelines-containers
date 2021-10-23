using System;

namespace Samurai.Api.Models
{
    public class Battle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
    }
}