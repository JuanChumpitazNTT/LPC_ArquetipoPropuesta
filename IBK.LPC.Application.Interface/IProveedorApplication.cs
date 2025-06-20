using IBK.LPC.Application.Dto.Proveedor;

namespace IBK.LPC.Application.Interface
{
    public interface IProveedorApplication
    {
        Task<dynamic> GetDataAsync(string codInstitucion); // VB6: GetData
        Task<dynamic> AdicionarAsync(ProveedorDto proveedor); // VB6: Adicionar
        Task<dynamic> ModificarAsync(ProveedorDto proveedor); // VB6: Modificar
        Task<dynamic> EliminarAsync(string codInstitucion); // VB6: Eliminar
    }
}
