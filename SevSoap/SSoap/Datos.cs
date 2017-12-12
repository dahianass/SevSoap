using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Linq;

namespace SSoap
{
    public class Datos
    {
        public string ConsumingService(string urlServicio)
        {
            try
            {
                WebRequest req = (WebRequest)WebRequest.Create(urlServicio);
                var UserName = ConfigurationManager.AppSettings["UserName"];
                var PassWord = ConfigurationManager.AppSettings["PassWord"];

                req.Credentials = new NetworkCredential(UserName, PassWord);
  
                req.Headers["X-FORMS_BASED_AUTH_ACCEPTED"] = "f";
                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                string Json = readStream.ReadToEnd();

                response.Close();
                readStream.Close();

                var json = new JavaScriptSerializer().Serialize(GetXmlData(XElement.Parse(Json)));

                resultDto objResult = new resultDto(false,"", json);
                string obj = new JavaScriptSerializer().Serialize(objResult);
                return obj;
            }
            catch (Exception ex)
            {
                resultDto objResult = new resultDto(true, ex.Message, "");
                string obj = new JavaScriptSerializer().Serialize(objResult);
                return obj;
            }
        }
        private static Dictionary<string, object> GetXmlData(XElement xml)
        {
            var attr = xml.Attributes().ToDictionary(d => d.Name.LocalName, d => (object)d.Value);
            if (xml.HasElements) attr.Add("_value", xml.Elements().Select(e => GetXmlData(e)));
            else if (!xml.IsEmpty) attr.Add("_value", xml.Value);

            return new Dictionary<string, object> { { xml.Name.LocalName, attr } };
        }

        public string consumingSharepoint() {
            return "";
        }
    }
}