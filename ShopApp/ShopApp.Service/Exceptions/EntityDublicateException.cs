using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Service.Exceptions
{
    public class EntityDublicateException:Exception
    {
        public EntityDublicateException()
        {

        }

        public EntityDublicateException(string message):base(message)
        {

        }
    }
}
