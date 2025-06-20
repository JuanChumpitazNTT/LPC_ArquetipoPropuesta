using AutoMapper;
using IBK.LPC.Application.Main.Automapper.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBK.LPC.Application.Main.Automapper
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            var configuration = new MapperConfiguration(x => { x.AddMaps(typeof(AutoMapperConfiguration)); });
        }
        public static MapperConfiguration? MapperConfiguration { get; private set; }
        public static void Inicializate()
        {
            MapperConfiguration = new MapperConfiguration(configure => {
                configure.AddProfile<ProveedorProfile>();
            });
        }
    }
}
