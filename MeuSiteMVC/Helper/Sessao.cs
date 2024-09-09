using MeuSiteMVC.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace MeuSiteMVC.Helper
{
    public class Sessao : ISessao
    {

        private readonly IHttpContextAccessor _contextAccessor;

        public Sessao(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        
        public void CreateSessionUser(UserModel user)
        {
            string userValue = JsonConvert.SerializeObject(user);

            _contextAccessor.HttpContext.Session.SetString("sessionLogedUser", userValue);
        }

        public UserModel GetSessionUser()
        {
            string sessionUser = _contextAccessor.HttpContext.Session.GetString("sessionLogedUser");

            if (string.IsNullOrEmpty(sessionUser)) return null;
            

            return JsonConvert.DeserializeObject<UserModel>(sessionUser);
        }

        public void RemoveSessionUser()
        {
            _contextAccessor.HttpContext.Session.Remove("sessionLogedUser");
        }
    }
}
