using IBK.LPC.Application.Dto.Proveedor;
using IBK.LPC.Application.Interface;
using IBK.LPC.Domain.Proveedor;
using IBK.LPC.Infraestructure.CrossCutting.Constanst;
using IBK.LPC.Infraestructure.CrossCutting.Logging;
using IBK.LPC.Infraestructure.Interface;

namespace IBK.LPC.Application.Main
{
    public class ProveedorApplication : BaseApplication, IProveedorApplication
    {

        private readonly IProveedorRepository _proveedorService;

        public ProveedorApplication(IServiceProvider serviceProvider, IProveedorRepository proveedorService)
            : base(serviceProvider)
        {
            _proveedorService = proveedorService;
        }


        public async Task<dynamic> GetDataAsync(string codInstitucion)
        {
            var lstEntity = await _proveedorService.GetDataAsync(codInstitucion);
            if (lstEntity.Count() == 0)
            {
                return new JsonResult<object>(false, message: MessageResponseConst.NotFound);
            }
            var bandejaResponses = _mapper.Map<List<ProveedorDto>>(lstEntity);

            return new JsonResult<List<ProveedorDto>>(data: bandejaResponses, message: MessageResponseConst.OKList);
        }

        public async Task<dynamic> AdicionarAsync(ProveedorDto proveedor)
        {
            var objEntity = new Proveedor
            {
                CodProveedor = proveedor.CodProveedor,
                CodInstitucion = proveedor.CodInstitucion,
                CodProveedorTipo = proveedor.CodProveedorTipo,
                TipoOficProveedor = proveedor.TipoOficProveedor,
                EstadoProveedor = proveedor.EstadoProveedor,
                TipoBancaMercado = proveedor.TipoBancaMercado,
                TipoProducto = proveedor.TipoProducto,
                IndProductoActivo = proveedor.IndProductoActivo,
                RUC = proveedor.RUC
            };
            var respuesta = await _proveedorService.AdicionarAsync(objEntity);
            if (respuesta != 0)
            {
                return new JsonResult<object>(false, message: MessageResponseConst.NoInsert);
            }

            return new JsonResult<object>(true, message: MessageResponseConst.OKInsert);
        }

        public async Task<dynamic> ModificarAsync(ProveedorDto proveedor)
        {
            var objEntity = new Proveedor
            {
                CodProveedor = proveedor.CodProveedor,
                CodInstitucion = proveedor.CodInstitucion,
                CodProveedorTipo = proveedor.CodProveedorTipo,
                TipoOficProveedor = proveedor.TipoOficProveedor,
                EstadoProveedor = proveedor.EstadoProveedor,
                TipoBancaMercado = proveedor.TipoBancaMercado,
                TipoProducto = proveedor.TipoProducto,
                IndProductoActivo = proveedor.IndProductoActivo,
                RUC = proveedor.RUC
            };
            var respuesta = await _proveedorService.ModificarAsync(objEntity);
            if (respuesta != 0)
            {
                return new JsonResult<object>(false, message: MessageResponseConst.NoUpdate);
            }

            return new JsonResult<object>(true, message: MessageResponseConst.OKUpdate);
        }

        public async Task<dynamic> EliminarAsync(string codInstitucion)
        {
            var respuesta = await _proveedorService.EliminarAsync(codInstitucion);
            if (respuesta != 0)
            {
                return new JsonResult<object>(false, message: MessageResponseConst.NoDelete);
            }

            return new JsonResult<object>(true, message: MessageResponseConst.OKDelete);
        }
    }
}
