using Dapper;
using IBK.LPC.Application.Dto.Proveedor;
using IBK.LPC.Domain.Proveedor;
using IBK.LPC.Infraestructure.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace IBK.LPC.Infraestructure.Repository
{
    public class ProveedorRepository : IProveedorRepository
    {

        private readonly string _connectionString;

        public ProveedorRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }


        // VB6: GetData
        public async Task<IEnumerable<Proveedor>> GetDataAsync(string codInstitucion)
        {
            using var conn = new SqlConnection(_connectionString);
            var parameters = new DynamicParameters();
            parameters.Add("@Operacion", "C");
            parameters.Add("@OtroParam", ""); // si tu SP lo necesita
            parameters.Add("@CodInstitucion", codInstitucion);

            var result = await conn.QueryAsync<Proveedor>(
                "UP_Proveedor_SEL",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return result;
        }

        // VB6: Adicionar

        public async Task<long> AdicionarAsync(Proveedor proveedor)
        {
            using var conn = new SqlConnection(_connectionString);
            var parameters = CrearParametrosProveedor(proveedor, 2);

            var respuesta = await conn.ExecuteAsync("UP_Proveedor_INS", parameters, commandType: CommandType.StoredProcedure);
            return respuesta;
        }

        // VB6: Modificar
        public async Task<long> ModificarAsync(Proveedor proveedor)
        {
            using var conn = new SqlConnection(_connectionString);
            var parameters = CrearParametrosProveedor(proveedor, 1);

            var respuesta = await conn.ExecuteAsync("UP_Proveedor_UPD", parameters, commandType: CommandType.StoredProcedure);
            return respuesta;
        }

        // VB6: Eliminar
        public async Task<long> EliminarAsync(string codInstitucion)
        {
            if (string.IsNullOrWhiteSpace(codInstitucion))
                return 1025;

            using var conn = new SqlConnection(_connectionString);
            var parameters = new DynamicParameters();
            parameters.Add("@Type", 1);
            parameters.Add("@CodProveedor", "");
            parameters.Add("@CodInstitucion", codInstitucion);
            parameters.Add("@CodProveedorTipo", "");
            parameters.Add("@TipoOficProveedor", "");
            parameters.Add("@EstadoProveedor", "");
            parameters.Add("@TipoBancaMercado", "");
            parameters.Add("@CodModuloOperacion", "");
            parameters.Add("@TipoOperacion", "");
            parameters.Add("@FechaRegistro", null);
            parameters.Add("@CodUsuario", "");
            parameters.Add("@TextoAudiCreacion", "");
            parameters.Add("@TextoAudiModi", "");
            parameters.Add("@TipoProducto", "");
            parameters.Add("@IndProductoActivo", "");
            parameters.Add("@RUC", "");

            await conn.ExecuteAsync("UP_Proveedor_DEL", parameters, commandType: CommandType.StoredProcedure);
            return 0;
        }

        private DynamicParameters CrearParametrosProveedor(Proveedor proveedor, int tipoOperacion)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Type", tipoOperacion);
            parameters.Add("@CodProveedor", proveedor.CodProveedor ?? "");
            parameters.Add("@CodInstitucion", proveedor.CodInstitucion ?? "");
            parameters.Add("@CodProveedorTipo", proveedor.CodProveedorTipo ?? "");
            parameters.Add("@TipoOficProveedor", proveedor.TipoOficProveedor ?? "");
            parameters.Add("@EstadoProveedor", proveedor.EstadoProveedor ?? "");
            parameters.Add("@TipoBancaMercado", proveedor.TipoBancaMercado ?? "");
            parameters.Add("@CodModuloOperacion", "");
            parameters.Add("@TipoOperacion", "");
            parameters.Add("@FechaRegistro", null);
            parameters.Add("@CodUsuario", "");
            parameters.Add("@TextoAudiCreacion", "");
            parameters.Add("@TextoAudiModi", "");
            parameters.Add("@TipoProducto", proveedor.TipoProducto ?? "");
            parameters.Add("@IndProductoActivo", proveedor.IndProductoActivo ?? "");
            parameters.Add("@RUC", proveedor.RUC ?? "");
            return parameters;
        }


    }
}
