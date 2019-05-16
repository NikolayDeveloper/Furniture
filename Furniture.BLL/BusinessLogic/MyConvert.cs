using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Furniture.BLL
{
    public static class MyConvert
    {
        /// <summary>
        /// Конвертация объекта HttpPostedFileBase в массив байтов для хранения в бд
        /// </summary>
        /// <param name="furniture"></param>
        /// <param name="img"></param>
        /// <returns></returns>
        public static FurnitureListDTO TurnPhoto(FurnitureListDTO furniture, HttpPostedFileBase img)
        {
            byte[] photo = null;
            if (img != null)
            {
                using (var binaryReader = new BinaryReader(img.InputStream))
                {
                    photo = binaryReader.ReadBytes(img.ContentLength);
                }
            }
            furniture.Photo = photo;
            return furniture;
        }
    }
}
