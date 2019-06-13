using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uStore.Data.EF//.Metadata
{

    [MetadataType(typeof(ProductMetadata))]
    public partial class Product { }

    public class ProductMetadata
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage = "* Required")]
        [StringLength(150, ErrorMessage = "* Maximum 150 Characters")]
        public string Name { get; set; }

        [StringLength(250, ErrorMessage = "* Maximum 250 Characters")]
        public string Description { get; set; }

        public decimal Price { get; set; }

        [Display(Name = "Units In Stock")]
        public int UnitsInStock { get; set; }

        [StringLength(75, ErrorMessage = "* Maximum 75 Characters")]
        [Display(Name = "Product Image")]
        public string ProductImage { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "* Required")]
        [RegularExpression(@"[1-4]{1}", ErrorMessage = "* Please enter number (1-4) for StatusID")]
        public int StatusID { get; set; }

        [Display(Name = "Category")]
        [RegularExpression(@"[1-6]{1}", ErrorMessage = "* Please enter number (1-6) for CategoryID")]
        public int CategoryID { get; set; }

        [StringLength(500, ErrorMessage = "* Maximum 500 Characters")]
        public string Notes { get; set; }

        [StringLength(1024, ErrorMessage = "* Maximum 1024 Characters")]
        [Display(Name = "Reference URL")]
        public string ReferenceURL { get; set; }
    }
}
