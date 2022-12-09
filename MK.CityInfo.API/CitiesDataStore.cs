using MK.CityInfo.API.Models;

namespace MK.CityInfo.API
{
    public class CitiesDataStore
    {
        public List<CityDto> Cities { get; set; }

        //public static CitiesDataStore Current { get; } = new CitiesDataStore();

        public CitiesDataStore()
        {
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id = 1,
                    Name = "Istanbul",
                    Description ="The one that have two continents",
                    PointsOfInterest= new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id=1,
                            Name = "Hagia Sophia",
                            Description="The Hagia Sophia (Aya Sofya in Turkish) was the emperor's swaggering statement to the world of the wealth and technical ability of his empire."
                        },

                        new PointOfInterestDto()
                        {
                            Id=2,
                            Name = "Grand Bazaar",
                            Description="For many visitors, sightseeing in Istanbul is as much about shopping as museums and monumental attractions, and the Grand Bazaar is where everyone comes."
                        },
                        new PointOfInterestDto()
                        {
                            Id=3,
                            Name = "Galata Tower",
                            Description="This tower overlooking the Golden Horn was built by the Genoese in the 14th century. Today it remains one of Istanbul's most recognizable landmarks."
                        },
                        new PointOfInterestDto()
                        {
                            Id=4,
                            Name = "Galata Tower",
                            Description="This tower overlooking the Golden Horn was built by the Genoese in the 14th century. Today it remains one of Istanbul's most recognizable landmarks."
                        }
                    }
                },

                new CityDto()
                {
                    Id = 2,
                    Name = "Paris",
                    Description ="The one with that big tower named Eiffel",
                    PointsOfInterest= new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id=1,
                            Name = "Eiffel Tower",
                            Description="The Eiffel Tower (la Tour Eiffel) ranks high on the list of places to visit in France and is the most-visited tourist attraction in the world."
                        },

                        new PointOfInterestDto()
                        {
                            Id=2,
                            Name = "Louvre",
                            Description="A sumptuous palace that was once the home of France's kings, the Louvre is the most important of Paris' top museums."
                        }

                    }
                },

                new CityDto()
                {
                    Id = 3,
                    Name = "Berlin",
                    Description ="The capital of Germany",
                    PointsOfInterest= new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id=1,
                            Name = "The Brandenburg Gate",
                            Description="Berlin's most famous historic landmark is undoubtedly the Brandenburg Gate"
                        },

                        new PointOfInterestDto()
                        {
                            Id=2,
                            Name = "The Berlin Wall Memorial",
                            Description="The Berlin Wall originated in 1961 when East Germany sealed off that half of the city to prevent citizens from fleeing to West Germany."
                        }

                    }
                },

                new CityDto()
                {
                    Id = 4,
                    Name = "Moscow",
                    Description ="One of the biggest cities of Russia",
                    PointsOfInterest= new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id=1,
                            Name = "Red Square",
                            Description="All of Moscow's main streets start at Red Square"
                        },

                        new PointOfInterestDto()
                        {
                            Id=2,
                            Name = "Moscow Metro",
                            Description="Riding the Moscow metro is an experience all in itself," +
                            " but even just heading underground to walk through the stations is something no visitor should miss."
                        }

                    }
                }

            };
        }
    }
}
