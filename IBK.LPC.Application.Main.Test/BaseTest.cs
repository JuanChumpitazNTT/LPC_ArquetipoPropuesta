using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using IBK.LPC.Application.Main.Automapper;
using Microsoft.AspNetCore.Http;
using Moq;
using System.Security.Claims;


namespace IBK.LPC.Application.Main.Test
{
    public class BaseTest
    {
        protected Mock<IServiceProvider> _mockServiceProvider;
        protected Mock<IHttpContextAccessor> _mockHttpContextAccessor;
        protected IMapper _mapper;
        protected string ProfileCode { get; set; }
        public BaseTest()
        {
            AutoMapperConfiguration.Inicializate();
            _mapper = AutoMapperConfiguration.MapperConfiguration!.CreateMapper();

            _mockHttpContextAccessor = new Mock<IHttpContextAccessor>();
            _mockHttpContextAccessor.Setup(_ => _.HttpContext).Returns(GetDefaultHttpContext());
            _mockServiceProvider = new Mock<IServiceProvider>();
            _mockServiceProvider.Setup(x => x.GetService(typeof(IMapper))).Returns(_mapper);
            _mockServiceProvider.Setup(x => x.GetService(typeof(IHttpContextAccessor)))
                .Returns(_mockHttpContextAccessor.Object);

        }

        private DefaultHttpContext GetDefaultHttpContext()
        {
            var defaultHttpContext = new DefaultHttpContext
            {
                User = new ClaimsPrincipal(
                        new ClaimsIdentity(
                            [
                                new Claim("FullName", "admin"),
                                new Claim("Id", "S02230"),
                                new Claim("ProfileCode", "2")
                            ],
                            "Basic")
                        )
            };
            defaultHttpContext.Request.Headers.Append("Authorization", "Authorization");
            return defaultHttpContext;
        }
        public DefaultHttpContext GetDefaultHttpContext2()
        {
            var defaultHttpContext = new DefaultHttpContext
            {
                User = new ClaimsPrincipal(
                        new ClaimsIdentity(
                            [
                                new Claim("FullName", "admin"),
                                new Claim("Id", "S02230"),
                                new Claim("ProfileCode", "6")
                            ],
                            "Basic")
                        )
            };
            defaultHttpContext.Request.Headers.Append("Authorization", "Authorization");
            return defaultHttpContext;
        }
    }
}
