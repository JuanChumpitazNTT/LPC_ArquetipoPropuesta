using IBK.LPC.Domain.Proveedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBK.LPC.Application.Main.Test.Info
{
    public class Datos
    {
        public static IEnumerable<Proveedor> Proveedores()
        {
            return new List<Proveedor>
            {
                new Proveedor
                {
                    CodProveedor = "P001",
                    CodInstitucion = "I001",
                    CodProveedorTipo = "T001",
                    TipoOficProveedor = "Oficina Principal",
                    EstadoProveedor = "Activo",
                    TipoBancaMercado = "Banca Mayorista",
                    TipoProducto = "Producto Financiero",
                    IndProductoActivo = "S",
                    RUC = "12345678901"
                }
            };
        }
        public static Proveedor Proveedor()
        {
            return new Proveedor
            {
                CodProveedor = "P001",
                CodInstitucion = "I001",
                CodProveedorTipo = "T001",
                TipoOficProveedor = "Oficina Principal",
                EstadoProveedor = "Activo",
                TipoBancaMercado = "Banca Mayorista",
                TipoProducto = "Producto Financiero",
                IndProductoActivo = "S",
                RUC = "12345678901"
            };
        }
    }
}
