using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MailingService.Tests.DataAcces
{
    /// <summary>
    /// Summary description for DbTest
    /// </summary>
    [TestClass]
    public class DBTest
    {

        public DBTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [TestMethod]
        public void TestCheckBasisPlanOnID()
        {
            BasisPlanDB BPDB = new BasisPlanDB();

            BasisPlan BP = BPDB.FindBasisPlanByID(1);

            Assert.IsNotNull(BP);
        }

        [TestMethod]
        public void TestBasisPlanForEdits()
        {

        }
    }
}
