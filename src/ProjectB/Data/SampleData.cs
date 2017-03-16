using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using ProjectB.Models;
using System.Collections.Generic;

namespace ProjectB.Data
{
    public class SampleData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            // Ensure db
            context.Database.EnsureCreated();

            // Ensure Stephen (IsAdmin)
            var reginald = await userManager.FindByNameAsync("beason.reginald@gmail.com");
            if (reginald == null)
            {
                // create user
                reginald = new ApplicationUser
                {
                    UserName = "Kanakara",
                    Email = "beason.reginald@gmail.com"
                };
                await userManager.CreateAsync(reginald, "Secret123!");

                // add claims
                await userManager.AddClaimAsync(reginald, new Claim("IsAdmin", "true"));
            }
            if (!context.Quotes.Any())
            {
                var myQuotes = new Quote[]
                {
                    new Quote {Statement = "I wanted a perfect ending. Now I've learned, the hard way, that some poems don't rhyme, and some stories don't have a clear beginning, middle, and end. Life is about not knowing, having to change, taking the moment and making the best of it, without knowing what's going to happen next. Delicious Ambiguity.", Author = "Gilda Radner" },
                    new Quote {Statement = "The only way to have a friend is to be one.", Author = "Ralph Waldo Emerson"  },
                    new Quote {Statement = "I don't spend much time thinking about whether God exists. I don't consider that a relevant question. It's unanswerable and irrelevant to my life, so I put it in the category of things I can't worry about.", Author = "Wendy Kaminer"  },
                    new Quote {Statement = "Ideals are like stars: you will not succeed in touching them with your hands, but like the seafaring man on the desert of waters, you choose them as your guides, and following them you reach your destiny.", Author = "Carl Schurz"  },
                    new Quote {Statement = "Success is not the key to happiness. Happiness is the key to success. If you love what you are doing, you will be successful.", Author = "Albert Schweitzer"  },
                    new Quote {Statement = "My will shall shape the future. Whether I fail or succeed shall be no man's doing but my own. I am the force; I can clear any obstacle before me or I can be lost in the maze. My choice; my responsibility; win or lose, only I hold the key to my destiny.", Author = "Elaine Maxwell"  },
                    new Quote {Statement = "How far you go in life depends on your being tender with the young, compassionate with the aged, sympathetic with the striving and tolerant of the weak and strong. Because someday in life you will have been all of these.", Author= "George Washington Carver"  },
                    new Quote {Statement = "In these days, a man who says a thing cannot be done is quite apt to be interrupted by some idiot doing it.", Author = "Elbert Hubbard"  },
                    new Quote {Statement = "You cannot dream yourself into a character; you must hammer and forge yourself one.", Author = "James A. Froude" },
                    new Quote {Statement = "Trust only movement. Life happens at the level of events, not of words. Trust movement.", Author = "Alfred Adler" },
                    new Quote {Statement = "We do not grow absolutely, chronologically. We grow sometimes in one dimension, and not in another; unevenly. We grow partially. We are relative. We are mature in one realm, childish in another. The past, present, and future mingle and pull us backward, forward, or fix us in the present. We are made up of layers, cells, constellations.", Author = "Anais Nin" }
                };

                context.Quotes.AddRange(myQuotes);
                context.SaveChanges();
            }
            if (!context.DanceEvents.Any())
            {
                var listEvent = new DanceEvent[]
                {
            new DanceEvent {Name = "Capital Swing", City = "Sacramento", State = "CA", Category = "NASDE", URL="http://www.capitalswingconvention.com/" },
            new DanceEvent {Name = "MADjam", City = "Baltimore", State = "MD", Category = "NASDE", URL="http://www.atlanticdancejam.com/"  },
            new DanceEvent {Name = "Chicago Classics", City = "Chicago", State = "IL", Category = "NASDE", URL="https://thechicagoclassic.com/"  },
            new DanceEvent {Name = "Seattle Easter Swing", City = "Seattle", State = "WA", Category = "NASDE", URL="http://easterswing.org/"  },
            new DanceEvent {Name = "Swing Diego", City = "San Diego", State = "CA", Category = "NASDE", URL="https://www.swingdiego.com/"  },
            new DanceEvent {Name = "USA Grand Nationals", City = "Marietta", State = "GA", Category = "NASDE" , URL="http://usagrandnationals.com/GNDC/" },
            new DanceEvent {Name = "Liberty Swing", City = "New Brunswick", State = "NJ", Category = "NASDE", URL="http://www.libertyswing.com/"  },
            new DanceEvent {Name = "Swingtime in the Rockies", City = "Denver", State = "CO", Category = "NASDE", URL="http://www.swingtimeintherockies.com/"  },
            new DanceEvent {Name = "Tampa Bay Classics", City = "Tampa Bay", State = "FL", Category = "NASDE", URL="http://tampabayclassic.com/"  },
            new DanceEvent {Name = "Summer Hummer", City = "Boston", State = "MA", Category = "NASDE", URL="http://dancepros.net/"  },
            new DanceEvent {Name = "Boogie by the Bay", City = "San Francisco", State = "CA", Category = "NASDE", URL="https://boogiebythebay.com/"  },
            new DanceEvent {Name = "The US Open", City = "Burbank", State = "CA", Category = "NASDE", URL="http://usopenswing.com/"  },
            new DanceEvent {Name = "West Coast Swing BudaFest", City = "Budapest", State = "Hungary", Category = "Global", URL="http://wcs-budafest.com/"  },
            new DanceEvent {Name = "Austin Swing Dance Championship", City = "Austin", State = "TX", Category = "US", URL="http://www.austinswingdancechampionships.com/"  },
            new DanceEvent {Name = "Charlotte Westie Fest", City = "Charlotte", State = "NC", Category = "US" , URL="http://www.charlottewestiefest.com/" },
            new DanceEvent {Name = "U.K. & European WCS Championships", City = "London", State = "England", Category = "Global", URL="http://www.jiveaddiction.com/event-type/west-coast-swing"  },
            new DanceEvent {Name = "Asia West Coast Swing Open", City = "Singapore", State = "China", Category = "Global", URL="http://www.asiawcsopen.com/"  },
            new DanceEvent {Name = "Jack & Jill O'Rama", City = "Garden Grove", State = "CA", Category = "US", URL="http://jackandjillorama.com/"  },
            new DanceEvent {Name = "Phoenix 4th of July", City = "Phoenix", State = "AZ", Category = "US", URL="http://www.phoenix4thofjuly.com/2016-convention.html"  },
            new DanceEvent {Name = "Desert City Swing", City = "Phoenix", State = "AZ", Category = "US", URL="http://www.desertcityswing.com/"  },
            new DanceEvent {Name = "Bavarian Open WCS", City = "Munich", State = "Germany", Category = "Global", URL="https://bavarianopen.com/"  },
            new DanceEvent {Name = "Atlanta Swing Classics", City = "Atlanta", State = "GA", Category = "US", URL="http://www.atlantaswingclassic.com/"  },
            new DanceEvent {Name = "DC Swing Experience", City = "Herndon", State = "VA", Category = "US", URL="http://www.dcswingexperience.com/"  },
            new DanceEvent {Name = "New Year's Swing Fling", City = "Heathorw", State = "England", Category = "Global", URL="https://www.nyswingfling.co.uk/"  },
            new DanceEvent {Name = "Spotlight Dance Celebration", City = "Dearborn", State = "MI", Category = "US", URL="http://www.spotlightnewyears.com/"  }
                        };

                context.DanceEvents.AddRange(listEvent);
                context.SaveChanges();
            }
        }
    }
}
