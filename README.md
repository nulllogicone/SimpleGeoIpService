# Simple GeoIP Service

The free webservice http://freegeoip.net/json/ to get a country name for an IP address went down.
So I needed a quick and easy work around to see where a request comes from.

This project was the fastest solution I could think of

- Create a new WebApi project
- Copy the free GeoLite2 database from http://dev.maxmind.com/geoip/geoip2/geolite2/
- Install a NuGet package to read from DB
- Configure Continuous Integration from Git to Azure
- done

<a href="https://azuredeploy.net/?repository=https://github.com/nulllogicone/SimpleGeoIpService" target="_blank">
    <img src="http://azuredeploy.net/deploybutton.png"/>
</a>
## Specification

```
 GET {yourdomain}/api/country/92.111.21.90
 ```

 returns just the ISO country code,  nothing else.
 There is also a swagger UI
 
## Update the database
 
 - Download DB, unzip file, copy to App_Data folder
 - Commit the change and push
 - done
 
### attribution requirement

This product includes GeoLite2 data created by MaxMind, available from
<a href="http://www.maxmind.com">http://www.maxmind.com</a>.

### Test live

http://simplegeoipservice.azurewebsites.net/swagger/ui/index

http://simplegeoipservice.azurewebsites.net/api/country/1.2.3.4

