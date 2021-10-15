using BackEndIntegrador.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndIntegrador.Controllers
{
    [Route("api/publicacion")]
    [ApiController]
    public class PublicacionesController : Controller
    {
        private readonly IPublicacionRepository _repo;

        public PublicacionesController(IPublicacionRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetPublicaciones()
        {
            var listPublicaciones = _repo.GetPublicacion();
            return Ok(listPublicaciones);
        }
    }
}
