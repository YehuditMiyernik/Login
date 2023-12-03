using Entities.Models;
using PresidentsApp.Middlewares;
using Services;

namespace MyFirstWebApi.Middlewares
{
    public class RatingMiddleware
    {
        private IRatingService _ratingService;
        private readonly RequestDelegate _next;
        public RatingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext, IRatingService ratingService)
        {
            _ratingService = ratingService;
            Rating rating = new Rating();
            //rating.Host = httpContext.Request.Host.ToString();
            //rating.Method = httpContext.Request.Method;
            //rating.Path = httpContext.Request.Path;
            //rating.Referer = httpContext.Request.Protocol + httpContext.Request.Host;
            //rating.UserAgent = httpContext.Session.Id.ToString();
            //rating.RecordDate = new DateTime();
            rating.Host = "yehudit";
            await _ratingService.AddRating(rating);
        }
    }
    public static class RatingMiddlewareExtentions
    {
        public static IApplicationBuilder UseRatingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RatingMiddleware>();
        }
    }
}
