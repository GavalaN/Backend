using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace TestLogin_Host
{
    public class MyServiceAuthorizationManager: ServiceAuthorizationManager
    {
        protected override bool CheckAccessCore(OperationContext operationContext)
        {
            HttpResponseMessageProperty property = new HttpResponseMessageProperty();
            property.Headers.Add("Access-Control-Allow-Origin", "*");
            operationContext.OutgoingMessageProperties.Add(HttpResponseMessageProperty.Name, property);

            return true;
        }
    }
}
