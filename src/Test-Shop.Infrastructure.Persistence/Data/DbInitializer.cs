namespace Test_Shop.Infrastructure.Persistence.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context) =>
            context.Database.EnsureCreated();
    }
}
