using Data.Model;
using NHibernate;
using NHibernate.Cfg;
using NUnit.Framework;

namespace DataTest.Repository
{
    [TestFixture]
    public abstract class RepositoryTest
    {
        protected Configuration Configuration;
        protected ISessionFactory SessionFactory;

        protected ISession OpenSession
        {
            get { return SessionFactory.OpenSession(); }
        }

        [TestFixtureSetUp]
        public void SetUpRepository()
        {
            Configuration = new Configuration();
            Configuration.Configure();
            Configuration.AddAssembly(typeof(HasKey).Assembly);
            SessionFactory = Configuration.BuildSessionFactory();
        }

        [SetUp]
        public abstract void SetupContect();
        public abstract void CreateNew();
        protected void CreateOrModifyKey(HasKey hasKey)
        {
            using (var session = SessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.SaveOrUpdate(hasKey);
                transaction.Commit();
            }
        }

        protected void ModifyKey(HasKey hasKey)
        {
            using (var session = SessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Update(hasKey);
                transaction.Commit();
            }
        }

    }
}
