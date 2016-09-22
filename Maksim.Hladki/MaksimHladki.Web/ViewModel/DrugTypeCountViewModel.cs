using System.ComponentModel.DataAnnotations;

namespace MaksimHladki.Web.ViewModel
{
    public class DrugTypeCountViewModel : DrugTypeViewModel
    {
        [Required]
        [Display(Name = "Count")]
        [Range(0, short.MaxValue)]
        [DataType(DataType.Currency)]
        public int Count { get; set; }
    }
}