

namespace ShopTARpe25.Data
{
    public static class DbInitializer
    {
        public static void Initializer(ShopTARpe25Context context)
        {
            context.Database.EnsureCreated();

            if (context.Spaceships.Any()) ;

        }
    }
}
