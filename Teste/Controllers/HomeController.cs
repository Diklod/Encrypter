using Microsoft.AspNetCore.Mvc;
using Teste.Global;

namespace aulacriptografia.Controllers
{

    [ApiController]
    [Route("api/home")]
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("EncodeToBytes")]
        public JsonResult EncodeToBytes(string text)
        {
            Security security = new Security();
            string result = security.EncodeToBytes(text);
            return new JsonResult(new { success = true, data = result });

        }


        [HttpGet]
        [Route("DecodeToBytes")]
        public JsonResult DecodeToBytes(string text)
        {
            Security security = new Security();
            string result = security.DecodeToBytes(text);
            return new JsonResult(new { success = true, data = result });

        }


        [HttpGet]
        [Route("EncodeFromBase64")]
        public JsonResult EncodeFromBase64(string text)
        {
            string result = string.Empty;
            Security security = new Security();
            result = security.EncodeFromBase64(text);
            return new JsonResult(new { success = true, data = result });
        }


        [HttpGet]
        [Route("DecodeFromBase64")]
        public JsonResult DecodeFromBase64(string text)
        {
            string result = string.Empty;
            Security security = new Security();
            result = security.DecodeFromBase64(text);
            return new JsonResult(new { success = true, data = result });
        }


        [HttpGet]
        [Route("EncryptoMD5")]
        public JsonResult EncryptoMD5(string text)
        {
            string result = string.Empty;
            Security security = new Security();
            result = security.EncryptMD5(text);
            return new JsonResult(new { success = true, data = result });
        }
    }
}
