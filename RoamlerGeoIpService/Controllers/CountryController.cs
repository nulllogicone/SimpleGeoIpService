using System.Web.Hosting;
using System.Web.Http;
using MaxMind.Db;

namespace SimpleGeoIpService.Controllers
{
    public class CountryController : ApiController
    {
        // GET: api/Country/5
        public string Get(string ip)
        {
            var countryCode = GetCountryCodeByIp(ip);
            return countryCode;
        }

        private string GetCountryCodeByIp(string ip)
        {
            var reader = GetReader();
            dynamic data = reader.Find(ip);
            var countryCode = data.country.iso_code;
            return countryCode;
        }

        static Reader reader;
        private static Reader GetReader()
        {
            if (reader == null)
            {
                var dbPath = HostingEnvironment.MapPath("~/App_Data/GeoLite2-Country.mmdb");
                reader = new Reader(dbPath);
            }
            return reader;
        }

    }
}
