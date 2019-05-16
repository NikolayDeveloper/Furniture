using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Furniture.DAL;
using AutoMapper;
namespace Furniture.BLL
{
    public class StuffService
    {
        private StuffRepository _repo = null;
        public StuffService()
        {
            _repo = new StuffRepository();
        }
        /// <summary>
        /// Получение всех предметов с зависимостями
        /// </summary>
        /// <returns></returns>
        public List<StuffDTO> GetStuffs()
        {
          return  Mapper.Map<List<StuffDTO>>(_repo.GetStuffs());
        }
        /// <summary>
        /// Получение названия мебели
        /// </summary>
        /// <param name="idStuff"></param>
        /// <returns></returns>
        public string GetStuffName(int idStuff)
        {
            Stuff stuff = null;
            stuff= _repo.GetStuff(idStuff);
            if(stuff!=null)
            {
                return stuff.Name;
            }
            throw new NotImplementedException();
        }
    }
}
