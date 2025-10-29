using ProductInventory.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory.Model
{
   
    public class Supplier
    {
        [Key]
      public int supid {  get; set; }
        [Required]
    public string Phone {  get; set; }
    public string Email {  get; set; }
        public string SName {  get; set; }

        public ICollection<Product> Products { get; set; }=new List<Product>();
    }
}
