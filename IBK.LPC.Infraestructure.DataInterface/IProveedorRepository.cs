using IBK.LPC.Application.Dto.Proveedor;
using IBK.LPC.Domain.Proveedor;

namespace IBK.LPC.Infraestructure.Interface
{
    public interface IProveedorRepository
    {
        Task<IEnumerable<Proveedor>> GetDataAsync(string codInstitucion);
        Task<long> AdicionarAsync(Proveedor proveedor);
        Task<long> ModificarAsync(Proveedor proveedor);
        Task<long> EliminarAsync(string codInstitucion);
    }
}
