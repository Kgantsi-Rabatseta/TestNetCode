using Data.Constants;

namespace Data.Model.UserKey
{
    public class UserAccess:HasKey
    {
        public virtual Enumerators.UserAccessRole UserRole { get; set; }
        public virtual UserModel UserModel { get; set; }
    }
}
