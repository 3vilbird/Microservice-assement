using Microsoft.EntityFrameworkCore;

namespace storageservice.UniqueCodeContext
{
    public static class DbPrep
    {

        public static void PrePopulation(IApplicationBuilder app)
        {
            // this will take care of initial db set up;
            using (var serviceScope = app.ApplicationServices.CreateAsyncScope())
            {
                PrepareDatabase(serviceScope.ServiceProvider.GetService<UniquecodeContext>());
            }
        }

        public static void PrepareDatabase(UniquecodeContext context)
        {
            // 
            context.Database.Migrate();
        }
    }
}
