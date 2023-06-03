using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class FStoreContext : PRN221_SalesApplicationContext
    {
        private static FStoreContext _instance;

        private FStoreContext() :base() { }

        public static FStoreContext GetInstance()
        {
             if (_instance == null)
             {
                 _instance = new FStoreContext();
             }
            return _instance;
        }
    }
}
