using System.Data.Entity;
using System.Reflection;

namespace DataLayer
{
    public class BaseContext<TContext> : DbContext where TContext : DbContext
    {
        static BaseContext()
        {
            Database.SetInitializer(new NullDatabaseInitializer<TContext>());
        }

        protected BaseContext() : base("name=ApplicationContext")
        {

        }
    }
}