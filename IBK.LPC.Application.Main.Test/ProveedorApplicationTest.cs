using IBK.LPC.Application.Dto.Proveedor;
using IBK.LPC.Application.Main.Test.Info;
using IBK.LPC.Domain.Proveedor;
using IBK.LPC.Infraestructure.CrossCutting.Constanst;
using IBK.LPC.Infraestructure.CrossCutting.Logging;
using IBK.LPC.Infraestructure.Interface;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IBK.LPC.Application.Main.Test
{
    public class ProveedorApplicationTest : BaseTest
    {
        [Fact]
        public async Task ReturnRow_WhenDataExist()
        {
            //Arrange
            string codigo = "P001";
            var _mockIProveedorRepository = new Mock<IProveedorRepository>();

            _mockIProveedorRepository
                .Setup(m => m.GetDataAsync(It.IsAny<string>()))
                .ReturnsAsync(Datos.Proveedores());
            ProveedorApplication service = new ProveedorApplication(_mockServiceProvider.Object, _mockIProveedorRepository.Object);
            // Act
            var result = await service.GetDataAsync(codigo);

            // Assert
            var jsonResult = Assert.IsType<JsonResult<List<ProveedorDto>>>(result);
            Assert.NotEmpty(jsonResult.Data);
            Assert.Equal(MessageResponseConst.OKList, jsonResult.Message);
        }
        [Fact]
        public async Task ReturnRow_WhenDataNOExist()
        {
            //Arrange
            string codigo = "PXYZ";
            var _mockIProveedorRepository = new Mock<IProveedorRepository>();

            _mockIProveedorRepository
                .Setup(m => m.GetDataAsync(It.IsAny<string>()))
                .ReturnsAsync(new List<Proveedor>());
            
            ProveedorApplication service = new ProveedorApplication(_mockServiceProvider.Object, _mockIProveedorRepository.Object);
            
            // Act
            var result = await service.GetDataAsync(codigo);

            // Assert
            var jsonResult = Assert.IsType<JsonResult<object>>(result);
            Assert.True(jsonResult.Valid == false);
            Assert.Equal(MessageResponseConst.NotFound, jsonResult.Message);
        }
        [Fact]
        public async Task ReturnTrue_WhenDataAdd()
        {
            //Arrange
            ProveedorDto proveedorDto = new ProveedorDto
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
            var _mockIProveedorRepository = new Mock<IProveedorRepository>();

            _mockIProveedorRepository
                .Setup(m => m.AdicionarAsync(It.IsAny<Proveedor>()))
                .ReturnsAsync(0);

            ProveedorApplication service = new ProveedorApplication(_mockServiceProvider.Object, _mockIProveedorRepository.Object);
            // Act
            var result = await service.AdicionarAsync(proveedorDto);

            // Assert
            var jsonResult = Assert.IsType<JsonResult<object>>(result);
            Assert.True(jsonResult.Valid);
            Assert.Equal(MessageResponseConst.OKInsert, jsonResult.Message);
        }
        [Fact]
        public async Task ReturnTrue_WhenDataNOAdd()
        {
            //Arrange
            ProveedorDto proveedorDto = new ProveedorDto
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
            var _mockIProveedorRepository = new Mock<IProveedorRepository>();

            _mockIProveedorRepository
                .Setup(m => m.AdicionarAsync(It.IsAny<Proveedor>()))
                .ReturnsAsync(-1);

            ProveedorApplication service = new ProveedorApplication(_mockServiceProvider.Object, _mockIProveedorRepository.Object);
            // Act
            var result = await service.AdicionarAsync(proveedorDto);

            // Assert
            var jsonResult = Assert.IsType<JsonResult<object>>(result);
            Assert.True(jsonResult.Valid == false);
            Assert.Equal(MessageResponseConst.NoInsert, jsonResult.Message);
        }
        [Fact]
        public async Task ReturnTrue_WhenDataUpdate()
        {
            //Arrange
            ProveedorDto proveedorDto = new ProveedorDto
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
            var _mockIProveedorRepository = new Mock<IProveedorRepository>();

            _mockIProveedorRepository
                .Setup(m => m.ModificarAsync(It.IsAny<Proveedor>()))
                .ReturnsAsync(0);

            ProveedorApplication service = new ProveedorApplication(_mockServiceProvider.Object, _mockIProveedorRepository.Object);
            // Act
            var result = await service.ModificarAsync(proveedorDto);

            // Assert
            var jsonResult = Assert.IsType<JsonResult<object>>(result);
            Assert.True(jsonResult.Valid);
            Assert.Equal(MessageResponseConst.OKUpdate, jsonResult.Message);
        }
        [Fact]
        public async Task ReturnTrue_WhenDataNOUpdate()
        {
            //Arrange
            ProveedorDto proveedorDto = new ProveedorDto
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
            var _mockIProveedorRepository = new Mock<IProveedorRepository>();

            _mockIProveedorRepository
                .Setup(m => m.ModificarAsync(It.IsAny<Proveedor>()))
                .ReturnsAsync(-1);

            ProveedorApplication service = new ProveedorApplication(_mockServiceProvider.Object, _mockIProveedorRepository.Object);
            // Act
            var result = await service.ModificarAsync(proveedorDto);

            // Assert
            var jsonResult = Assert.IsType<JsonResult<object>>(result);
            Assert.True(jsonResult.Valid == false);
            Assert.Equal(MessageResponseConst.NoUpdate, jsonResult.Message);
        }
        [Fact]
        public async Task ReturnTrue_WhenDataDelete()
        {
            //Arrange
            var _mockIProveedorRepository = new Mock<IProveedorRepository>();

            _mockIProveedorRepository
                .Setup(m => m.EliminarAsync(It.IsAny<string>()))
                .ReturnsAsync(0);

            ProveedorApplication service = new ProveedorApplication(_mockServiceProvider.Object, _mockIProveedorRepository.Object);
            // Act
            var result = await service.EliminarAsync("P001");

            // Assert
            var jsonResult = Assert.IsType<JsonResult<object>>(result);
            Assert.True(jsonResult.Valid);
            Assert.Equal(MessageResponseConst.OKDelete, jsonResult.Message);
        }
        [Fact]
        public async Task ReturnTrue_WhenDataNODelete()
        {
            //Arrange
            var _mockIProveedorRepository = new Mock<IProveedorRepository>();

            _mockIProveedorRepository
                .Setup(m => m.EliminarAsync(It.IsAny<string>()))
                .ReturnsAsync(-1);

            ProveedorApplication service = new ProveedorApplication(_mockServiceProvider.Object, _mockIProveedorRepository.Object);
            // Act
            var result = await service.EliminarAsync("P001");

            // Assert
            var jsonResult = Assert.IsType<JsonResult<object>>(result);
            Assert.True(jsonResult.Valid == false);
            Assert.Equal(MessageResponseConst.NoDelete, jsonResult.Message);
        }
    }
}
