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

        public static class Authentication
        {
            public const string Register = Base + "/auth/register";
            public const string Refresh = Base + "/auth/refresh";
            public const string Logout = Base + "/auth/logout";
            public const string Login = Base + "/auth/login";
        }

        public static class Account
        {
            public const string ChangePassword = Base + "/account/changepassword";
            public const string ForgotPassword = Base + "/account/forgotpassword";
            public const string ResetPassword = Base + "/account/resetpassword";
            public const string ConfirmEmail = Base + "/account/confirmemail";
        }
    }
}
