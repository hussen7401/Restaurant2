

using System.ComponentModel.DataAnnotations;

namespace Core.Dtos
{
    public class MenuItemDto
    {
        [Required(ErrorMessage = "الرجاء ادخال اسم الوجبة ")]
        public required string Name { get; set; }
        [Required(ErrorMessage = "الرجاء ادخال وصف الوجبة ")]
        public required string Description { get; set; }
        [Required(ErrorMessage = "الرجاء ادخال سعر الوجبة ")]
        [Range(0.01 ,99.99)]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "الرجاء تحديد اذا كانت الوجبة متوفرة او غير متوفرة ")]
        public bool IsAvailable { get; set; }
    }
}
