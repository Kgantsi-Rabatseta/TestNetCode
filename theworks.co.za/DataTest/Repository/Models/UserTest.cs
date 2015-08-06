using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Data.Model.UserKey;
using Data.Repository;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using TestUtility.Builders;

namespace DataTest.Repository.Models
{
    class UserTest:RepositoryTest
    {
        private const int UserNmuber = 456;
        private IList<User> _users;
        private UserKeyRepository _repository;

        public override void SetupContect()
        {

            new SchemaExport(Configuration).Execute(false, true, false);

            _repository = new UserKeyRepository();
            _users = UserBuilder.BuildUsers(5);
            foreach (var user in _users)
            {
                user.Key = Guid.NewGuid();
                CreateOrModifyKey(user);
            }
        }

        public override void CreateNew()
        {
            var newUser = UserBuilder.BuildAUser(UserNmuber);
            using (var session = SessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                _repository.CreateNew(session,newUser);
                transaction.Commit();
            }

            using (var session = SessionFactory.OpenSession())
            {
                var userFromDb = _repository.GetAllKeys(session).First(un=>un.UserName.Contains(
                    UserNmuber.ToString(CultureInfo.InvariantCulture)));
                Assert.AreEqual(userFromDb.UserName, newUser.UserName);
                Assert.AreEqual(userFromDb.Password,newUser.Password);
            }
        }
    }
}
