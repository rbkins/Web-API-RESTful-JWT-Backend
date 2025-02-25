using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebapiproductoJWT.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using WebapiproductoJWT.connection;
using WebapiproductoJWT.Data;
using Microsoft.AspNetCore.Authorization;

namespace WebapiproductoJWT.Controllers
{
    [Route("api/productos")]
    [Authorize]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<List<productoModelo>>> Get() {

            var function = new Dpproductos();
            var listar = await function.listarproductos();
            return listar;
        }

        [HttpPost]

        public async Task Post([FromBody] productoModelo parametros) { 
        
            var function = new Dpproductos();
            await function.insertarproductos(parametros);
        
        }

        [HttpPut("{IdProducto}")]

        public async Task<ActionResult> Put(int IdProducto, [FromBody] productoModelo modelo) { 
        
            var function = new Dpproductos();
            modelo.IdProducto = IdProducto;
            await function.editarproductos(modelo);
            return NoContent();
        
        }


        [HttpDelete("{IdProducto}")]

        public async Task<ActionResult> Delete(int IdProducto) {

            var function = new Dpproductos();
            var modelo = new productoModelo();

            modelo.IdProducto = IdProducto;
            await function.eliminarproducto(modelo);
            return NoContent();
        }

    }
}
