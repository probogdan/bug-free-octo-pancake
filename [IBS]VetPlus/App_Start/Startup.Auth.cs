using _IBS_InterfacesBLL;
using System.Configuration;
using System.Linq;
using Ninject;
using System;
using System.IO;

namespace _IBS_VetPlus
{
    public class StartupConfig
    {
        private static KernelBase _kernelBase;

        public static void Configure()
        {
            var adminLogin = ConfigurationManager.AppSettings.GetValues("defaultAdminLogin").FirstOrDefault();
            var AdminPassword = ConfigurationManager.AppSettings.GetValues("defaultAdminPassword").FirstOrDefault();
            var AdminAvatar = ConfigurationManager.AppSettings.GetValues("defaultAdminAvatar").FirstOrDefault();
            var AdminAvatarMimeType = ConfigurationManager.AppSettings.GetValues("defaultAdminAvatarMimeType").FirstOrDefault();
            var AdminDateOfBirth = new DateTime(1996, 11, 30);
            var AdminAge = DateTime.Now.Year - AdminDateOfBirth.Year;           
            var AdminAvatarBytes = File.ReadAllBytes(AdminAvatar);
            var _authModule = _kernelBase.Get<IAuthBLL>();

            if (_authModule.GetUser(adminLogin) == null)
            {
                _authModule.CreateAccount(new _IBS_Entities.Account()
                {
                    Age = AdminAge,
                    DateOfBirth = AdminDateOfBirth,
                    ProfilePhotoMimeType = AdminAvatarMimeType,
                    Password = AdminPassword,
                    Name = adminLogin,
                    Roles = new string[] {
                                         "user",
                                         "admin",
                                         "consultant" //в переводе - консультант
                                         },
                    ProfilePhoto = AdminAvatarBytes
                });               
            }
        }
    }
}
