using System.Collections.Generic;
using BeersLib;
using Microsoft.AspNetCore.Mvc;

namespace BeersApi.Controllers {
    [ApiController]
    [Route ("[controller]")]
    public class BeersController : ControllerBase {

        static Beers beers = new Beers();

        public BeersController() {

        }

        [HttpGet]        
        public List<Beer> Get () {
            return beers.BeersList;
        }

        [HttpGet("{name}")]
        public Beer GetBeer(string name) {
            return beers.GetBeerByName(name);
        }
        
        [HttpPost]
        public void Post(Beer newBeer) {
            beers.AddBeer(newBeer); 
        }
    }

}