using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Model.User;
using NHibernate;
using NHibernate.Cfg;
using Environment = NHibernate.Cfg.Environment;

namespace Data
{
    public class NHiberConnection
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    var configuration = new Configuration();
                    try
                    {
                        configuration.Configure(System.Environment.SpecialFolder.ProgramFilesX86+@"\ProgramSettings\DataBaseProperties.cfg.xml");
                    }
                    catch (Exception)
                    {
                        configuration.Configure();
                    }
                    if (!string.IsNullOrEmpty(ConnectionString))
                    {
                        configuration.SetProperty(Environment.ConnectionString, ConnectionString);
                    }
                    configuration.AddAssembly(typeof(User).Assembly);
                    _sessionFactory = configuration.BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }

        public static string ConnectionString { get; set; }


        public static ISession OpenSession()
        {
            var session = SessionFactory.OpenSession();
            session.FlushMode = FlushMode.Commit;
            return session;
        }

        public static void ResetSessionFactory()
        {
            SessionFactory.Close();
            _sessionFactory = null;
        }
    }
}
