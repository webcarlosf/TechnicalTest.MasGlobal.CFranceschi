using DaoContext;
using DaoContext.Repositories.Interfaces;
using LogicContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace Tests
{
    public class Tests
    {
        IEmployeeRepository _IEmployeeRepository;

        [TestMethod]
        public async Task GetEmployeesTest()
        {
            _IEmployeeRepository = new EmployeeRepository();

            EmployeeLogicContext obj = new EmployeeLogicContext(_IEmployeeRepository);
            var respuesta = obj.GetAll();

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(respuesta.Result.Count() > 1);

        }
    }
}