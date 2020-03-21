using System;
using System.Reflection;
using System.Web;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using NHibernate.Tool.hbm2ddl;

namespace IIT.EResult.Modules
{
    public class PersistenceSessionManager //: IHttpModule
    {
        //Session factories can be expensive to create, especially with a large domain model. 
        //So we only want to instantiate one of these during the lifetime of our app, which will hang around in memory until our app dies
        private static readonly ISessionFactory _SessionFactory;
        
        // Constructs our HTTP module
        static PersistenceSessionManager()
        {
            _SessionFactory = CreateSessionFactory();
        }

        // Returns our session factory
        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(CreateDbConfig)
                //.Mappings(m => m.AutoMappings.Add(CreateMappings()))
                .Mappings(x => x.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .ExposeConfiguration(UpdateSchema)
                .CurrentSessionContext<WebSessionContext>()
                .BuildSessionFactory();
        }

        // Returns our database configuration
        private static MsSqlConfiguration CreateDbConfig()
        {
            return MsSqlConfiguration
                .MsSql2008
                .ConnectionString(c => c.FromConnectionStringWithKey("sqlConnStr"));
        }

        // Returns our mappings
        private static AutoPersistenceModel CreateMappings()
        {
            return AutoMap
                .Assembly(System.Reflection.Assembly.GetCallingAssembly())
                .Where(t => t.Namespace != null && t.Namespace.EndsWith("Models"))
                .Conventions.Setup(c => c.Add(DefaultCascade.SaveUpdate()));
        }

        // Updates the database schema if there are any changes to the model,
        // or drops and creates it if it doesn't exist
        private static void UpdateSchema(Configuration cfg)
        {
            new SchemaUpdate(cfg)
                .Execute(false, true);
        }


        // Binds and returns the current session
        public static ISession GetCurrentSession()
        {
            if (!CurrentSessionContext.HasBind(_SessionFactory))
            {
                CurrentSessionContext.Bind(_SessionFactory.OpenSession());
            }
            return _SessionFactory.GetCurrentSession();
        }

        // Unbinds and closes the current session
        public static void DisposeCurrentSession()
        {
            ISession currentSession = CurrentSessionContext.Unbind(_SessionFactory);
            if (currentSession != null)
            {
                currentSession.Close();
                currentSession.Dispose();
            }
        }

        /*
        // Returns the current session
        public static ISession GetCurrentSession()
        {
            return _SessionFactory.GetCurrentSession();
        }

        // Initializes the HTTP module
        public void Init(HttpApplication context)
        {
            context.BeginRequest += BeginRequest;
            context.EndRequest += EndRequest;
        }

        // Opens the session, begins the transaction, and binds the session
        private static void BeginRequest(object sender, EventArgs e)
        {
            ISession session = _SessionFactory.OpenSession();

            session.BeginTransaction();

            CurrentSessionContext.Bind(session);
        }

        // Unbinds the session, commits the transaction, and closes the session
        private static void EndRequest(object sender, EventArgs e)
        {
            ISession session = CurrentSessionContext.Unbind(_SessionFactory);

            if (session == null) return;

            try
            {
                session.Transaction.Commit();
            }
            catch (Exception)
            {
                session.Transaction.Rollback();
            }
            finally
            {
                session.Close();
                session.Dispose();
            }
        }

        // Disposes the HTTP module
        public void Dispose() { }        
        */
    }
}
