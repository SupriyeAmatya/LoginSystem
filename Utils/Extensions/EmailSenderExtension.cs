using Login.Data.Configurations;

namespace Login.Utils.Extensions
{
    public static class EmailSenderExtension
    {
        public static void ConfigureEmailSender(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            var emailConfig = configuration
                .GetSection("EmailConfiguration")
                .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);
        }
    }
}
