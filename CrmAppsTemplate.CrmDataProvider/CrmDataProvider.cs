using CrmAppsTemplate.CrmConnectionPrvdr;
using System;

namespace CrmAppsTemplate.CrmDataPrvdr
{
    public class CrmDataProvider
    {
        private readonly CrmConnectionProvider _crmConnectionProvider;

        public CrmDataProvider(CrmConnectionProvider crmConnectionProvider)
        {
            _crmConnectionProvider = crmConnectionProvider ?? throw new ArgumentNullException(nameof(crmConnectionProvider));
        }
    }
}