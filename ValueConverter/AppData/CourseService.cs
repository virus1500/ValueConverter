using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ValueConverter.AppData
{
    public class CourseService
    {
        private ComboBox _sellValuteComboBox;
        private ComboBox _buyValuteComboBox;
        private TextBox _sellValuteTB;
        private TextBox _buyValuteTB;
        private TextBlock _sellRatioTBl;
        private TextBlock _buyRatioTBl;
        private TextBlock _updateDataTBl;

        public CourseService(ComboBox sellValuteComboBox, ComboBox buyValuteComboBox, TextBox sellValuteTB, TextBox buyValuteTB, TextBlock sellRatioTBl, TextBlock buyRatioTBl, TextBlock updateDataTBl)
        {
            _sellValuteComboBox = sellValuteComboBox;
            _buyValuteComboBox = buyValuteComboBox;
            _sellValuteTB = sellValuteTB;
            _buyValuteTB = buyValuteTB;
            _sellRatioTBl = sellRatioTBl;
            _buyRatioTBl = buyRatioTBl;
            _updateDataTBl = updateDataTBl;
        }

        public string RequestUrl { get; private set; } = "https://www.cbr-xml-daily.ru/daily_json.js";
        public string LocalResquestUrl { get; private set; } = "\\\\fs\\Profiles$\\Students\\кИС-33\\Гоголев.Валерий\\Desktop\\courseJS\\course.json";
        public Valute SellValute { get; private set; }
        public Valute BuyValute { get; private set; }
        public double SellAmount { get; private set; }
        public double BuyAmount { get; private set; }
        public double SellRatio { get; private set; }
        public double BuyRatio { get; private set; }
        public DateTime UpdateDate { get; private set; }
        public List<Valute> Valutes { get; private set; }
        public Course Course { get; private set; }
        //
        public async Task LoadCourse()
        {
            try
            {
                // Создаём http клиент для отправдения запроса на веб-сервер
                HttpClient httpClient = new HttpClient();
                // Создаём переменную для хранения ответа
                var response = await httpClient.GetStringAsync(RequestUrl);
                // Проводим десереализацию ответа (из строки делать объект)
                // Устанавливаем пакет Newtonsoft.Json
                // Проверяем переменную response на наличие значения
                // Вызываем метод DeseriallizeObject() с указанием типа данных объекта
                if (!string.IsNullOrEmpty(response))
                {
                    // Получаем курс валют
                    Course = JsonConvert.DeserializeObject<Course>(response);
                    // Получаем список валют из курса
                    Valutes = Course.Valute.Values.ToList();
                    // Добавляем новую валюту
                    Valute rouble = new Valute
                    {
                        ID = "R000001",
                        NunCode = "643",
                        CharCode = "RUB",
                        Nominal = 1,
                        Name = "Российский рубль",
                        Value = 1,
                        Previous = 1
                    };
                    // Вставляем новую вулюту
                    Valutes.Insert(0, rouble);
                    // Загружаем списки валют в выпадающие списки
                    _sellValuteComboBox.ItemsSource = Valutes;
                    _buyValuteComboBox.ItemsSource = Valutes;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        public void Convert()
        {
            if (_sellValuteComboBox.SelectedItem != null && _buyValuteComboBox.SelectedItem != null)
            {

            }
        }
    }
}
