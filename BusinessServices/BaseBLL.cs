using DataAccessLayer.EntityFramework;
using System;

namespace BusinessServices
{
    public class BaseBLL : IDisposable
    {
        public readonly UserManagementDBEntities Db;
        public BaseBLL()
        {
            Db = new UserManagementDBEntities();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
