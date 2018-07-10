using System;

using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace BL
{
    public class UserBL
    {
        private UserDAL udal = new UserDAL();
        public User Login(string username, string password)
        {
            Regex regex = new Regex("[a-zA-Z0-9_]");
            MatchCollection matchCollectionUsername = regex.Matches(username);
            MatchCollection matchCollectionPassword = regex.Matches(password);
            if (matchCollectionUsername.Count < username.Length || matchCollectionPassword.Count < password.Length)
            {
                return null;
            }
            return udal.Login(username, password);
        }
    }

    
    