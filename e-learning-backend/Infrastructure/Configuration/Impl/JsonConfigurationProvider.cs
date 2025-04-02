namespace e_learning_backend.Infrastructure.Configuration.Impl;

public class JsonConfigurationProvider : IJsonConfigurationProvider
{
    private readonly IConfiguration _configuration;
    private const string Filename = "appsettings.json";

    public JsonConfigurationProvider()
    {
        _configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile(Filename, optional: false, reloadOnChange: true)
            .Build();
    }

    public T GetConfig<T>(string section)
    {
        return _configuration
            .GetSection(section)
            .Get<T>() ?? throw new InvalidOperationException($"Section '{section}' not found.");
    }
}