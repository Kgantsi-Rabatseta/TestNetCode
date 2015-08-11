using System;
using System.Collections.Generic;

namespace Data.Model.UserKey
{
    public class UserModel:HasKey
    {
        private IList<UserAccess> _userAccessRoles;
        public virtual string UserName { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual string Surname { get; set; }

        public virtual string Password { get; set; }

        public virtual string OldPassword { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual IList<UserAccess> UserAccess
        {
            get { return _userAccessRoles; } set { _userAccessRoles = value; }
        }

        public Boolean HasAccess(UserAccess userAccess)
        {
            return _userAccessRoles.Contains(userAccess);
        }
    }
}
