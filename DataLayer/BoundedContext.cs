using System.Data.Entity;
using System.Reflection;

namespace DataLayer
{
    public class BoundedContext<TContext> : DbContext where TContext : DbContext
    {
        static BoundedContext()
        {
            Database.SetInitializer(new NullDatabaseInitializer<TContext>());
        }

        protected BoundedContext() : base("name=ApplicationContext")
        {

        }
    }
}