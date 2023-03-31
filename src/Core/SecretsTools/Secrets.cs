using SecretsTools.Secret;

namespace SecretsTools;

public static class Secrets
{
    public static string? Get<T>(SecretValue secret) where T:class
    {
        var secretAppSettingReader = new SecretAppSettingReader();
        var secretValues = secretAppSettingReader.ReadSection<SecretValues, T>("Movies");
        return secret switch
        {
            SecretValue.ConnectionString => secretValues!.ConnectionString,
            SecretValue.FirstAdminPassword => secretValues!.FirstAdminPassword,
            _ => null,
        };
    }
}