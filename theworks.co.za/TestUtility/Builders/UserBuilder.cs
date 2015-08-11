using System.Collections.Generic;
using Data.Model.UserKey;

namespace TestUtility.Builders
{
    public class UserBuilder
    {
        private readonly int _userNumber;

        private UserBuilder(int userNumber)
        {
            _userNumber = userNumber;
        }

        public static IList<UserModel> BuildUsers(int numberOfUsers)
        {
            var usersList = new List<UserModel>();
            for (var i = 1; i <= numberOfUsers; )
            {
                usersList.Add(BuildAUser(i++));
            }
            return usersList;
        }

        public static UserModel BuildAUser(int userNmuber)
        {
            return new UserBuilder(userNmuber).Build();
        }

        private UserModel Build()
        {
            return new UserModel
                {
                    UserName = "UserName_"+_userNumber,
                    FirstName = "firstName_"+_userNumber,
                    LastName = "UserLastName_"+_userNumber,
                    Surname = "UserSurname_"+_userNumber,
                    Password ="UserPassword_"+_userNumber
                };
        }
    }
}
