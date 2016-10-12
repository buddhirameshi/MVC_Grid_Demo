using DataAccessor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public class ItemDto
    {

        [DisplayName("Id")]
        public int ItemId { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [DataType(DataType.Currency, ErrorMessage = "Invalid value for currency")]
        public decimal? Price { get; set; }

        [MaxLength(50, ErrorMessage = "Please enter a value within 50 characters")]
        public string Description { get; set; }
        //public int ItemId { get; set; }
        //public decimal? Price { get; set; }
        //public string Description { get; set; }
    }
}
