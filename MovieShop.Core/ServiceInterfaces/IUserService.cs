using MovieShop.Core.Models.Request;
using MovieShop.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Core.ServiceInterfaces
{
    public interface IUserService
    {
        Task<bool> RegisterUser(UserRegisterRequestModel userRegisterRequestModel);
        Task<LoginResponseModel> ValidateUser(LoginRequestModel loginRequestModel);
        Task<bool> PurchaseMovie(PurchaseRequestModel purchaseRequest);
    }
}
