using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.EntityClient;
using System.Linq;

namespace MobileDataService
{
    public class ObjectData
    {
       public int ObjectID;
       public int ParentObjectID;
       public string Name;
    }

    public interface IQDBData
    {
        List<IdNamePair> GetViewList();
        List<IdNamePair> GetDeviceList(int viewId);
        List<Device> GetDeviceData(int viewId, int deviceId);
    }

    
    public class QDBData : IQDBData
    {
        QDBEntities context = null;

        private QDBData()
        {
            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();
            sqlBuilder.DataSource = @"BLR-L-CSNAVEEN\test";
            sqlBuilder.InitialCatalog = "QDB";
            sqlBuilder.UserID = "mobileadmin";
            sqlBuilder.Password = "netiq123";
            sqlBuilder.MultipleActiveResultSets = true;

            EntityConnectionStringBuilder connBuilder = new EntityConnectionStringBuilder();
            connBuilder.Provider = "System.Data.SqlClient";
            connBuilder.ProviderConnectionString = sqlBuilder.ToString();
            connBuilder.Metadata = @"res://*/QDBEntities.csdl|res://*/QDBEntities.ssdl|res://*/QDBEntities.msl";

            EntityConnection connection = new EntityConnection(connBuilder.ToString());
            context = new QDBEntities(connection);
        }

        private static QDBData instance = null;

        public static QDBData Instance()
        {
            if (instance == null)
            {
                instance = new QDBData();
            }
            return instance;		 
	    }

        #region IQDBData Members

        public List<IdNamePair> GetViewList()
        {
            return (from view in context.Views select new IdNamePair { ID = view.ViewID, name = view.Name }).ToList();
        }

        public List<IdNamePair> GetDeviceList(int viewId)
        {
            return (from obj in context.Objects
                    join viewHier in context.ViewHierarchies on obj.ObjID equals viewHier.ObjID
                    where viewHier.ViewID == viewId && viewHier.ParentObjID == context.ViewHierarchies.FirstOrDefault(view => view.ViewID == viewId && view.ParentObjID == null).ObjID
                    select new IdNamePair { ID = obj.ObjID, name = obj.Name } ).ToList();
        }

        public List<Device> GetDeviceData(int viewId, int deviceId)
        {
            var devices = context.GetDevices(viewId, deviceId).ToList();
            return GetDeviceHierachy(devices, deviceId);

        }

        private List<Device> GetDeviceHierachy(IEnumerable<DeviceNode> allEmployees, int? parentId)
        {
            int? parentEmployeeId = null;

            parentEmployeeId = parentId;

            var childEmployees = allEmployees.Where(e => e.parentid == parentEmployeeId);

            List<Device> hierarchy = new List<Device>();

            foreach (var emp in childEmployees)
                hierarchy.Add(new Device() { name = emp.name, icon = emp.id ?? 0, children = GetDeviceHierachy(allEmployees, emp.id) });

            return hierarchy;
        }

        #endregion
    }

  }