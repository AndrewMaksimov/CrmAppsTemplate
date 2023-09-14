using Microsoft.Extensions.Options;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using System.Net;
using CrmAppsTemplate.Options;
using System.ServiceModel.Description;
using System;

namespace CrmAppsTemplate.CrmConnectionPrvdr
{
    public class CrmConnectionProvider
    {
        private IOrganizationService _organizationService;

        public IOrganizationService OrganizationService => _organizationService;

        public CrmConnectionProvider(IOptions<CrmConnectionOptions> options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));
            try
            {
                _organizationService = CreateOrganizationService(options.Value);
            }
            catch(Exception ex)
            {

            }
        }

        private IOrganizationService CreateOrganizationService(CrmConnectionOptions connectionOptions)
        {
            var cc = new ClientCredentials();
            cc.UserName.UserName = connectionOptions.Login;
            cc.UserName.Password = connectionOptions.Password;

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            return new OrganizationServiceProxy(new Uri(connectionOptions.CrmUri), null, cc, null);
        }
    }
}