namespace BowlingGame
{
    public class ConfigurationService
    {
        public static IConfigurationRoot Configuration
        {
            get
            {
                var environmentName = Environment.GetEnvironmentVariable("DOTNETCORE_ENVIRONMENT");
                var builder = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{environmentName}.json", optional: true);
                return builder.Build();
            }
        }

    }
}
