using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectIt
{
   public interface ILogger
    {

    }

    public class SqlSercerLogger : ILogger
    {

    }

    public interface IRepository<T>
    {

    }

    public class SqlRepository<T> : IRepository<T>
    {
        public SqlRepository(ILogger logger)
        {

        }
    }

    public class InvoiceService
    {
        public InvoiceService(IRepository<Employee> repositoru, ILogger logger)
        {

        }
    }

}
