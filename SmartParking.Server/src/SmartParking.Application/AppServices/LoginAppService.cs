using SmartParking.IAppServices;
using Volo.Abp.Validation;

namespace SmartParking.AppServices
{
    public class LoginAppService : SmartParkingAppService, ILoginAppService, IValidationEnabled
    {

        public LoginAppService()
        {
        }
    }
}
