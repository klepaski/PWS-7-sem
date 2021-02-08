using System.Web.Mvc;
using System.Web.Http;
using Lab8.Models;
using Newtonsoft.Json;
using System.Web;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace Lab8.Controllers
{
    public class JRServiceController : Controller
    {
        [HttpPost]
        public JsonResult Multi([FromBody] ReqJsonRPC[] body)
        {
            int length = body.Length;
            JsonResult[] result = new JsonResult[length];

            for (int i = 0; i < length; i++)
                result[i] = Single(body[i]);

            return Json(result);
        }

        [HttpPost]
        public JsonResult Single(ReqJsonRPC body)
        {
            if ((string)HttpContext.Session["ignore"] == "1")
                return Json(new ResJsonRPCError()
                {
                    Id = body.Id,
                    Error = new ErrorJsonRPC { Message = "Methods are not available", Code = -32601 }
                });

            string method = body.Method;
            DataModel param = body.Params;
            if(param == null)
            {
                return Json(body, JsonRequestBehavior.AllowGet);
            }
            int? result = null;

            string key = param.Key;
            int value = int.Parse(param.Value == null || param.Value == "" ? "0" : param.Value);

            switch (method)
            {
                case "SetM": { result = SetM(key, value); break; }
                case "GetM": { result = GetM(key); break; }
                case "AddM": { result = AddM(key, value); break; }
                case "SubM": { result = SubM(key, value); break; }
                case "MulM": { result = MulM(key, value); break; }
                case "DivM": { result = DivM(key, value); break; }
                case "ErrorExit": { ErrorExit(); break; }

                default:
                {
                    return Json(new ResJsonRPCError()
                    {
                        Id = body.Id,
                        Error = new ErrorJsonRPC { Message = "Function is not found", Code = -32601 }
                    });
                }
            }

            return Json(new ResJsonRPC()
            {
                Id = body.Id,
                Method = body.Method,
                Result = result
            }, JsonRequestBehavior.AllowGet
            );
        }
        
        private int? SetM(string k, int x)
        {
            HttpContext.Session.Add(k, x);
            return GetM(k);
        }

        private int? GetM(string k)
        {
            object result = HttpContext.Session[k];
            if (result == null)
                return null;
            else
                return int.Parse(result.ToString());
        }

        private int? AddM(string k, int x)
        {
            int? value = GetM(k);
            System.Web.HttpContext.Current.Session[k] = value == null ? x : value + x;
            return GetM(k);
        }

        private int? SubM(string k, int x)
        {
            int? value = GetM(k);
            System.Web.HttpContext.Current.Session[k] = value == null ? x : value - x;
            return GetM(k);
        }

        private int? MulM(string k, int x)
        {
            int? value = GetM(k);
            System.Web.HttpContext.Current.Session[k] = value == null ? x : value * x;
            return GetM(k);
        }

        private int? DivM(string k, int x)
        {
            int? value = GetM(k);
            System.Web.HttpContext.Current.Session[k] = value == null ? x : value / x;
            return GetM(k);
        }

        private void ErrorExit()
        {
            System.Web.HttpContext.Current.Session.Clear();
            System.Web.HttpContext.Current.Session["ignore"] = "1";
        }
    }
}