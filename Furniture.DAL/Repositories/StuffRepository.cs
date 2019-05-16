using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace Furniture.DAL
{
    public class StuffRepository
    {
        private FurnitureContext db = null;
        /// <summary>
        /// Получение всех предметов с зависимостями
        /// </summary>
        /// <returns></returns>
        public List<Stuff> GetStuffs()
        {
            List<Stuff> stuffs = null;
            using (db = new FurnitureContext())
            {
                stuffs = db.Stuffs.Include(m => m.Room).ToList();
            }
            return stuffs;
        }
        /// <summary>
        /// Получение одной мебели
        /// </summary>
        /// <param name="idStuff"></param>
        /// <returns></returns>
        public Stuff GetStuff(int idStuff)
        {
            Stuff stuff = null;
            using (db = new FurnitureContext())
            {
               stuff= db.Stuffs.Where(m => m.Id == idStuff).FirstOrDefault();
            }
            return stuff;
        }
    }
}
