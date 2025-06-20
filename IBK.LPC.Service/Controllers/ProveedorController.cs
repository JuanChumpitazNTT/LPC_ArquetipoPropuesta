using IBK.LPC.Application.Dto.Proveedor;
using IBK.LPC.Application.Interface;
using IBK.LPC.Application.Main;
using Microsoft.AspNetCore.Mvc;

namespace IBK.LPC.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorApplication _handler;

        public ProveedorController(IProveedorApplication handler)
        {
            _handler = handler;
        }

        [HttpGet("{codInstitucion}")]
        public async Task<List<ProveedorDto>> Get(string codInstitucion)
        {
            var result = await _handler.GetDataAsync(codInstitucion);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProveedorDto proveedor)
        {
            var result = await _handler.AdicionarAsync(proveedor);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProveedorDto proveedor)
        {
            var result = await _handler.ModificarAsync(proveedor);
            return Ok(result);
        }

        [HttpDelete("{codInstitucion}")]
        public async Task<IActionResult> Delete(string codInstitucion)
        {
            var result = await _handler.EliminarAsync(codInstitucion);
            return Ok(result);
        }
    }
}
