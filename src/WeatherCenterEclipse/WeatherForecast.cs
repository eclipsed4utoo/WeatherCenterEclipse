using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace WeatherCenterEclipse
{
    public class WeatherForecast
    {
        #region Private Variables

        private int m_dayNumber = -1;
        private string m_dayOfWeek = string.Empty;
        private string m_date = string.Empty;
        private int m_forecastLowTemperature = 0;
        private int m_forecastHighTemperature = 0;
        private string m_sunrise = string.Empty;
        private string m_sunset = string.Empty;
        private int m_dayWeatherIcon = 0;
        private string m_dayWeatherDescription = string.Empty;
        private string m_dayWeatherDescriptionShort = string.Empty;
        private int m_dayWindSpeed = 0;
        private int m_dayWindGust = 0;
        private int m_dayWindDirection = 0;
        private string m_dayWindDirectionPhrase = string.Empty;
        private int m_dayHumidity = 0;
        private int m_dayChanceOfPrecipitation = 0;
        private int m_nightWeatherIcon = 0;
        private string m_nightWeatherDescription = string.Empty;
        private string m_nightWeatherDescriptionShort = string.Empty;
        private int m_nightWindSpeed = 0;
        private int m_nightWindGust = 0;
        private int m_nightWindDirection = 0;
        private string m_nightWindDirectionPhrase = string.Empty;
        private int m_nightHumidity = 0;
        private int m_nightChanceOfPrecipitation = 0;

        #endregion

        #region Public Properties

        public int DayNumber
        {
            get { return m_dayNumber; }
            set { m_dayNumber = value; }
        }
        
        public string DayOfWeek
        {
            get { return m_dayOfWeek; }
            set { m_dayOfWeek = value; }
        }
        
        public string Date
        {
            get { return m_date; }
            set { m_date = value; }
        }
        
        public int ForecastLowTemperature
        {
            get { return m_forecastLowTemperature; }
            set { m_forecastLowTemperature = value; }
        }
        
        public int ForecastHighTemperature
        {
            get { return m_forecastHighTemperature; }
            set { m_forecastHighTemperature = value; }
        }
        
        public string Sunrise
        {
            get { return m_sunrise; }
            set { m_sunrise = value; }
        }
        
        public string Sunset
        {
            get { return m_sunset; }
            set { m_sunset = value; }
        }

        public int DayWeatherIcon
        {
            get { return m_dayWeatherIcon; }
            set { m_dayWeatherIcon = value; }
        }

        public string DayWeatherDescription
        {
            get { return m_dayWeatherDescription; }
            set { m_dayWeatherDescription = value; }
        }

        public string DayWeatherDescriptionShort
        {
            get { return m_dayWeatherDescriptionShort; }
            set { m_dayWeatherDescriptionShort = value; }
        }

        public int DayHumidity
        {
            get { return m_dayHumidity; }
            set { m_dayHumidity = value; }
        }

        public int DayChanceOfPrecipitation
        {
            get { return m_dayChanceOfPrecipitation; }
            set { m_dayChanceOfPrecipitation = value; }
        }

        public int DayWindSpeed
        {
            get { return m_dayWindSpeed; }
            set { m_dayWindSpeed = value; }
        }

        public int DayWindGust
        {
            get { return m_dayWindGust; }
            set { m_dayWindGust = value; }
        }

        public int DayWindDirection
        {
            get { return m_dayWindDirection; }
            set { m_dayWindDirection = value; }
        }

        public string DayWindDirectionPhrase
        {
            get { return m_dayWindDirectionPhrase; }
            set { m_dayWindDirectionPhrase = value; }
        }
        
        public int NightWeatherIcon
        {
            get { return m_nightWeatherIcon; }
            set { m_nightWeatherIcon = value; }
        }

        public string NightWeatherDescription
        {
            get { return m_nightWeatherDescription; }
            set { m_nightWeatherDescription = value; }
        }

        public string NightWeatherDescriptionShort
        {
            get { return m_nightWeatherDescriptionShort; }
            set { m_nightWeatherDescriptionShort = value; }
        }

        public int NightHumidity
        {
            get { return m_nightHumidity; }
            set { m_nightHumidity = value; }
        }

        public int NightChanceOfPrecipitation
        {
            get { return m_nightChanceOfPrecipitation; }
            set { m_nightChanceOfPrecipitation = value; }
        }

        public int NightWindSpeed
        {
            get { return m_nightWindSpeed; }
            set { m_nightWindSpeed = value; }
        }

        public int NightWindGust
        {
            get { return m_nightWindGust; }
            set { m_nightWindGust = value; }
        }

        public int NightWindDirection
        {
            get { return m_nightWindDirection; }
            set { m_nightWindDirection = value; }
        }

        public string NightWindDirectionPhrase
        {
            get { return m_nightWindDirectionPhrase; }
            set { m_nightWindDirectionPhrase = value; }
        }

        #endregion

        #region Constructor

        public WeatherForecast(XElement e)
        {
            int.TryParse(e.Attribute("d").Value, out m_dayNumber);

            m_dayOfWeek = e.Attribute("t").Value;
            m_date = e.Attribute("dt").Value;

            int.TryParse(e.Element("low").Value, out m_dayNumber);
            int.TryParse(e.Element("hi").Value, out m_dayNumber);

            m_sunrise = e.Element("sunr").Value;
            m_sunset = e.Element("suns").Value;

            XElement ele = e.Descendants("part").First();

            int.TryParse(ele.Element("icon").Value, out m_dayWeatherIcon);
            
            m_dayWeatherDescription = ele.Element("t").Value;
            m_dayWeatherDescriptionShort = ele.Element("bt").Value;

            int.TryParse(ele.Element("wind").Element("s").Value, out m_dayNumber);
            int.TryParse(ele.Element("wind").Element("gust").Value, out m_dayWindGust);

            int.TryParse(ele.Element("wind").Element("d").Value, out m_dayWindDirection);
            m_dayWindDirectionPhrase = ele.Element("wind").Element("t").Value;

            int.TryParse(ele.Element("hmid").Value, out m_dayHumidity);
            int.TryParse(ele.Element("ppcp").Value, out m_dayChanceOfPrecipitation);

            XElement ele2 = e.Descendants("part").Skip(1).First();

            int.TryParse(ele2.Element("icon").Value, out m_nightWeatherIcon);
            int.TryParse(ele2.Element("wind").Element("s").Value, out m_nightWindSpeed);

            m_nightWeatherDescription = ele2.Element("t").Value;
            m_nightWeatherDescriptionShort = ele2.Element("bt").Value;

            int.TryParse(ele2.Element("wind").Element("gust").Value, out m_nightWindGust);
            int.TryParse(ele2.Element("wind").Element("d").Value, out m_nightWindDirection);

            m_nightWindDirectionPhrase = ele2.Element("wind").Element("t").Value;

            int.TryParse(ele2.Element("hmid").Value, out m_nightHumidity);
            int.TryParse(ele2.Element("ppcp").Value, out m_nightChanceOfPrecipitation);
        }

        #endregion
    }
}
