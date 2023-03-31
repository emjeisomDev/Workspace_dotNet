using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels
{
    public class EditorCategoryViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "This field must contain between 3 and 40 characters.")]
        public String  Name { get; set; }

        [Required(ErrorMessage = "Slug is required.")]
        public String Slug { get; set; }
    }
}
