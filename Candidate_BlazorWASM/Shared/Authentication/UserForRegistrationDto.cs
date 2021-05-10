using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_BlazorWASM.Shared
{
    public class UserForRegistrationDto
    {
        [Required(ErrorMessage = "Email không được bỏ trống!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được bỏ trống!")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Xác nhận mật khẩu không khớp!")]
        public string ConfirmPassword { get; set; }
    }
}
