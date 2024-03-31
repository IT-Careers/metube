namespace MeTube.Data.Util;

public static class ConnectionStringBuilder
{
    public static string BuildConnectionString()
    {
        var dbHostUrl = Environment.GetEnvironmentVariable("DB_HOST_URL");
        var dbPort = Environment.GetEnvironmentVariable("DB_PORT");
        var dbDatabase = Environment.GetEnvironmentVariable("DB_DATABASE");
        var dbUser = Environment.GetEnvironmentVariable("DB_USER");
        var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");

        if(dbHostUrl == null || dbPort == null || dbDatabase == null || dbUser == null || dbPassword == null)
        {
            return null;
        }

        return $"Server={dbHostUrl};Port={dbPort};Database={dbDatabase};User Id={dbUser};Password={dbPassword};";
    }
}
