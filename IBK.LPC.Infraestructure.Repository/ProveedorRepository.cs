using Dapper;
using IBK.LPC.Domain.Proveedor;
using IBK.LPC.Infraestructure.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Reflection;
using Interbank.Productos.Comercial.Transversal.Interfaces.Models;
using IBK.LPC.Infraestructure.CrossCutting.Models;
using Newtonsoft.Json;
using Interbank.Productos.Comercial.Transversal.Interfaces;
using Interbank.Productos.Comercial.Transversal;

namespace IBK.LPC.Infraestructure.Repository
{
    public class ProveedorRepository : IProveedorRepository
    {

        private readonly string _connectionString;
        private readonly string TAG;
        private readonly IAmbiente _ambiente;

        public ProveedorRepository(IConfiguration configuration, IAmbiente ambiente)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
            TAG = nameof(ProveedorRepository);
            _ambiente = ambiente;
        }


        // VB6: GetData
        public async Task<IEnumerable<Proveedor>> GetDataAsync(string codInstitucion)
        {
            try {
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
            catch (Exception exception)
            {
                throw new RepositoryException
                {
                    TipoExcepcion = Constante.TipoEvento.ERROR,
                    FechaRegistro = DateTime.Now,
                    ExcepcionAnidada = exception,
                    Parametros = JsonConvert.SerializeObject(codInstitucion),
                    Funcion = MethodBase.GetCurrentMethod()!.ReflectedType!.Name,
                    Clase = TAG,
                    RutaLog = _ambiente.RutaEventos
                };
            }
           
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
