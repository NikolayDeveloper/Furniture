using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.BLL
{
    
    public  class FurnitureListDTO
    {
        public int Id { get; set; }
        public byte[] Photo { get; set; }
        public string Name { get; set; }
        public string Material { get; set; }
        public string Characteristic { get; set; }
        public bool IsExist { get; set; }
        public int Price { get; set; }
        public int IdStuff { get; set; }
    }
}
