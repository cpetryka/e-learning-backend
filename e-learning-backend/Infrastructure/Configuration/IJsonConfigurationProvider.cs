namespace e_learning_backend.Infrastructure.Configuration;

public interface IJsonConfigurationProvider
{
    T GetConfig<T>(string section);
}