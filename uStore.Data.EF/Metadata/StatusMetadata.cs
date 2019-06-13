using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uStore.Data.EF//.Metadata
{

    [MetadataType(typeof(StatusMetadata))]
    public partial class Status { }

    public class StatusMetadata
    {
        [Display(Name = "Status")]
        public int StatusID { get; set; }

        [Required(ErrorMessage = "* Required")]
        [Display(Name = "Status Name")]
        [StringLength(30, ErrorMessage = "* Maximum of 30 characters")]
        public string StatusName { get; set; }

        [Required(ErrorMessage = "* Required")]
        [Display(Name = "Status Order")]
        public byte StatusOrder { get; set; }

        [StringLength(100, ErrorMessage = "* Maximum of 100 characters")]
        public string Notes { get; set; }
    }
}
