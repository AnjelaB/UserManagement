using System.ComponentModel.DataAnnotations;

namespace Common.ModelsDTO.Input
{
    public class UpdateUserDetailsInput
    {
        [Required]
        public int Id { get; set; }

        public string FullName { get; set; }

        [RegularExpression(@"^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}", ErrorMessage = "Not valid mobile number")]
        public string MobileNumber { get; set; }

        public Constants.UserState? State { get; set; }

        public int CountryId { get; set; }
    }
}
