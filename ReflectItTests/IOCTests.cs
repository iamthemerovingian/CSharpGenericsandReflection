using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReflectIt;

namespace ReflectItTests
{
    [TestClass]
    public class IoCTests
    {
        [TestMethod]
        public void Can_Resolve_Types()
        {
            var ioc = new Container();

            var containerBuilderObj = ioc.For<ILogger>(); //This line of code creates a container bulder object with the source type (Ilogger) and a reference to the container object.

            containerBuilderObj.Use<SqlSercerLogger>(); // This line of code registers the same container object with a dictionary entry of Ilogger type and SqlServer type.

            var logger = ioc.Resolve<ILogger>(); // This returns an instance of the ILogger type.

            Assert.AreEqual(typeof(SqlSercerLogger), logger.GetType()); // This is checking if the type of SqlServerLogger and Logger are both Logger type.
        }

        [TestMethod]
        public void Can_Resolve_Types_Without_Default_Ctor()
        {
            var ioc = new Container();
            ioc.For<ILogger>().Use<SqlSercerLogger>();
            ioc.For<IRepository<Employee>>().Use<SqlRepository<Employee>>();

            var repository = ioc.Resolve<IRepository<Employee>>();

            Assert.AreEqual(typeof(SqlRepository<Employee>), repository.GetType());
        }

        [TestMethod]
        public void Can_Resolve_Concrete_Type()
        {
            var ioc = new Container();
            ioc.For<ILogger>().Use<SqlSercerLogger>();
            //ioc.For<IRepository<Employee>>().Use<SqlRepository<Employee>>();
            //ioc.For<IRepository<Customer>>().Use<SqlRepository<Customer>>();
            ioc.For(typeof(IRepository<>)).Use(typeof(SqlRepository<>));

            var service = ioc.Resolve<InvoiceService>();

            Assert.IsNotNull(service);
        }
    }
}
