using Newtonsoft.Json.Linq;
using WebRoutes.Models;

namespace WebRoutes.Services.Routes;

public interface IRouteBuilder
{
    Task<(List<Coordinate> coordinates, float distance, float time)> BuildAsync(List<Place> places, string mode);
}