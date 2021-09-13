using Microsoft.AspNetCore.Mvc;
using MonitXMLServer.Modells;
using System.Collections.Generic;

namespace MonitXMLServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ErroController: ControllerBase
    {
        [HttpGet]
        public List<ErroDTO> GetListaErros()
        {
            if(Dados.lstErros.Count==0)
            {
                Dados.CarregarListaErros();
            }

            return Dados.lstErros;
        }
    }
}
