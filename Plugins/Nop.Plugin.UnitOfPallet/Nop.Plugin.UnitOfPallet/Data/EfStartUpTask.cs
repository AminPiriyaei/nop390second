
using Nop.Core.Infrastructure;

namespace Nop.Plugin.UnitOfPallet.Data
{
    public class EfStartUpTask : IStartupTask
    {
        public int Order
        {
            get
            {
                return 0;
            }
        }

        public void Execute()
        {
            //Database.SetInitializer<KeshNavarObjectContext>(null);
        }
    }
}
