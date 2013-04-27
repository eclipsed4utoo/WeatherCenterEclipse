using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace WeatherCenterEclipse
{
    public class WeatherLocation
    {
        private string m_locationID = string.Empty;

        public string LocationID
        {
            get { return m_locationID; }
            set { m_locationID = value; }
        }
        private string m_locationName = string.Empty;

        public string LocationName
        {
            get { return m_locationName; }
            set { m_locationName = value; }
        }
        private string m_locationLocalTime = string.Empty;

        public string LocationLocalTime
        {
            get { return m_locationLocalTime; }
            set { m_locationLocalTime = value; }
        }
        private decimal m_locationLongitute = 0;

        public decimal LocationLongitute
        {
            get { return m_locationLongitute; }
            set { m_locationLongitute = value; }
        }
        private decimal m_locationLatitude = 0;

        public decimal LocationLatitude
        {
            get { return m_locationLatitude; }
            set { m_locationLatitude = value; }
        }
        private string m_locationSunrise = string.Empty;

        public string LocationSunrise
        {
            get { return m_locationSunrise; }
            set { m_locationSunrise = value; }
        }
        private string m_locationSunset = string.Empty;

        public string LocationSunset
        {
            get { return m_locationSunset; }
            set { m_locationSunset = value; }
        }
        private int m_locationTimeZoneOffset = 0;

        public int LocationTimeZoneOffset
        {
            get { return m_locationTimeZoneOffset; }
            set { m_locationTimeZoneOffset = value; }
        }

        public WeatherLocation(XElement e)
        {
            m_locationID = e.Attribute("id").Value;
            m_locationName = e.Element("dnam").Value;
            m_locationLocalTime = e.Element("tm").Value;

            decimal.TryParse(e.Element("lon").Value, out m_locationLongitute);
            decimal.TryParse(e.Element("lat").Value, out m_locationLatitude);

            m_locationSunrise = e.Element("sunr").Value;
            m_locationSunset = e.Element("suns").Value;

            int.TryParse(e.Element("zone").Value, out m_locationTimeZoneOffset);
        }
    }
}
