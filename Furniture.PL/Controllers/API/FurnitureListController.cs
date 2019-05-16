using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Furniture.DAL;
using System.Web.Http.Description;
using Furniture.BLL;
using System.Web.SessionState;
using System.Threading;
using static System.Collections.Specialized.BitVector32;
using System.Web;

namespace Furniture.PL.Controllers.API
{
    /// <summary>
    /// Контроллер для обслуживания списка мебели
    /// </summary>
    public class FurnitureListController : ApiController
    {
        private FurnitureContext db = new FurnitureContext();
        /// <summary>
       /// Добавление выбранной мебели в список мебели
       /// </summary>
       /// <param name="furniture"></param>
       /// <returns></returns>
        public IHttpActionResult PostFurnitureList(FurnitureList furniture)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FurnitureLists.Add(furniture);
            db.SaveChanges();

             return Ok(HttpStatusCode.Created);
        }
        /// <summary>
        /// Удаление мебели из списка мебели
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult DeleteFurniture(int id)
        {
           FurnitureList furniture= db.FurnitureLists.Find(id);
            if (furniture == null)
            {
                return NotFound();
            }
            db.FurnitureLists.Remove(furniture);
            db.SaveChanges();
            return Ok();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
