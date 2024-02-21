using Microsoft.AspNetCore.Mvc;

namespace Prueba.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MatematicaController : ControllerBase
    {
        

        private readonly ILogger<MatematicaController> _logger;

        public MatematicaController(ILogger<MatematicaController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<int> Sumar(int number)
        {
            return number + 1;
            
        }

        [HttpPost("mcm")]
        public async Task<int> MultiploComunMinimo(List<int> numbers)
        {
            int mayor, nn=0;
            foreach (var item in numbers)
            {
                int x, y, z=0;

                x = item;
                mayor = x;
                
                nn = mayor;
                while ((nn % x != 0))
                    nn = nn + 1;
            }

            return nn;
        }
    }
}
