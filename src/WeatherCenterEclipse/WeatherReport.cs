using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace WeatherCenterEclipse
{
    public class WeatherReport
    {
        #region Private Variables

        private WeatherLocation m_location;
        private WeatherCurrentConditions m_currentConditions;
        private WeatherForecast m_day1;
        private WeatherForecast m_day2;
        private WeatherForecast m_day3;
        private WeatherForecast m_day4;
        private WeatherForecast m_day5;
        private DateTime m_lastUpdateDate = DateTime.MinValue;

        #endregion

        #region Public Properties

        public DateTime LastUpdateDate
        {
            get { return m_lastUpdateDate; }
            set { m_lastUpdateDate = value; }
        }

        public WeatherLocation Location
        {
            get { return m_location; }
            set { m_location = value; }
        }
        
        public WeatherCurrentConditions CurrentConditions
        {
            get { return m_currentConditions; }
            set { m_currentConditions = value; }
        }
        
        public WeatherForecast Day1
        {
            get { return m_day1; }
            set { m_day1 = value; }
        }
        
        public WeatherForecast Day2
        {
            get { return m_day2; }
            set { m_day2 = value; }
        }
        
        public WeatherForecast Day3
        {
            get { return m_day3; }
            set { m_day3 = value; }
        }
        
        public WeatherForecast Day4
        {
            get { return m_day4; }
            set { m_day4 = value; }
        }

        public WeatherForecast Day5
        {
            get { return m_day5; }
            set { m_day5 = value; }
        }

        #endregion

        #region Public Methods

        public void GetWeather(string zipCode, string partnerID, string licenseKey)
        {
            WeatherReport wr = null;

            XDocument doc = XDocument.Load(string.Format("http://xoap.weather.com/weather/local/{0}?cc=*&dayf=5&link=xoap&prod=xoap&par={1}&key={2}", zipCode, partnerID, licenseKey));

            if (zipCode.Length == 5)
            {
                var query = from e in doc.Elements("weather")
                            select new WeatherReport
                            {
                                CurrentConditions = new WeatherCurrentConditions(e.Element("cc")),
                                Location = new WeatherLocation(e.Element("loc")),
                                Day1 = new WeatherForecast(e.Element("dayf").Descendants("day").First()),
                                Day2 = new WeatherForecast(e.Element("dayf").Descendants("day").Skip(1).First()),
                                Day3 = new WeatherForecast(e.Element("dayf").Descendants("day").Skip(2).First()),
                                Day4 = new WeatherForecast(e.Element("dayf").Descendants("day").Skip(3).First()),
                                Day5 = new WeatherForecast(e.Element("dayf").Descendants("day").Skip(4).First()),
                                LastUpdateDate = DateTime.Parse(e.Element("cc").Element("lsup").Value.Remove(e.Element("cc").Element("lsup").Value.Length - 3).Trim())
                            };

                m_currentConditions = query.First().CurrentConditions;
                m_location = query.First().Location;
                m_day1 = query.First().Day1;
                m_day2 = query.First().Day2;
                m_day3 = query.First().Day3;
                m_day4 = query.First().Day4;
                m_day5 = query.First().Day5;
                LastUpdateDate = query.First().LastUpdateDate;
            }
            else
            {
                var query = from e in doc.Elements("weather")
                            select new WeatherReport
                            {
                                CurrentConditions = new WeatherCurrentConditions(e.Element("cc")),
                                Location = new WeatherLocation(e.Element("loc")),
                                Day1 = new WeatherForecast(e.Element("dayf").Descendants("day").First()),
                                Day2 = new WeatherForecast(e.Element("dayf").Descendants("day").Skip(1).First()),
                                Day3 = new WeatherForecast(e.Element("dayf").Descendants("day").Skip(2).First()),
                                Day4 = new WeatherForecast(e.Element("dayf").Descendants("day").Skip(3).First()),
                                Day5 = new WeatherForecast(e.Element("dayf").Descendants("day").Skip(4).First()),
                                LastUpdateDate = DateTime.Parse(e.Element("cc").Element("lsup").Value.Remove(e.Element("cc").Element("lsup").Value.Length - 10).Trim())
                            };

                m_currentConditions = query.First().CurrentConditions;
                m_location = query.First().Location;
                m_day1 = query.First().Day1;
                m_day2 = query.First().Day2;
                m_day3 = query.First().Day3;
                m_day4 = query.First().Day4;
                m_day5 = query.First().Day5;
                LastUpdateDate = query.First().LastUpdateDate;
            }
        }

        #endregion
    }
}
