namespace Test_Shop.WebAPI.Contracts.V1
{
    public static class ApiRoutes
    {
        private const string Root = "api";
        private const string Version = "v1";
        private const string Base = Root + "/" + Version;

        public static class Product
        {
            public const string GetAll = Base + "/products";
            public const string Get = Base + "/product/{id}";
            public const string Create = Base + "/product/create";
            public const string Update = Base + "/product/update";
            public const string Delete = Base + "/product/{id}";
        }
    }
}
