using MeuSiteMVC.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace MeuSiteMVC.Helper
{
    public class Session : ISession
    {

        private readonly IHttpContextAccessor _contextAccessor;

        public Session(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        
        public void CreateSessionUser(UserModel user)
        {
            string value = JsonConvert.SerializeObject(user);

            _contextAccessor.HttpContext.Session.SetString("SessionLogedUser", value);
        }

        public UserModel GetSessionUser()
        {
            string sessionUser = _contextAccessor.HttpContext.Session.GetString("SessionLogedUser");

            if (string.IsNullOrEmpty(sessionUser))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<UserModel>(sessionUser);
        }

        public void RemoveSessionUser()
        {
            _contextAccessor.HttpContext.Session.Remove("SessionLogedUser");
        }
    }
}
