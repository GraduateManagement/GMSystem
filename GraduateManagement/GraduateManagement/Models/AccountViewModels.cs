using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GraduateManagement.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "用户")]
        public string accountNum { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string password { get; set; }

        [Display(Name = "记住密码")]
        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "学号")]
        public string accountNum { get; set; }

        [Required]
        [Display(Name = "姓名")]
        public string name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "密码最小长度至少要6位", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "初始密码")]
        public string password { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}