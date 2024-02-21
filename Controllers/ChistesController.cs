using Microsoft.AspNetCore.Mvc;

namespace Prueba.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChistesController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ChistesController> _logger;
        private AppBBDDContext _appBBDDContext;

        public ChistesController(ILogger<ChistesController> logger,
            AppBBDDContext context
            )
        {
            _logger = logger;
            _appBBDDContext = context;
        }

        [HttpGet]
        public async Task<Object> Get(string param)
        {

            var client = new HttpClient();
            Object content = null;

            if (param.Equals("chuck", StringComparison.OrdinalIgnoreCase))
            {
                var result = await client.GetAsync("https://api.chucknorris.io/jokes/random");
                if (!result.IsSuccessStatusCode)
                {
                    throw new Exception("Ha ocurrido un error");
                }

                content = await result.Content.ReadFromJsonAsync<object>();


            }

            if (param.Equals("dad", StringComparison.OrdinalIgnoreCase))
            {
                var result = await client.GetAsync("https://icanhazdadjoke.com/slack");
                if (!result.IsSuccessStatusCode)
                {
                    throw new Exception("Ha ocurrido un error");
                }

                content = await result.Content.ReadFromJsonAsync<object>();
            }

            return content;
        }

        [HttpPost("delete")]
        public async Task<Object> Delete(int chisteId)
        {
            var chiste =_appBBDDContext.Chistes.FirstOrDefault(c => c.Id == chisteId);
            if(chiste != null)
            {
                var tc =_appBBDDContext.TematicasChistes.FirstOrDefault(tc => tc.IDChiste==chisteId);
                _appBBDDContext.Chistes.Remove(chiste);
                if(tc != null)
                    _appBBDDContext.TematicasChistes.Remove(tc);
                _appBBDDContext.SaveChanges();
                return "Chiste borrado correctamente";
            }

            return "El chiste no ha sido encontrado";
        }

        [HttpPost("update")]
        public async Task<Object> Update(int chisteId,[FromBody] Chiste chiste)
        {
            var c = _appBBDDContext.Chistes.FirstOrDefault(c => c.Id == chisteId);
            if (c != null)
            {
                _appBBDDContext.Chistes.Update(chiste);
                _appBBDDContext.SaveChanges();
                return "Chiste guardado correctamente";
            }

            return "El chiste no ha sido encontrado";
        }

        [HttpPost("add")]
        public async Task<Object> Add([FromBody] Chiste chiste)
        {

            _appBBDDContext.Chistes.Add(chiste);
            _appBBDDContext.SaveChanges();
            _appBBDDContext.TematicasChistes.Add(new TematicasChistes()
            {
                IDTematica = chiste.TematicaId,
                IDChiste = chiste.Id
            });
            _appBBDDContext.SaveChanges();

            return "Chiste guardado correctamente";

        }
    }
}
