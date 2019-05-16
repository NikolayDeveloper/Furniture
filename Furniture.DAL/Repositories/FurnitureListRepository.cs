using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.DAL
{
    public  class FurnitureListRepository
    {
        private FurnitureContext db = null;
        /// <summary>
        /// Получение списка мебели
        /// </summary>
        /// <param name="id"></param>
        /// <seealso cref="GetFurniture(int[])"/>
        /// <returns></returns>
        public List<FurnitureList> GetFurniture(int id)
        {
            List<FurnitureList> furniture = null;
            using (db = new FurnitureContext())
            {
                furniture = db.FurnitureLists.Where(m=>m.IdStuff==id).ToList();
            }
            return furniture;
        }
        /// <summary>
        /// Получение списка мебели
        /// </summary>
        /// <param name="idFurnitures">массив id мебели</param>
        /// <seealso cref="GetFurniture(int)"/>
        /// <returns></returns>
        public List<FurnitureList> GetFurniture(params int[] idFurnitures)
        {
            List<FurnitureList> furniture = new List<FurnitureList>();
            FurnitureList tempFurniture = null;
            int tempId = 0;
            using (db = new FurnitureContext())
            {
                for (int i = 0; i < idFurnitures.Length; i++)
                {
                    tempId = idFurnitures[i];
                    tempFurniture = db.FurnitureLists.Where(m => m.Id == tempId).FirstOrDefault();
                    if(tempFurniture!=null)
                    {
                        furniture.Add(tempFurniture);
                        tempFurniture = null;
                    }
                }
            }
            return furniture;
        }
        /// <summary>
        /// Поиск мебели
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FurnitureList Find(int id)
        {
            FurnitureList furniture = null;
            using (db = new FurnitureContext())
            {
                furniture = db.FurnitureLists.Find(id);
            }
            return furniture;
        }
        /// <summary>
        /// Редактирование мебели
        /// </summary>
        /// <param name="furniture"></param>
        /// <returns></returns>
        public void Edit(FurnitureList furniture)
        {
            using (db = new FurnitureContext())
            {
                db.Entry(furniture).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
