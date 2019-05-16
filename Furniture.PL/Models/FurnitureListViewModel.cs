using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Furniture.PL
{
    public class FurnitureListViewModel
    {
        public int Id { get; set; }
        [DisplayName("Фото")]
        public byte[] Photo { get; set; }

        [Required(ErrorMessage = "Введите название мебели")]
        [DisplayName("Название")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Из чего сделано?")]
        [DisplayName("Материал")]
        public string Material { get; set; }

        [Required(ErrorMessage = "Черты мебели")]
        [DisplayName("Особенности")]
        public string Characteristic { get; set; }
        [DisplayName("Наличие")]
        public bool IsExist { get; set; }

        [Required(ErrorMessage = "Введите цену")]
        [DisplayName("Цена")]
        public int Price { get; set; }
        public int IdStuff { get; set; }

    }
}