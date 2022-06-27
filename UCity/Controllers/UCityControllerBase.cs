using Microsoft.AspNetCore.Mvc;
using UCity.Data.Models.Auth;

namespace UCity.Controllers
{
    public class UCityControllerBase : ControllerBase
    {
        public Account? CurrentUserAccount => (Account?)HttpContext.Items["Account"];
    }
}