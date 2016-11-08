using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UraApp.Utility;

namespace UraApp.Utility
{

    public class UserSession : Controller
    {
        private string SessionName = "Sbabu.Session";

        public UserSession(int userId, string userName)
        {
            UserId = userId;
            UserName = userName;
        }
        public int UserId { get; set; }
        public string UserName { get; set; }

        public void SetSession(UserSession session)
        {
            HttpContext.Session.SetObjectAsJson(SessionName, session);
        }

        public UserSession GetSession()
        {
            if (HttpContext.Session.Get(SessionName) != null)
            {
                return HttpContext.Session.GetObjectFromJson<UserSession>(SessionName);
            }
            else
            {
                return null;
            }
        }


    }
}