using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBK.LPC.Infraestructure.CrossCutting.Logging
{
    public class JsonResult<TData>
    {
        public bool Valid { get; set; }
        public string Message { get; set; }
        public TData Data { get; set; }

        public JsonResult(TData data)
        {
            Valid = true;
            Data = data;
        }
        public JsonResult(bool valid = true, TData data = default, string message = null)
        {
            Data = data;
            Valid = valid;
            Message = message;
        }

    }
}
