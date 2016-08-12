using System;
using System.Collections.Generic;
using System.Data.Entity;
using Beertap.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Beertap.UnitTest
{
    [TestClass]
    public class OfficeTest
    {
        [TestMethod]
        public void OfficeBeerTest()
        {
            Database.SetInitializer<BeertapContext>(new DropCreateDatabaseAlways<BeertapContext>());

            using (var context = new BeertapContext())
            {
                context.Database.Create();

                var offices = new List<Office>
                {
                    new Office
                    {
                        Location = "Vancouver",
                        Beers = new List<Beer>
                        {
                            new Beer
                            {
                                Brand = "Budweiser",
                                Milliliters = 3900
                            }
                        }
                    },
                    new Office
                    {
                        Location = "Regina",
                        Beers = new List<Beer>
                        {
                            new Beer
                            {
                                Brand = "Bud Light",
                                Milliliters = 3900
                            }
                        }
                    },
                    new Office
                    {
                        Location = "Winnipeg",
                        Beers = new List<Beer>
                        {
                            new Beer
                            {
                                Brand = "Corona Extra",
                                Milliliters = 3900
                            }
                        }
                    },
                    new Office
                    {
                        Location = "Davidson",
                        Beers = new List<Beer>
                        {
                            new Beer
                            {
                                Brand = "Labatt Blue",
                                Milliliters = 3900
                            }
                        }
                    },
                    new Office
                    {
                        Location = "Manila",
                        Beers = new List<Beer>
                        {
                            new Beer
                            {
                                Brand = "Red Horse",
                                Milliliters = 3900
                            },
                            new Beer
                            {
                                Brand = "San Mig Light",
                                Milliliters = 3900
                            }
                        }
                    },
                    new Office
                    {
                        Location = "Sydney",
                        Beers = new List<Beer>
                        {
                            new Beer
                            {
                                Brand = "Victoria Bitter",
                                Milliliters = 3900
                            }
                        }
                    }
                };

                offices.ForEach(o => context.Entry(o).State = EntityState.Added);

                context.SaveChanges();
            }
        }
    }
}
