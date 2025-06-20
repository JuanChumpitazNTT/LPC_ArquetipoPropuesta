using System.Data;

namespace IBK.LPC.Infraestructure.DataInterface
{
    public interface IConectionFactory
    {
        IDbConnection GetLPCConnection { get; }
    }
}
