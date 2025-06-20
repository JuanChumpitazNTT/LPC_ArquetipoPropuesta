using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace IBK.LPC.Application.Main
{
    public class BaseApplication
    {
        protected readonly IServiceProvider _serviceProvider;
        protected readonly IMapper _mapper;
        public BaseApplication(IServiceProvider serviceProvider)
        {
            _mapper = serviceProvider.GetService<IMapper>()!;

        }
    }
}
