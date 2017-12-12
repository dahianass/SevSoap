using Microsoft.SharePoint.Client;
using SSoap.Models;
using SSoap.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSoap.DataS
{
    public class Facturas
    {
        Conexion _Conexion = new Conexion();
        ClientContext _Context;
        public FacturaDto getListSharepoint(string factura,string CodigoProveedor)
        {
            try
            {
                FacturaDto objFactura = new FacturaDto();
                _Context = _Conexion.ConetionSharepoint();
                if (_Context != null)
                {

                    CamlQuery QueryReferencia = new CamlQuery();

                    var obj = _Context.Web.Lists.GetByTitle("InformacionFacturas");

                    CamlQuery query = new CamlQuery();
                    query.ViewXml = "<View><Query><Where><And><Eq><FieldRef Name='Factura'/>" +
                    "<Value Type='text'>" + factura + "</Value></Eq>"+
                    "<Eq><FieldRef Name='CodigoProveedor'/>" +
                    "<Value Type='text'>" + CodigoProveedor + "</Value></Eq>"+
                    "</And></Where></Query><RowLimit>100</RowLimit></View>";
                    ListItemCollection itemFactura = obj.GetItems(query);
                    _Context.Load(itemFactura);
                    _Context.ExecuteQuery();
                    if (itemFactura.Count > 0)
                    {
                        for (int i = 0; i < itemFactura.Count; i++)
                        {
                            var item = itemFactura[i];
                            objFactura.Factura = (string)item["Factura"];
                            //objFactura.Proveedor = (string)item["Proveedor"];
                            objFactura.Codproveedor = (string)item["CodigoProveedor"];
                            //objFactura.ResponsableSAP = (string)item["ResponsableSAP"];
                            //objFactura.Fecharadicado = (DateTime)item["FechaRadicado"];
                            //FieldLookupValue ResponsableFactura = item["ResponsableFactura"] as FieldLookupValue;
                            //objFactura.Responsablefactura = ResponsableFactura.LookupValue;
                            //objFactura.Valor = Convert.ToString((Double)item["Valor"]);
                            //objFactura.Moneda = (string)item["Moneda"];
                            //objFactura.Numeropreliminar = (string)item["NumeroPreliminar"];
                            //objFactura.Numerocontabilizado = (string)item["NumeroContabilizado"];
                            //FieldLookupValue ResponsableEstado = item["ResponsableEstado"] as FieldLookupValue;
                            //objFactura.Responsableestado = ResponsableEstado.LookupValue;
                            //objFactura.Estado = item.FieldValues["Estado"].ToString();
                            //objFactura.Limitegestion = (DateTime)item["Limite_x0020_gestion"];
                            //objFactura.CodigoRadicado = (string)item["C_x00f3_digo_x0020_radicado"];
                            //objFactura.Añoradicado = Convert.ToString((Double)item["A_x00f1_o_x0020_del_x0020_radica"]);
                            //objFactura.Nitproveedor = (string)item["Nit_x0020_proveedor"];
                            //objFactura.Motivodevolución = (string)item["Motivo_x0020_devoluci_x00f3_n"];
                            //objFactura.Descripciondevolucion = (string)item["Descripcion_x0020_devolucion"];
                            //objFactura.Tipodocumento = (string)item["Tipo_x0020_documento"];
                            //objFactura.Iddocumento = (string)item["IdDocumento"];
                            //objFactura.Fechafactura = (DateTime)item["FechaFactura"];
                            objFactura.Linkdocumento = (string)item["LinkDocumento"];
                            //objFactura.Idfactura = (Double)item["IdFactura"];
                            //objFactura.Estadointernofactura = (string)item["EstadoInternoFactura"];
                            //objFactura.Responsabletramite = (string)item["ResponsableTramite"];
                            //objFactura.Etapatramite = (string)item["EtapaTramite"];
                            //objFactura.Cajatramite = (string)item["CajaTramite"];
                            //objFactura.Serietramite = (string)item["SerieTramite"];
                            //objFactura.Archivotramite = (string)item["ArchivoTramite"];
                            //objFactura.Ubicaciontramite = (string)item["UbicacionTramite"];
                            //objFactura.Notificacionjefe = (Boolean)item["NotificacionJefe"];
                            //objFactura.Notificacionresponsable = (Boolean)item["NotificacionResponsable"];
                            //objFactura.Codigodevolución = (string)item["CodigoDevolucion"];
                            //objFactura.Responsablecomprasnoindustriales = (string)item["ResponsableCompras"];
                            //objFactura.Codigodevolución = (string)item["CodigoDevolucion"];
                            //objFactura.Solicitantecompra = (string)item["SolicitanteCompras"];
                            //objFactura.Novidad = (Boolean)item["Novidad"];
                            //objFactura.Causantedevolucion = (string)item["CausanteDevolucion"];
                            //objFactura.Usuariocontabilidad = (string)item["UsuarioContabilidad"];
                        }
                    }
                }
                return objFactura;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}