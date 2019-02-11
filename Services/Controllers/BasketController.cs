using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataLayer.Models;
using DataLayer;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;

namespace Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IRepository _repo;

        public BasketController(IRepository repo) => _repo = repo;

        // GET: api/Basket {all}
        [HttpGet]
        //[EnableQuery]  - in .net core 2.x you cannot use OData without a database contextuall model. - therefore I cannot use that for this example project
        [ODataRoute("Basket", RouteName = "Get")]
        public IEnumerable<Basket> Get()
        {
                return _repo.getAllBaskets();
        }

        // GET: api/Basket/{id}
        [HttpGet("{id}", Name = "GetById")]
        public Basket Get(string id)
        {
            return _repo.getBasketById(id);
        }

    }
}
