using Furniture.PL.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Furniture.BLL;
using Furniture.DAL;
using AutoMapper;

namespace Furniture.PL.Controllers.MVC
{
    /// <summary>
    /// Контроллер предназначен только для Admin
    /// </summary>
    [MyAuthorize(Roles = "Admin")]
    public partial class AdminController : Controller
    {
        private FurnitureService furnitureService = null;
        public AdminController()
        {
            furnitureService = new FurnitureService();
        }
     
        /// <summary>
        /// Создание мебели
        /// </summary>
        /// <param name="IdStuff"></param>
        /// <seealso cref="Create(FurnitureListViewModel, HttpPostedFileBase)"/>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult Create(int IdStuff = 0)
        {
            return View(new FurnitureListViewModel() { IdStuff = IdStuff, IsExist = true });
        }
        /// <summary>
        /// Создание мебели
        /// </summary>
        /// <param name="furniture"></param>
        /// <param name="img"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual ActionResult Create(FurnitureListViewModel furniture, HttpPostedFileBase img)
        {
            if (ModelState.IsValid)
            {

                if (furnitureService.CreateStuff(Mapper.Map<FurnitureListDTO>(furniture), img))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return Content("По какой то причине не удалось создать новый объект");
                }
            }
            else
            {
                ModelState.AddModelError("", "Заполните поля");
            }
            return View("Create", furniture);
        }
        /// <summary>
        /// Редактирование мебели
        /// </summary>
        /// <param name="Id"></param>
        /// <seealso cref="Edit(FurnitureListViewModel, HttpPostedFileBase)"/>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult Edit(int Id)
        {
            FurnitureListViewModel furniture = Mapper.Map<FurnitureListViewModel>(furnitureService.Find(Id));
            return View(furniture);
        }

        /// <summary>
        /// Редактирование мебели
        /// </summary>
        /// <param name="furniture"></param>
        /// <param name="Image"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual ActionResult Edit(FurnitureListViewModel furniture,HttpPostedFileBase Image)
        {
            if(ModelState.IsValid)
            {
                FurnitureListDTO furnitureDTO = Mapper.Map<FurnitureListDTO>(furniture);
                furnitureService.EditFurniture(furnitureDTO, Image);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Заполните поля");
                return View(furniture);
            }
        }
    }
}
