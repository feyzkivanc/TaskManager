using Castle.MicroKernel.SubSystems.Conversion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace WebApplication16.Models
{
    public class Event
    {
        [Key]
        public int EventID { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Event Name")]
        public string EventName { get; set; }
        [Column(TypeName = "varchar(250)")]
        [DisplayName("Detail")]
        public string Detail { get; set; }
        [Column(TypeName = "Date")]
        [Required(ErrorMessage = "This field is required.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayName("Start")]
        public DateTime Start { get; set; }
        [Column(TypeName = "Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]

        [DisplayName("End")]
        public DateTime End { get; set; }

    }
}
