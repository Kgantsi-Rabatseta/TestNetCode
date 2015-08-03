using System.Collections.Generic;

namespace DataUtilities.User
{
    public class UserBuilder:Builder
    {
        private const string UserNameString = "UserName";
        private const string PasswordString = "password";
        private const string EmailAddressString = "EmailAddress@";
        private const string DotCom = ".com";
        private readonly string _userName;
        private readonly string _password;
        private readonly string _emailAddress;
        private int _version;

        public static Data.Objects.User BuildAUser()
        {
             return new UserBuilder(){_version = 1}.Build();
         }

        public static IList<Data.Objects.User> BuildUsers(int numberOfUsers)
        {
            var list = new List<Data.Objects.User>();
            for (var i = 1; i <= numberOfUsers; i++)
            {
                var name = UserNameString + i;
                var password = PasswordString + i;
                var email = EmailAddressString + i;
                list.Add(new UserBuilder(name,password,email,i).Build());
            }
            return list;
        }


        public UserBuilder():this(UserNameString+0,PasswordString+0,EmailAddressString+0)
        {
            
        }

        public UserBuilder(string userName, string password, string emailAddress)
        {
            _userName = userName;
            _password = password;
            _emailAddress = emailAddress;
        }

        private UserBuilder(string userName, string password, string emailAddress, int version):this(userName,password,emailAddress)
        {
            _version = version;
        }

        private Data.Objects.User Build()
        {
            var user = new Data.Objects.User
                {
                    UserName = _userName,
                    Password = _password,
                    EmailAddress = _emailAddress+DotCom,
                    Version = _version
                };
            return user;
        }
    }
}