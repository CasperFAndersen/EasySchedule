﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Core;

namespace BusinessLogic.Tests
{
    [TestClass]
    public class TemplateShiftControllerTests
    {
        private ITemplateShiftControlller _templateShiftController;

        [TestInitialize]
        public void TestInitialize()
        {
            _templateShiftController = new TemplateShiftController();
        }
        [TestMethod]
        public void CreateTemplateShiftTest()
        {
            //TODO: Implement this
        }

        [TestMethod]
        public void FindTemplateShiftByIdTest()
        {
            //TODO: Implement this
        }

        [TestMethod]
        public void TestGetAllTemplateShiftsByTemplateScheduleId()
        {
            List<TemplateShift> templateShifts = _templateShiftController.GetTemplateShiftsByTemplateScheduleId(1);
            Assert.IsNotNull(templateShifts);
        }
    }
}
