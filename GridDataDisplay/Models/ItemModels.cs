using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GridDataDisplay.Models
{
    public class ItemModels
    {
        [DisplayName("LookuoId")]
        [ReadOnly(true)]
        public int ItemId { get; set; }

        [Required (ErrorMessage="Price is required")]
        [DataType(DataType.Currency,ErrorMessage ="Invalid value for currency")]
        public decimal? Price { get; set; }

        [MaxLength(50,ErrorMessage ="Please enter a value within 50 characters")]
        public string Description { get; set; }
    }
}