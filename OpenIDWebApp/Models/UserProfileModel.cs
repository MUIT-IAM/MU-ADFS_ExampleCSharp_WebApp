using System.Collections.Generic;
using System.Security.Claims;

namespace OpenIDWebApp.Models
{
    public class UserProfile
    {
        private Dictionary<string, string> _claim = new Dictionary<string, string>();
        private Dictionary<string, string> _claimType = new Dictionary<string, string>() {
            { "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress","email" },
            { "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname","given_name" },
            { "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name","unique_name" },
            { "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/upn","upn" },
            { "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname","family_name" },
            {"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/privatepersonalidentifier","ppid" },
            {"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier","sub" },
            {"http://schemas.microsoft.com/ws/2008/06/identity/claims/windowsaccountname","winaccountname" },
        };


        public UserProfile(System.Security.Claims.ClaimsIdentity ci)
        {
            foreach (Claim c in ci.Claims)
            {
                string claimType = _claimType.ContainsKey(c.Type) == true ? _claimType[c.Type] : c.Type;
                _claim.Add(claimType, c.Value);
            }
        }

        public Dictionary<string, string> Claims { get { return _claim; } }
    }
}