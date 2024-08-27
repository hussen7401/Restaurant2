using System.ComponentModel.DataAnnotations;

namespace Core.Dtos.Reservation
{
    public class TableDto
    {
        [Required(ErrorMessage ="الرجاء اختيار رقم الطاولة ")]
        public int TableNumber { get; set; }

        [Required(ErrorMessage = "الرجاء اختيار عدد المقاعد ")]
        [Range(1, 20)]
        public int Capacity { get; set; }
    }
}
