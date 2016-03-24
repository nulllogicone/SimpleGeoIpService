using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using MaxMind.Db;

namespace RoamlerGeoIpService.Controllers
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
            var dbPath = HostingEnvironment.MapPath("~/App_Data/GeoLite2-Country.mmdb");
            using (var reader = new Reader(dbPath))
            {
                dynamic data = reader.Find(ip);
                var countryCode = data.country.iso_code;
                return countryCode;
            }
        }

    }
}
