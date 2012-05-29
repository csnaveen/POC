using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.ServiceModel.Activation;

namespace MobileDataService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]

    public class DiscoveryService : IDiscoveryTree
    {
        public List<IdNamePair> GetViewList()
        {
            return QDBData.Instance().GetViewList();
        }

        public List<IdNamePair> GetDeviceList(string viewId)
        {
            return QDBData.Instance().GetDeviceList(Convert.ToInt32(viewId));
        }

        public List<Device> GetDeviceData(string viewId, string deviceId)
        {
            return QDBData.Instance().GetDeviceData(Convert.ToInt32(viewId), Convert.ToInt32(deviceId));
        }
    }
}
