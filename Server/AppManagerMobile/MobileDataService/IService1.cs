using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.IO;

namespace MobileDataService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IDiscoveryTree
    {

        [OperationContract]
        [WebGet(UriTemplate = "/Views", ResponseFormat = WebMessageFormat.Json)]
        List<IdNamePair> GetViewList();

        [OperationContract]
        [WebGet(UriTemplate = "/Views/{viewId}", ResponseFormat = WebMessageFormat.Json)]
        List<IdNamePair> GetDeviceList(string viewId);

        [OperationContract]
        [WebGet(UriTemplate = "/Views/{viewID}/{deviceId}", ResponseFormat = WebMessageFormat.Json)]
        List<Device> GetDeviceData(string viewId, string deviceId);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Device
    {
        [DataMember]
        public string name;
        [DataMember]
        public int icon;
        [DataMember]
        public List<Device> children;
    }

    [DataContract]
    public class IdNamePair
    {
        [DataMember]
        public int ID;
        [DataMember]
        public string name;
    }

}
