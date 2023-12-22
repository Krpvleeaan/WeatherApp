using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Laverna_Test_1
{
    public partial class Weather_Form : Form
    {
        public Weather_Form()
        {
            InitializeComponent();
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {

        }
        private async void button_RefreshWeather_Click(object sender, EventArgs e)
        {
            string cityName    = richTextBox_NameOfCity.Text; // Инициализируется строчка в которой лежит название города

            var filePath = "Weather_Info.json"; // считываю информацию об ApiUrl и ApiKey с JSON файла, https://openweathermap.org/

            var optionsFromJson = File.ReadAllText(filePath);

            var options = JsonConvert.DeserializeObject<WeatherServiceOptions>(optionsFromJson);

            options.ApiUrl = options.ApiUrl.Replace("apiKey", options.ApiKey);

            var weatherService = new WeatherService(options);

            var dto = await weatherService.GetWeatherByCityName(cityName); // Получаю информацию о погоде

            if (dto == null)
            {
                label_Temperature.Text = "Temperature: ";
                label_Description.Text = "Description: ";
                label_WindSpeed.Text = "Wind Speed: ";
                return;
            }
            label_Temperature.Text = "Temperature: " + dto.Temperature + "°C";
            label_Description.Text = "Description: " + dto.Description;
            label_WindSpeed.Text = "Wind Speed: " + dto.WindSpeed + "m/s";
        }
    }
}
