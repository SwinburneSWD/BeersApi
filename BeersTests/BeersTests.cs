using System;
using System.Collections.Generic;
using BeersLib;
using Xunit;

namespace BeersTests
{
    public class BeersTests
    {
        Beers beersTestList;
        Beer newBeer;

        public BeersTests() {
            this.beersTestList = new Beers();
            this.beersTestList.BeersList = new List<Beer>();
            this.beersTestList.BeersList.Add(new Beer ("Fosters", "CUB", 4.5f, 12, 350, 6f));
            this.beersTestList.BeersList.Add(new Beer ("VB", "CUB", 4.5f, 16, 375, 5f));
            this.beersTestList.BeersList.Add(new Beer ("Colonial Pale", "Colonial Brewing", 4.4f, 35, 375, 7f));

            newBeer = new Beer("Coopers", "Coopers", 3.5f, 5, 375, 5.5f);
        }

        [Theory]
        [InlineData()]
         public Beer GetLightestBeerTest() {
            throw new NotImplementedException();
        }

        [Theory]
        [InlineData()]
        public Beer GetHeaviestBeerTest() {
            throw new NotImplementedException();
        }

        [Theory]
        [InlineData()]
        public Beer CompareAbvTest() {
            throw new NotImplementedException();
        }

        [Theory]
        [InlineData()]
        public void AddBeerTest() {
            throw new NotImplementedException();
        }

        [Theory]
        [InlineData()]
        public void RemoveBeerTest() {
            throw new NotImplementedException();
        }

        [Theory]
        [InlineData()]
        public void UpdateBeerTest() {
            throw new NotImplementedException();
        }

        [Theory]
        [InlineData()]
        public void GetBeerByNameTest() {
            throw new NotImplementedException();
        }

    }
}