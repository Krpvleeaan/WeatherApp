using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laverna_Test_1
{
    class WeatherService //Отдельный сервис для получения информации о погоде
    {
        private readonly string _apiUrl;
        private readonly string _apiKey;
        private readonly MyCache<string, WeatherDto> _cache;
        public WeatherService(WeatherServiceOptions options)
        {
            _apiUrl = options.ApiUrl;
            _apiKey = options.ApiKey;
            _cache = new MyCache<string, WeatherDto>(TimeSpan.FromMinutes(10)); // Кэш будет хранить данные в течение 10 минут
        }

        public async Task<WeatherDto> GetWeatherByCityName(string cityName)
        {
            if (_cache.TryGetValue(cityName, out WeatherDto existedDto)) // Если в кэше есть запись по данному городу, возвращаем эту запись
            {
                return existedDto;
            }

            // Запрос к api
            var weatherData = await WeatherRequestAsync(cityName);

            if (weatherData == null)
                return null;
            // Формирование DataTransferObject
            var dto = new WeatherDto()
            {
                Temperature = ((int)weatherData["main"]["temp"] - 273).ToString(),
                Description = weatherData["weather"][0]["description"].ToString(),
                WindSpeed = weatherData["wind"]["speed"].ToString()
            };
            
            // Добавляем запись в кэш
            _cache.AddValue(cityName, dto);
            return dto;
        }
        async Task<JObject> WeatherRequestAsync(string cityName) // Запрос к api
        {
            var weatherData = new JObject();
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string ApiUrl = _apiUrl.Replace("city", cityName);
                    var response = await client.GetAsync(ApiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResult = await response.Content.ReadAsStringAsync();
                        weatherData = JObject.Parse(jsonResult);
                    }
                    else
                    {
                        MessageBox.Show($"Error: {response.StatusCode}");
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    return null;
                }
            }
            return weatherData;
        }
    }
}
