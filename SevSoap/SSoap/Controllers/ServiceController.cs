using SSoap.DataS;
using SSoap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace SSoap.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Service
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public string OrdenCompra(string OC)
        { 
            try
            {
                if (OC != "")
                {
                    Datos _Datos = new Datos();
                    string url = System.Configuration.ConfigurationManager.AppSettings["Orden"];
                    string urlServicio = url + "('" + OC + "')";
                    string json = _Datos.ConsumingService(urlServicio);
                    return json;
                }
                else
                {
                    resultDto objResult = new resultDto(true, "No tiene orden compra", "");
                    string obj = new JavaScriptSerializer().Serialize(objResult);
                    return obj;
                }
            }
            catch (Exception ex)
            {
                resultDto objResult = new resultDto(true, ex.Message, "");
                string obj = new JavaScriptSerializer().Serialize(objResult);
                return obj;
            }
        }

        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public string Proveedores(string nit)
        {

            try
            {
                if (nit != "")
                {
                    Datos _Datos = new Datos();
                    string url = System.Configuration.ConfigurationManager.AppSettings["Proveedor"];
                    string urlServicio = url + "'" + nit + "'";
                    string json = _Datos.ConsumingService(urlServicio);
                    return json;
                }
                else
                {
                    resultDto objResult = new resultDto(true, "No tiene NIT del cliente", "");
                    string obj = new JavaScriptSerializer().Serialize(objResult);
                    return obj;
                }
            }
            catch (Exception ex)
            {
                resultDto objResult = new resultDto(true, ex.Message, "");
                string obj = new JavaScriptSerializer().Serialize(objResult);
                return obj;
            }
        }

        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public string Facturas(string Factura,string codFact) {
            Facturas obj = new Facturas();
            FacturaDto objFact = new FacturaDto();
            objFact = obj.getListSharepoint(Factura, codFact );//"3000001247"
            var xml = Utilidades.XML.GetXMLFromObject(objFact);

            return xml;

        }
    }
}
