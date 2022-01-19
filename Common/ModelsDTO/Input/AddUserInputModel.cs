using System.ComponentModel.DataAnnotations;

namespace Common.ModelsDTO.Input
{
    public class AddUserInputModel
    {
        [Required(ErrorMessage = "Fill Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Fill Username")]
        [RegularExpression(@"^[A-Za-z]\w*$", ErrorMessage = "Not valid username.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Fill Mobile number")]
        [RegularExpression(@"^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}", ErrorMessage = "Not valid mobile number")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Choose the country")]
        public int CountryId { get; set; }
    }
}
