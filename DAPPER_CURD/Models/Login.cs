using System.ComponentModel.DataAnnotations;

namespace DAPPER_CURD.Models
{
    public class LoginModel: LoginResponse
    {
        [Required(ErrorMessage ="Please Enter UserName")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
    public class LoginResponse:ErrorViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
    }
}
