using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uStore.Data.EF//.Metadata
{

    [MetadataType(typeof(CategoryMetadata))]
    public partial class Category { }

    public class CategoryMetadata
    {
        [Display(Name = "Category")]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "* Required")]
        [StringLength(100, ErrorMessage = "* Maximum of 100 characters")]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        [StringLength(500, ErrorMessage = "* Maximum of 500 characters")]
        public string Notes { get; set; }
    }
}
