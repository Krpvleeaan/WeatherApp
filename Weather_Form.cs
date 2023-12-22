using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laverna_Test_1
{
    public partial class Weather_Form : Form
    {
        /*private string apiUrl;   // string containing the reference for the query*/
        private string   cityName;     // string that contains the name of the city
        /*private string   apiKey;   // string that contains key for the api
        public string[] weatherForecast;   // string that contains the result of request*/

        public Weather_Form()
        {
            /*weatherForecast = new string[3];
            apiKey = "6983a538c04afaf357bdd92a3c04f986";*/ // initialize the line with the api key, which was obtained from the site https://openweathermap.org/
            InitializeComponent();
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {

        }
        private async void button_RefreshWeather_Click(object sender, EventArgs e)
        {
            cityName    = richTextBox_NameOfCity.Text;

            var filePath = "Weather_Info.json";

            var optionsFromJson = File.ReadAllText(filePath);

            var options = JsonConvert.DeserializeObject<WeatherServiceOptions>(optionsFromJson);
            var weatherService = new WeatherService(options);

            var dto = await weatherService.GetWeatherByCityName(cityName);

            label_Temperature.Text = "Температура: " + dto.Temperature + "°C";
            label_Description.Text = "Описание: " + dto.Description;
            label_WindSpeed.Text = "Скорость ветра: " + dto.WindSpeed + "м/с";
        }
    }
}

class WeatherServiceOptions
{
    public string ApiUrl { get; set; }
    public string ApiKey { get; set; }
}

class WeatherDto
{
    public string Temperature { get; set; }
    public string Description { get; set; }
    public string WindSpeed { get; set; }
}

class MyCache<TKey, TValue>
    where TKey : class
    where TValue : class
{
    class Entry
    {
        public TValue Value { get; set; }
        public DateTime CreationTime { get; set; }
    }

    private Dictionary<TKey, Entry> _cacheDictionary;
    private TimeSpan _lifeTime;
    public MyCache(TimeSpan lifeTime)
    {
        _cacheDictionary = new Dictionary<TKey, Entry>();
        _lifeTime = lifeTime;
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        if(!_cacheDictionary.TryGetValue(key, out var entry))
        {
            value = null;
            return false;
        }
        var currentTime = DateTime.UtcNow;
        var passedTime = entry.CreationTime - currentTime;  

        if(passedTime > _lifeTime)
        {
            _cacheDictionary.Remove(key);
            value = null;

            return false;
        }

        value = entry.Value;
        return true;
    }

    public void AddValue(TKey key, TValue value)
    {
        if (_cacheDictionary.ContainsKey(key))
        {
            _cacheDictionary.Remove(key);
            
            var newEntry = new Entry { Value = value, CreationTime = DateTime.UtcNow };
            _cacheDictionary.Add(key, newEntry);
        }
    }
}
class WeatherService
{
    private readonly string _apiUrl;
    private readonly string _apiKey;
    private readonly MyCache<string, WeatherDto> _cache;
    public WeatherService(WeatherServiceOptions options)
    {
        _apiUrl = options.ApiUrl;
        _apiKey = options.ApiKey;
        _cache = new MyCache<string, WeatherDto>(TimeSpan.FromMinutes(10));
    }

    public async Task<WeatherDto> GetWeatherByCityName(string cityName)
    {
        if(_cache.TryGetValue(cityName, out WeatherDto existedDto))
        {
            return existedDto;
        }
        var weatherData = await WeatherRequestAsync(cityName);
        // Запрос к api
        // Формирование DataTransferObject
        var dto = new WeatherDto()
        {
            Temperature = ((int)weatherData["main"]["temp"] - 273).ToString(),
            Description = weatherData["weather"][0]["description"].ToString(),
            WindSpeed = weatherData["wind"]["speed"].ToString()
        };
        _cache.AddValue(cityName, dto);
        return dto;
    }
    async Task<JObject> WeatherRequestAsync(string cityName)
    {
        var weatherData = new JObject();
        using (HttpClient client = new HttpClient())
        {
            try
            {
                var response = await client.GetAsync($"http://api.openweathermap.org/data/2.5/weather?q={cityName}&appid=6983a538c04afaf357bdd92a3c04f986");
                if (response.IsSuccessStatusCode)
                {
                    string jsonResult = await response.Content.ReadAsStringAsync();
                    weatherData = JObject.Parse(jsonResult);
                }
                else
                {
                    MessageBox.Show($"Error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        return weatherData;
    }
}
