using Newtonsoft.Json.Linq;
using WebRoutes.Models;

namespace WebRoutes.Services.Routes.Implementation;

public class RouteBuilder : IRouteBuilder
{
    private readonly HttpClient _client = new();
    
    public async Task<(List<Coordinate> coordinates, float distance, float time)> BuildAsync(List<Place> places)
    {
        const string apiKey = "4694ebc07b654d96b095f84d490b17ef";
        const string mode = "walk";
        var points = places.Select(p => p.Point).ToList();
        var json = await CalculateRouteAsync(points, apiKey, mode);

        if (json == null)
        {
            System.Diagnostics.Debug.WriteLine("Geoapify API response is null");
            return ([], 0, 0);
        }

        try
        {
            var firstResult = json["results"]?[0];
            if (firstResult == null)
            {
                System.Diagnostics.Debug.WriteLine("No results in API response");
                return ([], 0, 0);
            }

            var distance = (float)firstResult["distance"];
            var time = (float)firstResult["time"];

            var geometry = firstResult["geometry"]?[0];
            if (geometry == null)
            {
                System.Diagnostics.Debug.WriteLine("No geometry in API response");
                return ([], distance, time);
            }

            var routePoints = new List<Coordinate>();
            foreach (var point in geometry)
            {
                try
                {
                    var lon = (float)point["lon"];
                    var lat = (float)point["lat"];
                    routePoints.Add(new Coordinate(lat, lon));
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error parsing point: {ex.Message}");
                }
            }

            return (routePoints, distance, time);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error processing API response: {ex.Message}");
            return ([], 0, 0);
        }
    }
    
    private async Task<JObject> CalculateRouteAsync(List<Point> points, string apiKey, string mode)
    {
        var waypoints = string.Join("|", points.Select(p => $"{p.Coordinate.Latitude},{p.Coordinate.Longitude}"));
        var url = $"https://api.geoapify.com/v1/routing?waypoints={waypoints}&mode={mode}&format=json&apiKey={apiKey}";
        var response = await _client.GetAsync(url);
        var jsonResponse = await response.Content.ReadAsStringAsync();
        
        return JObject.Parse(jsonResponse);
    }
}