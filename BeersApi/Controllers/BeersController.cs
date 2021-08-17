using System.Collections.Generic;
using BeersLib;
using Microsoft.AspNetCore.Mvc;

namespace BeersApi.Controllers {
    [ApiController]
    [Route ("[controller]")]
    public class BeersController : ControllerBase {

        Beers beers = new Beers();

        [HttpGet]
        public List<Beer> Get () {
            return beers.BeersList;
        }

        [HttpGet("{name}")]
        public Beer GetBeer(string name) {
            return beers.GetBeerByName(name);
        }
    }

}