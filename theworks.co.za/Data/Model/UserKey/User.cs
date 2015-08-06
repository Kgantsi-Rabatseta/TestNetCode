using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Model.UserKey
{
    public class User:HasKey
    {
        public virtual string UserName { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual string Surname { get; set; }

        public virtual string Password { get; set; }
    }
}
