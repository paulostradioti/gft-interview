using System;
using Domain.Entites;
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
     
    }
}
