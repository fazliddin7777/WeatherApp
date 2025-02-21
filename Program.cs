const string KEY = "3fe3618da3f5d90fb993d05aa32c0afc";

using (HttpClient client = new())
{
    try
    {
        string url = $"https://api.openweathermap.org/data/2.5/weather?q=London&appid={KEY}";
        HttpResponseMessage responce = await client.GetAsync(url);

        if(responce.IsSuccessStatusCode)
        {
            string result = await responce.Content.ReadAsStringAsync();
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