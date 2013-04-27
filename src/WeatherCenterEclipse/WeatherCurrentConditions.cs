using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace WeatherCenterEclipse
{
    public class WeatherCurrentConditions
    {
        #region Private Variables

        private string m_observationStationName = string.Empty;
        private int m_temperature = 0;
        private int m_feelsLikeTemperature = 0;
        private string m_weatherDescription = string.Empty;
        private int m_weatherIconCode = 0;
        private decimal m_barometricPressure = 0;
        private string m_barometricTrend = string.Empty;
        private int m_windSpeed = 0;
        private int m_windGust = 0;
        private int m_windDirection = 0;
        private string m_windDirectionPhrase = string.Empty;
        private int m_humidity = 0;
        private decimal m_visibility = 0;
        private int m_uVIndex = 0;
        private string m_uVIndexDescription = string.Empty;
        private int m_dewPoint = 0;
        private int m_moonIconCode = 0;
        private string m_moonPhaseDescription = string.Empty;

        #endregion

        #region Public Properties

        public string ObservationStationName
        {
            get { return m_observationStationName; }
            set { m_observationStationName = value; }
        }
        
        public int Temperature
        {
            get { return m_temperature; }
            set { m_temperature = value; }
        }
        
        public int FeelsLikeTemperature
        {
            get { return m_feelsLikeTemperature; }
            set { m_feelsLikeTemperature = value; }
        }
        
        public string WeatherDescription
        {
            get { return m_weatherDescription; }
            set { m_weatherDescription = value; }
        }
        
        public int WeatherIconCode
        {
            get { return m_weatherIconCode; }
            set { m_weatherIconCode = value; }
        }
        
        public decimal BarometricPressure
        {
            get { return m_barometricPressure; }
            set { m_barometricPressure = value; }
        }
        
        public string BarometricTrend
        {
            get { return m_barometricTrend; }
            set { m_barometricTrend = value; }
        }
        
        public int WindSpeed
        {
            get { return m_windSpeed; }
            set { m_windSpeed = value; }
        }
        
        public int WindGust
        {
            get { return m_windGust; }
            set { m_windGust = value; }
        }
        
        public int WindDirection
        {
            get { return m_windDirection; }
            set { m_windDirection = value; }
        }
        
        public string WindDirectionPhrase
        {
            get { return m_windDirectionPhrase; }
            set { m_windDirectionPhrase = value; }
        }
        
        public int Humidity
        {
            get { return m_humidity; }
            set { m_humidity = value; }
        }
        
        public decimal Visibility
        {
            get { return m_visibility; }
            set { m_visibility = value; }
        }
        
        public int UVIndex
        {
            get { return m_uVIndex; }
            set { m_uVIndex = value; }
        }
        
        public string UVIndexDescription
        {
            get { return m_uVIndexDescription; }
            set { m_uVIndexDescription = value; }
        }
        
        public int DewPoint
        {
            get { return m_dewPoint; }
            set { m_dewPoint = value; }
        }
        
        public int MoonIconCode
        {
            get { return m_moonIconCode; }
            set { m_moonIconCode = value; }
        }

        public string MoonPhaseDescription
        {
            get { return m_moonPhaseDescription; }
            set { m_moonPhaseDescription = value; }
        }

        #endregion

        #region Constructor

        public WeatherCurrentConditions(XElement e)
        {
            m_observationStationName = e.Element("obst").Value;

            int.TryParse(e.Element("tmp").Value, out m_temperature);
            int.TryParse(e.Element("flik").Value, out m_feelsLikeTemperature);

            m_weatherDescription = e.Element("t").Value;

            int.TryParse(e.Element("icon").Value, out m_weatherIconCode);
            decimal.TryParse(e.Element("bar").Element("r").Value, out m_barometricPressure);

            m_barometricTrend = e.Element("bar").Element("d").Value;

            int.TryParse(e.Element("wind").Element("s").Value, out m_windSpeed);
            int.TryParse(e.Element("wind").Element("gust").Value, out m_windGust);
            int.TryParse(e.Element("wind").Element("d").Value, out m_windDirection);

            m_windDirectionPhrase = e.Element("wind").Element("t").Value;

            int.TryParse(e.Element("hmid").Value, out m_humidity);
            decimal.TryParse(e.Element("vis").Value, out m_visibility);
            int.TryParse(e.Element("uv").Element("i").Value, out m_uVIndex);

            m_uVIndexDescription = e.Element("uv").Element("t").Value;

            int.TryParse(e.Element("dewp").Value, out m_dewPoint);
            int.TryParse(e.Element("moon").Element("icon").Value, out m_moonIconCode);

            m_moonPhaseDescription = e.Element("moon").Element("t").Value;
        }

        #endregion
    }
}
