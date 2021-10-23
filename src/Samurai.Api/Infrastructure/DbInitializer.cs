using System;
using System.Collections.Generic;
using System.Linq;
using Samurai.Api.Models;

namespace Samurai.Api.Infrastructure
{
    public class DbInitializer
    {
        public static void Initialize(SamuraiContext context)
        {
            try
            {
                context.Database.EnsureCreated();
            }
            catch (Exception e)
            {
                Program.Error += "En ensure created:" +e.Message;
            }
            

            // Look for any students.
            if (context.Samurais.Any())
            {
                return;   // DB has been seeded
            }

            context.Samurais.AddRange(GetDefaultSamurais());
            context.SaveChanges();
        }

        private static IEnumerable<Models.Samurai> GetDefaultSamurais()
        {
            return new List<Models.Samurai>()
            {
                new Models.Samurai()
                {
                    Name    = "Takeshi",
                    Battles = new List<Battle>()
                    {
                        new Battle()
                        {
                            Name = "Tokio defense",
                            Location = "Tokio",
                            Date = new DateTime(1810,1,1)
                        }
                    },
                    Quotes = new List<Quote>()
                    {
                        new Quote()
                        {
                            Text = "Train as much as you can"
                        }
                    }
                },
                new Models.Samurai()
                {
                    Name    = "Koji",
                    Battles = new List<Battle>()
                    {
                        new Battle()
                        {
                            Name = "Tokio defense",
                            Location = "Tokio",
                            Date = new DateTime(1810,1,1)
                        }
                    },
                    Quotes = new List<Quote>()
                    {
                        new Quote()
                        {
                            Text = "Cofee time!"
                        }
                    }
                }
            };
        }
    }
}
