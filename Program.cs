using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;
using ServiceRest_097_Faysal_Fadel_Maulana;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;

namespace ServerCodeRest_097_Faysal_Fadel_Maulana
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost hostObj = null;
            Uri address = new Uri("http://localhost:1907/Mahasiswa");
            WebHttpBinding binding = new WebHttpBinding();

            try
            {
                hostObj = new ServiceHost(typeof(TI_UMY), address);
                hostObj.AddServiceEndpoint(typeof(ITI_UMY), binding, "");

                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                hostObj.Description.Behaviors.Add(smb);
                Binding mexbinding = MetadataExchangeBindings.CreateMexHttpBinding();
                hostObj.AddServiceEndpoint(typeof(IMetadataExchange), mexbinding, "mex");

                WebHttpBehavior whb = new WebHttpBehavior();
                whb.HelpEnabled = true;
                hostObj.Description.Endpoints[0].EndpointBehaviors.Add(whb);

                hostObj.Open();
                Console.WriteLine("Server Code is Ready .... ");
                Console.ReadLine();
                hostObj.Close();
            }
            catch(Exception e)
            {
                hostObj = null;
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
    }
}
