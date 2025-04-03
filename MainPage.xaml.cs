using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices.Sensors; 

namespace MauiUnitConverter
{
    public partial class MainPage : ContentPage
    {
       
        private readonly string[] _conversionOptions = new[]
        {
        "Celsius to Fahrenheit",
        "Fahrenheit to Celsius",
        "Kilometers to Miles",
        "Miles to Kilometers"
    };

        public MainPage()
        {
            InitializeComponent();
            ConversionPicker.ItemsSource = _conversionOptions;
            ConversionPicker.SelectedIndex = 0; 
        }

        private void OnConvertClicked(object sender, EventArgs e)
        {
            if (ConversionPicker.SelectedIndex == -1)
            {
                ResultLabel.Text = "Please select a conversion type.";
                return;
            }

            if (!double.TryParse(InputEntry.Text, out double inputValue))
            {
                ResultLabel.Text = "Please enter a valid number.";
                return;
            }

            string selected = _conversionOptions[ConversionPicker.SelectedIndex];
            double result = 0;
            string unitLabel = "";

            switch (selected)
            {
                case "Celsius to Fahrenheit":
                    result = UnitConverters.CelsiusToFahrenheit(inputValue); 
                    unitLabel = "°F";
                    break;

                case "Fahrenheit to Celsius":
                    result = UnitConverters.FahrenheitToCelsius(inputValue);
                    unitLabel = "°C";
                    break;

                case "Kilometers to Miles":
                    result = UnitConverters.KilometersToMiles(inputValue);
                    unitLabel = "mi";
                    break;

                case "Miles to Kilometers":
                    result = UnitConverters.MilesToKilometers(inputValue);
                    unitLabel = "km";
                    break;
            }

            ResultLabel.Text = $"{inputValue} → {result:F2} {unitLabel}";
        }
    }

}

//Statisk klasse under Microsoft.Maui.Devices.Sensors
//Predifinerede udregninger som kun understøtter temperatur og afstande
//Egentligt bare klasser med metematiske udregninger som kan kaldes og er indbygget i MAUI
//Metoder kaldes direkte