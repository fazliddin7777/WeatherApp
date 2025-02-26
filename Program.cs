using System.Text.Json;
using System.Text.Json.Serialization;

const string KEY = "3fe3618da3f5d90fb993d05aa32c0afc";

string city = Console.ReadLine();

using (HttpClient client = new())
{
    float formula = 273.15f;
    try
    {
        string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={KEY}";
        HttpResponseMessage responce = await client.GetAsync(url);

        if(responce.IsSuccessStatusCode)
        {
            string result = await responce.Content.ReadAsStringAsync();
            WeatherData weatherInfo = JsonSerializer.Deserialize<WeatherData>(result);
            Console.WriteLine($"Shahar nomi: {weatherInfo.Name}\nTemperature: {weatherInfo.Main.Temp -  formula}\nMa'lumot: {weatherInfo.Weather[0].Description}");

        }
        else
        {
            Console.WriteLine($"Error: {responce.StatusCode}");
        }
    }
    catch(Exception ex)
    {
        Console.WriteLine($"Exception: {ex.Message}");
    }
}

class WeatherData
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    [JsonPropertyName("main")]
    public MainDate? Main { get; set; }
    [JsonPropertyName("weather")]
    public WeatherInfo[]? Weather { get; set; }
}

class MainDate
{
    [JsonPropertyName("temp")]
    public double Temp { get; set; }
}

class WeatherInfo
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }
}