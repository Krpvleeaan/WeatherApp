using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Windows.Forms;

namespace Laverna_Test_1
{
    public partial class Main_Form : Form
    {
        public string apiUrl; // string containing the reference for the query
        public string city; // string that contains the name of the city
        public string apiKey; // string that contains key for the api
        public Main_Form()
        {
            apiKey = "6983a538c04afaf357bdd92a3c04f986"; // initialize the line with the api key, which was obtained from the site https://openweathermap.org/
            InitializeComponent();
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {

        }
        private async void button_RefreshWeather_Click(object sender, EventArgs e)
        {
            city = richTextBox_NameOfCity.Text;
            apiUrl = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}";
            int temperature;


            // Проверка успешности запроса
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    MessageBox.Show(response.IsSuccessStatusCode.ToString());
                    if (response.IsSuccessStatusCode)
                    {
                        // Чтение ответа в виде строки
                        string jsonResult = await response.Content.ReadAsStringAsync();

                        // Обработка jsonResult и вывод необходимых данных (температура, описание, скорость ветра)

                        JObject weatherData = JObject.Parse(jsonResult);
                        temperature = (int)weatherData["main"]["temp"] - 273;

                        label_Temperature.Text = $"Temperature: {temperature}°C";
                        label_Description.Text = $"Description: {weatherData["weather"][0]["description"]}";
                        label_WindSpeed.Text = $"Wind Speed: {weatherData["wind"]["speed"]} м/с";
                    }
                    else
                    {
                        MessageBox.Show($"Ошибка: This city was {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
        }
    }
}
