using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory.Model
{
    public class Product
    {
        [Key]
      public int ProductID {  get; set; } 
      public string PName {  get; set; }
     public string PDescription {  get; set; } 
     public int Quantity {  get; set; }
     public decimal Price { get; set; }
        public int SupplierID { get; set; }      
        [ForeignKey("SupplierID")]
       public Supplier supplier { get; set; }

    }
}
