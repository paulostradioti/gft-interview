using System;
using Domain.Entites;
using Domain.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Test
{
    [TestClass]
    public class OrderTest
    {

        public TestContext TestContext { get; set; }

        [TestMethod]
        [DeploymentItem("GetTimeOfDay_ValidInput.xls")]
        [DataSource("System.Data.Odbc", "Driver={Microsoft Excel Driver (*.xls)};DBQ=GetTimeOfDay_ValidInput.xls;defaultdir=.", "Plan1$", DataAccessMethod.Sequential)]                
        public void TestGetTimeOfDay()
        {
            var userInput = Convert.ToString(TestContext.DataRow["Input"]);
            var order = new Order(userInput);

            var expectedOutput = Convert.ToString(TestContext.DataRow["Output"]);
            
            order.GetTimeOfDay();

            Assert.AreEqual(order.TimeOfDay.ToString().ToLower(), expectedOutput);
        }


        [TestMethod]
        [DeploymentItem("GetTimeOfDay_InvalidInput.xls")]
        [DataSource("System.Data.Odbc", "Driver={Microsoft Excel Driver (*.xls)};DBQ=GetTimeOfDay_InvalidInput.xls;defaultdir=.", "Plan1$", DataAccessMethod.Sequential)]
        [ExpectedException(typeof(InvalidTimeOfDayException))]
        public void TestGetTimeOfDay_InvalidEntries()
        {
            var userInput = Convert.ToString(TestContext.DataRow["Input"]);
            var order = new Order(userInput);

            order.GetTimeOfDay();
        }
     
    }
}
