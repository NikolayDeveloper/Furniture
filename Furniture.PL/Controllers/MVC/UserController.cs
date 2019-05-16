using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Furniture.PL.Filters;
using Furniture.BLL;
using AutoMapper;


namespace Furniture.PL.Controllers.MVC
{
    /// <summary>
    /// Контроллер для User
    /// </summary>
    [MyAuthorize(Roles = "User")]
    public partial class UserController : Controller
    {
        /// <summary>
        /// Корзина пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual ActionResult Crate(int id=0)
        {
            List<int> IdFurnitures = new List<int>();
            var sessionCounter = Session["Counter"];
            int counter = 0;
            if (sessionCounter != null)
            {
                counter = Convert.ToInt32(sessionCounter);
            }
            if (id != 0)
            {
                counter++;
            }
            Session["Counter"] = counter;
            if (Session["id"] != null)
            {
                IdFurnitures = Session["id"] as List<int>;
                IdFurnitures.Add(id);
            }
            Session["id"] = IdFurnitures;
            return PartialView("_Crate",counter);
        }
        /// <summary>
        /// Содержание корзины пользователя
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult ContentCrate()
        {
            List<int> IdFurnitures = Session["id"] as List<int>;
            int[] idFurnituresArray = IdFurnitures.ToArray<int>();
            FurnitureService furnitureService = new FurnitureService();
            List<FurnitureListViewModel> list = Mapper.Map<List<FurnitureListViewModel>>(furnitureService.GetFurniture(idFurnituresArray));
            return View(list);
        }
        /// <summary>
        /// Убрать мебель из корзины пользователя
        /// </summary>
        /// <param name="IdFurniture"></param>
        [HttpPost]
        public void EjectFurnitureFromCrate(int IdFurniture=0)
        {
            int counter = 0;
            List<int> IdFurnitures = Session["id"] as List<int>;
            if (IdFurnitures.Remove(IdFurniture))
            {
                counter = Convert.ToInt32(Session["Counter"])-1;
                Session["Counter"] = counter;
            }

            Session["id"] = IdFurnitures;
        }
        /// <summary>
        /// Скачать файл подверждения о приобретенной мебели
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Purchase()
        {
            FurnitureService furnitureService = new FurnitureService();
            string filePath = AppDomain.CurrentDomain.BaseDirectory + @"FurnitureAffirmation.txt";
            List<int> IdFurnitures = Session["id"] as List<int>;
            int[] idFurnituresArray = IdFurnitures.ToArray<int>();
            try
            {
                furnitureService.CreateFile(filePath, idFurnituresArray);
                return File(Server.MapPath("~/FurnitureAffirmation.txt"), "application/octed-stream", "FurnitureAffirmation.txt");
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }
    }
}
