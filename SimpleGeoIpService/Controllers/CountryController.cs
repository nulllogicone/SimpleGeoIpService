using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using MaxMind.Db;

namespace SimpleGeoIpService.Controllers
{
    public class CountryController : ApiController
    {
        public string Get() => Get(HttpContext.Current.Request.UserHostAddress);

        // GET: api/Country/5
        public string Get(string ip)
        {
            var countryCode = SelectCountryCodeByIp(ip);
            return countryCode;
        }

        private static string SelectCountryCodeByIp(string ip)
        {
            if (ip == "::1" || ip == "127.0.0.1")
            {
                return "localhost";
            }
            
            var reader = GetReader();
            dynamic data = reader.Find(ip);
            var countryCode = data.country.iso_code;
            return countryCode;
        }

        private static Reader _reader;
        private static Reader GetReader()
        {
            if (_reader == null)
            {
                var dbPath = HostingEnvironment.MapPath("~/App_Data/GeoLite2-Country.mmdb");
                _reader = new Reader(dbPath);
            }
            return _reader;
        }

    }
}
