using AutoMapper;
using IBK.LPC.Application.Dto.Proveedor;
using IBK.LPC.Domain.Proveedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBK.LPC.Application.Main.Automapper.Profiles
{
    public class ProveedorProfile : Profile
    {
        public ProveedorProfile() 
        {
            CreateMap<Proveedor, ProveedorDto>()
                .ForMember(dest => dest.CodProveedor, opt => opt.MapFrom(src => src.CodProveedor))
                .ForMember(dest => dest.CodInstitucion, opt => opt.MapFrom(src => src.CodInstitucion))
                .ForMember(dest => dest.CodProveedorTipo, opt => opt.MapFrom(src => src.CodProveedorTipo))
                .ForMember(dest => dest.TipoOficProveedor, opt => opt.MapFrom(src => src.TipoOficProveedor))
                .ForMember(dest => dest.EstadoProveedor, opt => opt.MapFrom(src => src.EstadoProveedor))
                .ForMember(dest => dest.TipoBancaMercado, opt => opt.MapFrom(src => src.TipoBancaMercado))
                .ForMember(dest => dest.TipoProducto, opt => opt.MapFrom(src => src.TipoProducto))
                .ForMember(dest => dest.IndProductoActivo, opt => opt.MapFrom(src => src.IndProductoActivo))
                .ForMember(dest => dest.RUC, opt => opt.MapFrom(src => src.RUC)).ReverseMap() ;
        }
    }
}
