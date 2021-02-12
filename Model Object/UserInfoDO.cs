using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model_Object
{
    //Data Object class to store the personal information about the user.
    public class UserInfoDO
    {
        [Display(Name = "Email Id")]
        [Required(ErrorMessage = "Email Id is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid Email Id.")]
        public string EmailId { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required.")]
        public string UserName { get; set; }

        [Display(Name = "Age")]
        [Required(ErrorMessage = "Age is required.")]
        public int UserAge { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "Height(m)")]
        [Required(ErrorMessage = "Height is required.")]
        public string UserHeight { get; set; }

        [Display(Name = "Weight(kg)")]
        [Required(ErrorMessage = "Weight is required.")]
        public string UserWeight { get; set; }

        [Display(Name = "Mobile No.")]
        [Required(ErrorMessage = "Mobine number is required.")]
        public string UserMobile { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [NotMapped]
        [Required]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
