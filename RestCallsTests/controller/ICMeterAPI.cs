using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestCallsTests.controller
{
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
       /// <param name="to">DAtetime to</param>
       /// <returns></returns>
       public ResponceTable GetIndoorData(Token t, string device, DateTime from, DateTime to)
       {
           string fromdate = from.ToString("yyyy-MM-ddThh:mm:ssZ");
           string todate = to.ToString("yyyy-MM-ddThh:mm:ssZ");


           var client = new RestClient(BaseUrl);

           var request = new RestRequest("api/measurements/1.1/days/range/"+device, Method.GET);
           request.AddParameter("fromDate", fromdate);
           request.AddParameter("toDate", todate);
           request.AddParameter("access_token", t.access_token);
           RestResponse<ResponceTable> response = client.Execute<ResponceTable>(request) as RestResponse<ResponceTable>;
           return response.Data;
       }

       /// <summary>
       /// TEST Method uses hardcoded Device QR 
       ///Following request returns indoor data of 5 minutes measurements within specified 
       ///timestamp range, limited to maximum 31 days. If range is above 31 days, the returned data is 
       /// truncated.
       /// </summary>
       /// <param name="from"></param>
       /// <param name="to"></param>
       /// <returns></returns>
       public ResponceTable GetIndoorData(DateTime from , DateTime to)
       {
           return GetIndoorData(Token, _qr, from, to);
       }
    }


   
}
