namespace Shop.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class Product : IEntity
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "El campo {0} solo puede contener un máximo de {1} caracteres")]
        [Required (ErrorMessage = "El campo {0} es requerido") ]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        //TODO: corregir el precio al editar cambia los decimales
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        [Display(Name = "Precio")]
        public decimal Price { get; set; }

        [Display(Name = "Imagen")]
        public string ImageUrl { get; set; }

        [Display(Name = "Última Compra")]
        public DateTime? LastPurchase { get; set; }

        [Display(Name = "Última Venta")]
        public DateTime? LastSale { get; set; }

        [Display(Name = "Está Disponible?")]
        public bool IsAvailabe { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public double Stock { get; set; }
        public User User { get; set; }
        public string ImageFullPath 
        {
            get
            {
                if (string.IsNullOrEmpty(this.ImageUrl))
                {
                    return null;
                }
                return $"https://shopmamba.azurewebsites.net{this.ImageUrl.Substring(1)}";
            } 
        }
    }
}
