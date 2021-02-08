using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model_Object
{
    public class UserInfoDO
    {
        public int UserID { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required.")]
        public string UserName { get; set; }

        [Display(Name = "Age")]
        [Required(ErrorMessage = "Age is required.")]
        public int UserAge { get; set; }

        [Display(Name = "Height")]
        [Required(ErrorMessage = "Height is required.")]
        public string UserHeight { get; set; }

        [Display(Name = "Weight")]
        [Required(ErrorMessage = "Weight is required.")]
        public string UserWeight { get; set; }

        [Display(Name = "Mobile No.")]
        [Required(ErrorMessage = "Mobine number is required.")]
        public string UserMobile { get; set; }

        [Display(Name = "Symptoms")]
        [Required(ErrorMessage = "Symptoms is required.")]
        public string Symptoms { get; set; }
    }
}
