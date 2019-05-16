using System;
using System.Collections.Generic;
using AutoMapper;
using Furniture.DAL;
using System.Web;
using System.IO;
using System.Net.Http;


namespace Furniture.BLL
{
    public  class FurnitureService
    {
        private FurnitureListRepository _repo = null;
        string path = "http://localhost:49433/api/FurnitureList";
        public FurnitureService()
        {
            _repo = new FurnitureListRepository();
        }
        /// <summary>
        /// Получение списка мебели
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<FurnitureListDTO> GetFurniture(int id)
        {
            return Mapper.Map<List<FurnitureListDTO>>(_repo.GetFurniture(id));
        }
        /// <summary>
        /// Получение списка мебели
        /// </summary>
        /// <param name="idFurnitures">массив id мебели</param>
        /// <seealso cref="GetFurniture(int)"/>
        /// <returns></returns>
        public List<FurnitureListDTO> GetFurniture(params int[] idFurnitures)
        {
            return Mapper.Map<List<FurnitureListDTO>>(_repo.GetFurniture(idFurnitures));
        }
        /// <summary>
        /// Создание мебели
        /// </summary>
        /// <param name="furniture"></param>
        /// <param name="img"></param>
        /// <returns></returns>
        public bool CreateStuff(FurnitureListDTO furniture, HttpPostedFileBase img)
        {
            MyConvert.TurnPhoto(furniture, img);
            HttpClient client = null;
            string statusCode = null;
            using (client = new HttpClient())
            {
                HttpResponseMessage response =  client.PostAsJsonAsync(path, Mapper.Map<FurnitureList>(furniture)).Result;
                statusCode = response.StatusCode.ToString();
            }
            if (statusCode!=null&&statusCode=="OK")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Поиск мебели
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FurnitureListDTO Find(int id)
        {
            FurnitureList furniture = _repo.Find(id);
            if(furniture!=null)
            {
                return Mapper.Map<FurnitureListDTO>(furniture);
            }
            else
            {
                throw new NotSupportedException();
            }
        }
        /// <summary>
        /// Редактирование мебели
        /// </summary>
        /// <param name="furniture"></param>
        /// <param name="img"></param>
        /// <returns></returns>
        public bool EditFurniture(FurnitureListDTO furniture, HttpPostedFileBase img)
        {
            if(img!=null)
            {
                MyConvert.TurnPhoto(furniture, img);
            }
           
            _repo.Edit(Mapper.Map<FurnitureList>(furniture));
            return true;
        }
        /// <summary>
        /// Создать файл подверждения
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="idFurnitures"></param>
        public void CreateFile(string filePath,params int[] idFurnitures)
        {
           List<FurnitureList> furnitures = _repo.GetFurniture(idFurnitures);
            FileStream destFile = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(destFile);
            for (int i = 0; i < furnitures.Count; i++)
            {
                string str = string.Format("Приобретен "+furnitures[i].Name+" Цена: "+furnitures[i].Price);
                writer.WriteLine(str);
            }
            writer.Close();
            destFile.Close();
        }
    }
}
