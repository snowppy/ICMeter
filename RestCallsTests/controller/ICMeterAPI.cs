using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestCallsTests.controller
{
    /// <summary>
    ///API Doc Changelog 2014-10-21
    /// </summary>
   public class ICMeterAPI
    {
       const string BaseUrl = "https://app.ic-meter.com/icm/";
       readonly string _user = "demo@ic-meter.com";
       readonly string _password = "demo";
       readonly string _qr = "efde07df";
       readonly string _meterId = "10007";

       private Token _token;

       public Token Token
       {
           get { if (_token == null) GetToken(); return _token; }
           set { _token = value; }
       }

       private void GetToken()
       {
           var client = new RestClient(BaseUrl);

           var request = new RestRequest("oauth/token", Method.GET);
           request.AddParameter("client_id", "trusted-client");
           request.AddParameter("grant_type","password");
           request.AddParameter("scope","trust");
           request.AddParameter("username", _user);
           request.AddParameter("password", _password);
           RestResponse<Token> response = client.Execute<Token>(request) as RestResponse<Token>;
           _token = response.Data; 


           // token refresher
          var aTimer = new System.Timers.Timer(int.Parse(_token.expires_in) *1000);
          aTimer.Elapsed += (x,e) => { _token = null; };
          aTimer.Enabled = true;
       }


       /// <summary>
       ///Following request returns indoor data of 5 minutes measurements within specified 
       ///timestamp range, limited to maximum 31 days. If range is above 31 days, the returned data is 
       /// truncated.
       /// </summary>
       /// <param name="t">Token</param>
       /// <param name="device">Device QR code</param>
       /// <param name="from">Datetime form</param>
       /// <param name="to">Datetime to</param>
       /// <returns></returns>
       public ResponseTable GetIndoorData(Token t, string device, DateTime from, DateTime to)
       {
           string fromdate = from.ToString("yyyy-MM-ddTHH:mm:ssZ");
           string todate = to.ToString("yyyy-MM-ddTHH:mm:ssZ");


           var client = new RestClient(BaseUrl);

           var request = new RestRequest("api/measurements/1.1/days/range/"+device, Method.GET);
           request.AddParameter("fromDate", fromdate);
           request.AddParameter("toDate", todate);
           request.AddParameter("access_token", t.access_token);
           RestResponse<ResponseTable> response = client.Execute<ResponseTable>(request) as RestResponse<ResponseTable>;
           return response.Data;
       }

       /// <summary>
       /// TEST Method uses hardcoded Device QR 
       ///Following request returns indoor data of 5 minutes measurements within specified 
       ///timestamp range, limited to maximum 31 days. If range is above 31 days, the returned data is 
       /// truncated.
       /// </summary>
       /// <param name="from">Datetime form</param>
       /// <param name="to">Datetime to</param>
       /// <returns></returns>
       public ResponseTable GetIndoorData(DateTime from , DateTime to)
       {
           return GetIndoorData(Token, _qr, from, to);
       }

       /// <summary>
       /// Following request returns weather data of measurements within specified timestamp range, 
       /// limited to maximum 31 days. If range is above 31 days, the returned data is truncated.
       /// </summary>
       /// <param name="t">Token</param>
       /// <param name="device">Device QR code</param>
       /// <param name="from">Datetime form</param>
       /// <param name="to">Datetime to</param>
       /// <returns></returns>
       public ResponseTable GetWeatherData(Token t, string device, DateTime from, DateTime to)
       {
           string fromdate = from.ToString("yyyy-MM-ddTHH:mm:ssZ");
           string todate = to.ToString("yyyy-MM-ddTHH:mm:ssZ");
           var client = new RestClient(BaseUrl);

           var request = new RestRequest("api/weather/1.1/days/range/" + device, Method.GET);
           request.AddParameter("fromDate", fromdate);
           request.AddParameter("toDate", todate);
           request.AddParameter("access_token", t.access_token);
           RestResponse<ResponseTable> response = client.Execute<ResponseTable>(request) as RestResponse<ResponseTable>;
           return response.Data;
       }

       /// <summary>
       /// TEST Method uses hardcoded Device QR 
       /// Following request returns weather data of measurements within specified timestamp range, 
       /// limited to maximum 31 days. If range is above 31 days, the returned data is truncated.
       /// </summary>
       /// <param name="from">Datetime form</param>
       /// <param name="to">Datetime to</param>
       /// <returns></returns>
       public ResponseTable GetWeatherData( DateTime from, DateTime to)
       {
           return GetWeatherData(Token, _qr, from, to);
       }

       /// <summary>
       /// list visible external meters groups
       /// </summary>
       /// <returns></returns>
       public List<MeterGroup> GetExternalDataMeters()
       {
           return GetExternalDataMeters(Token);
       }
       /// <summary>
       /// list visible external meters groups
       /// </summary>
       /// <param name="t">Token</param>
       /// <returns></returns>
       public List<MeterGroup> GetExternalDataMeters(Token t)
       {
           var client = new RestClient(BaseUrl);

           var request = new RestRequest("api/externaldata/1.0/meters", Method.GET);
           request.AddParameter("access_token", t.access_token);
           RestResponse<List<MeterGroup>> response = client.Execute<List<MeterGroup>>(request) as RestResponse<List<MeterGroup>>;
           return response.Data;
       }

       /// <summary>
       /// External data measurements – data range of hourly measurements, for maximum 31 days
       /// </summary>
       /// <param name="t">Token</param>
       /// <param name="device">Device ID</param>
       /// <param name="from">Datetime form</param>
       /// <param name="to">Datetime to</param>
       /// <returns></returns>
       public ResponseTable GetExternalData(Token t, string device, DateTime from, DateTime to)
       {
           string fromdate = from.ToString("yyyy-MM-ddTHH:mm:ssZ");
           string todate = to.ToString("yyyy-MM-ddTHH:mm:ssZ");
           var client = new RestClient(BaseUrl);

           var request = new RestRequest("api/externaldata/1.0/measurements/range/" + device, Method.GET);
           request.AddParameter("fromDate", fromdate);
           request.AddParameter("toDate", todate);
           request.AddParameter("access_token", t.access_token);
           RestResponse<ResponseTable> response = client.Execute<ResponseTable>(request) as RestResponse<ResponseTable>;
           return response.Data;
       }

       /// <summary>
       /// TEST Method uses hardcoded Device ID 
       /// External data measurements – data range of hourly measurements, for maximum 31 days
       /// </summary>
       /// <param name="from">Datetime form</param>
       /// <param name="to">Datetime to</param>
       /// <returns></returns>
       public ResponseTable GetExternalData(DateTime from, DateTime to)
       {
           return GetExternalData(Token, _meterId, from, to);
       }

    }


   
}
