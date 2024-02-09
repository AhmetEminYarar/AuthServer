using AuthServer.Data.UnitOfWork;
using System.Net;
using System.Text.Json;
using AuthServer.DTO.Response.Error;

namespace AuthServer.Api.Middlewares
{
    public class GlobalExMiddleware : IMiddleware
    {
        private readonly IUnitOfWork _unitOfWork;

        public GlobalExMiddleware(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
                await _unitOfWork.CommitTranssections();

            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTranssections();
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                ErrorDetailsResponse errorDetailsResponse = new()
                {
                    status = (int)HttpStatusCode.InternalServerError,
                    title = "Internal Server Error",
                    message = ex.Message
                };

                string json = JsonSerializer.Serialize(new { error = errorDetailsResponse });

                await context.Response.WriteAsync(json);
            }
        }

    }
}

