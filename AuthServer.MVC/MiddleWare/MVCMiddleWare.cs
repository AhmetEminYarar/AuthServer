
namespace AuthServer.MVC.MiddleWare
{
    public class MVCMiddleWare : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var jwt = context.Request.Cookies["Jwt"];
            if(context.Request.Path != "/Login/Login" && string.IsNullOrEmpty(jwt))
            {
                context.Response.Redirect("/Login/Login");
                return;
            }
            await next(context);
        }
    }
}
