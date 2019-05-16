using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Furniture.PL.Controllers;
using System.Web.Mvc;
using Furniture.PL;
using System.Web;

namespace Furniture.Tests.Controller
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void HomeAccordingToRoletViewBag()
        {
            HomeController controller = new HomeController();
            ViewResult result=controller.AccordingToRole(1) as ViewResult;
            Assert.AreEqual(1,result.ViewBag.IdStuff);
           
           
        }
        [TestMethod]
        public void HomeStuffListViewBag()
        {
            HomeController controller = new HomeController();
            //ViewResult result = controller.AccordingToRole(1) as ViewResult;
            // var result = controller.StuffList();
            // Assert.AreEqual(1, result.ViewBag.IdStuff);
            // Assert.AreEqual("_StuffList", result.ViewName);
            SessionStateAttribute s = new SessionStateAttribute(System.Web.SessionState.SessionStateBehavior.Default);
            string a=s.Behavior.ToString();
          
                
        }
    }
}
