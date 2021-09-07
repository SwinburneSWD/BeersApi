using System.Collections.Generic;
using BeersLib;
using Microsoft.AspNetCore.Mvc;
using BeersApi.Handlers;

namespace BeersApi.Controllers {
    [ApiController]
    [Route ("[controller]")]
    public class BeersController : ControllerBase {

        static Beers beers = new Beers();
        DbHandler dbh = new DbHandler();

        public BeersController() {

        }

        [HttpGet]        
        public List<Beer> Get () {
            return this.dbh.GetAllBeers();
        }

        [HttpGet("{name}")]
        public Beer GetBeer(string name) {
            return this.dbh.GetBeerByName(name);
        }
        
        [HttpPost]
        public void Post(Beer newBeer) {
            beers.AddBeer(newBeer); 
        }
    }

}