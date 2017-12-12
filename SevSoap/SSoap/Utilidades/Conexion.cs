using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security;
using System.Web;

namespace SSoap.Utilidades
{
    public class Conexion
    {
        public ClientContext ConetionSharepoint()
        {

            //StreamWriter file = new StreamWriter(ConfigurationManager.AppSettings["Log"], append: true);
            try
            {
                string Usuario = ConfigurationManager.AppSettings["usuario"];
                string Clave = ConfigurationManager.AppSettings["password"];
                /*Variable de seguridad para poder loguiarse en el sharepoint*/
                SecureString SecurePassword = new SecureString();
                char[] VecClave = Clave.ToCharArray();
                /*recorro la clave y agrego la letra a la seguridad*/
                foreach (char letra in VecClave)
                {
                    SecurePassword.AppendChar(Convert.ToChar(letra));
                }
                /*me logue con share point*/
                SharePointOnlineCredentials cred = new SharePointOnlineCredentials(Usuario, SecurePassword);

                var URLSir = ConfigurationManager.AppSettings["url"];
                var urlClientContex = ConfigurationManager.AppSettings["context"];
                ClientContext context = new ClientContext(urlClientContex);
                context.Credentials = cred;

                return context;
            }
            catch (Exception ex)
            {
                //file.WriteLine("-------------Exepción Conexión");
                //file.WriteLine(ex.Message);
                return null;
            }
            //file.Close();
        }
    }
}