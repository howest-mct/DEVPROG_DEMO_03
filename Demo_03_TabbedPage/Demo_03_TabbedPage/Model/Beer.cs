using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace Demo_03_TabbedPage.Model
{
    //make class public
    public class Beer
    {
        //1. PROPERTIES
        public string Name { get; set; } //: Simple property "prop"

        //Simple property alternative "propfull":
        //private string _name;

        //public string Name
        //{
        //    get { return _name; }
        //    set { _name = value; }
        //}

        public string Brewery { get; private set; } //Readonly property

        public double Alcohol { get; set; } //required type double

        //Extra logic in set using "propfull"
        private string _color;

        public string Color
        {
            get { return _color; }
            set
            {
                if (value != "")
                {
                    this._color = value;
                }
                else
                {
                    this._color = "unknown";
                }
            }
        }


        //2. CONSTRUCTORS

        //empty ctor
        public Beer()
        {

        }

        //each parameter has an explicit type
        public Beer(string name, string brewery, double alcoholPerc, string color)
        {
            this.Name = name;
            this.Color = color;
            this.Alcohol = alcoholPerc;
            this.Brewery = brewery;
        }

        //3. METHODS

        //default ToString (Python: def __str__(self): )
        public override string ToString()
        {
            return Name + " (" + Brewery + ")";
        }

        /// <summary>
        /// Get a hard coded list of beer objects
        /// </summary>
        /// <returns>the list of beer objects</returns>
        public static List<Beer> GetBeers()
        {
            //return new List<Beer>
            //{
            //    new Beer("Rodenbach Grand Cru", "Rodenbach", 6, "brown"),
            //    new Beer("Jupiler", "InBev", 5.2, "blond"),
            //    new Beer("Omer", "Bockor", 8, "blond"),
            //    new Beer("PartyBeer", "SomeBrewery", 0, "blond"),
            //    new Beer("Duvel", "Duvel Moortgat", 8.5, "")
            //};
            return ReadBeers(); //return list from csv instead of hard coded list
        }

        /// <summary>
        /// Reads the embedded csv file beerlist.csv (in Assets folder)
        /// Returns a list of all beers in the file.
        /// </summary>
        /// <returns></returns>
        private static List<Beer> ReadBeers()
        {
            List<Beer> beerlist = new List<Beer>();

            var assembly = typeof(Beer).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("Demo_03_TabbedPage.Assets.beerlist.csv");

            using (var reader = new System.IO.StreamReader(stream))
            {
                reader.ReadLine(); //ignore first line (title row)
                string line = reader.ReadLine();

                while (line != null)
                {
                    string[] parts = line.Split(';');

                    try
                    {
                        //using the constructor that gets all property values:
                        //beerlist.Add(new Beer(parts[0], parts[1], Convert.ToDouble(parts[2]), parts[3]));

                        //alternative: using the empty constructor
                        //  => object composition
                        beerlist.Add(new Beer
                        {
                            Name = parts[0],
                            Brewery = parts[1],
                            Alcohol = Convert.ToDouble(parts[2]),
                            Color = parts[3]
                        });
                    }
                    catch (Exception)
                    {
                        Debug.WriteLine("error processing line: " + line);
                    }
                    line = reader.ReadLine();
                }
            }

            return beerlist;
        }

        public static List<Beer> GetBeersFiltered(bool isAlcoholFree)
        {
            List<Beer> filteredBeers = new List<Beer>();

            foreach (Beer beer in GetBeers())
                if ((beer.Alcohol == 0) == isAlcoholFree) //check if (not) alcohol free
                    filteredBeers.Add(beer);

            return filteredBeers;
        }

        public static IEnumerable GetBreweries()
        {
            List<string> breweries = new List<string>();

            foreach (Beer beer in GetBeers())
                if (!breweries.Contains(beer.Brewery))
                    breweries.Add(beer.Brewery);

            return breweries;
        }
    }
}
