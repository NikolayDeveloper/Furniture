using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Furniture.BLL;
using Furniture.PL.Filters;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;

namespace Furniture.PL.Controllers
{
    /// <summary>
    /// Контроллер предназначен для всех пользователей
    /// </summary>
    public partial class HomeController : Controller
    {
        private StuffService stuffService = null;
        /// <summary>
        /// Метод для навигационного меню
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult Index()
        {
            stuffService = new StuffService();
            string userEmail = User.Identity.Name;
            string userRole = null;
            if (User.Identity.IsAuthenticated)
            {
                using (UserService userService = new UserService())
                {
                    userRole = userService.GetRole(userEmail);
                }
            }
            ViewBag.userRole = userRole;
            List<StuffDTO> listStuffs = stuffService.GetStuffs().ToList();
            ViewBag.BedRoom = new SelectList(listStuffs.Where(m => m.Room == "Спальня"), "Id", "Name");
            ViewBag.Kitchen = new SelectList(listStuffs.Where(m => m.Room == "Кухня"), "Id", "Name");
            return View("Index");
        }
        /// <summary>
        /// В соответствии с ролью определить меню
        /// </summary>
        /// <param name="IdStuff"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual ActionResult AccordingToRole(int IdStuff = 0, string role = null)
        {
            ViewBag.role = role;
            ViewBag.IdStuff = IdStuff;
            return View();
        }
        /// <summary>
        /// Список мебели
        /// </summary>
        /// <param name="IdStuff"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost]
        public  ActionResult StuffList(int IdStuff = 0,string role=null)
        {
            stuffService = new StuffService();
            ViewBag.role = role;
            ViewBag.IdStuff = IdStuff;
            ViewBag.Stuff = stuffService.GetStuffName(IdStuff);
            FurnitureService furnitureService = new FurnitureService();
            List<FurnitureListViewModel> list = Mapper.Map<List<FurnitureListViewModel>>(furnitureService.GetFurniture(IdStuff));
            return PartialView("_StuffList", list);
        }
        [MyAuthorize(Roles = "User")]
        public virtual ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public virtual ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}