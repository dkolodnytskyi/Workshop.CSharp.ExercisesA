using HospitalApp.Areas.Identity.Pages.Account;
using HospitalApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace HospitalApp.ViewModels
{
    public class RegisterViewModel : RegisterModel
    {
        public RegisterViewModel(UserManager<Patient> userManager, 
            IUserStore<Patient> userStore, SignInManager<Patient> signInManager, 
            ILogger<RegisterModel> logger, IEmailSender emailSender) 
            : base(userManager, userStore, signInManager, logger, emailSender)
        {
        }
    }
}
