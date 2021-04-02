using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OpenIdConnect;
using OpenIDWebApp.Models;

namespace OpenIDWebApp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                UserProfile profile = new UserProfile(new System.Security.Claims.ClaimsIdentity(User.Identity));
                Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(profile.Claims).Replace(",", ",<br />"));
            }
            else
            {
                if (!String.IsNullOrEmpty(Request.QueryString["message"]))
                {
                    Response.Write(Request.QueryString["message"]);
                }
                else
                {
                    HttpContext.Current.GetOwinContext().Authentication.Challenge(new AuthenticationProperties { RedirectUri = "/" }, OpenIdConnectAuthenticationDefaults.AuthenticationType);
                }
            }
        }
    }
}