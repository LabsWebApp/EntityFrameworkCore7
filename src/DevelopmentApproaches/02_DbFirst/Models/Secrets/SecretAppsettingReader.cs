using Microsoft.Extensions.Configuration;

namespace DbFirst.Models.Secrets;

/*
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder
            .UseSqlite(SecretAppSettingReader
                .ReadSection<SecretValues, DataContext>("Secrets")!
                .ConnectionString);
*/

internal static class SecretAppSettingReader
{
    internal static T? ReadSection<T, TClass>(string sectionName) where TClass : class
    {
        var builder = new ConfigurationBuilder()
            .AddUserSecrets<TClass>()
            .AddEnvironmentVariables();
        var configurationRoot = builder.Build();

        return configurationRoot.GetSection(sectionName).Get<T>();
    }
}