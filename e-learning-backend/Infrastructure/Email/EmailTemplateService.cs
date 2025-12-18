namespace E_Learning.Infrastructure.Email;

public interface IEmailTemplateService
{
    string RenderHtml(string templateName, IDictionary<string, string> model);
}

/// <summary>
/// Provides functionality for rendering email templates by replacing placeholders in
/// HTML or plain-text template files with dynamic values from a model dictionary.
/// </summary>
/// <remarks>
/// Templates are loaded from the <c>Infrastructure/Email/Templates</c> directory.
/// Placeholders use the format <c>{{Key}}</c>, which are replaced with corresponding values.
/// </remarks>
public class EmailTemplateService : IEmailTemplateService
{
    private readonly string _templatesRoot;

    public EmailTemplateService(IHostEnvironment env)
    {
        _templatesRoot = Path.Combine(env.ContentRootPath, "Infrastructure", "Email", "Templates");
    }

    /// <summary>
    /// Renders an HTML email template by replacing all placeholders with the corresponding values from the model.
    /// </summary>
    /// <param name="templateName">The name of the HTML template file (without the <c>.html</c> extension).</param>
    /// <param name="model">A dictionary containing key-value pairs used to replace placeholders in the template.</param>
    /// <returns>The rendered HTML content as a string.</returns>
    public string RenderHtml(string templateName, IDictionary<string, string> model)
        => Render(Path.Combine(_templatesRoot, templateName + ".html"), model);


    /// <summary>
    /// Reads the specified template file and replaces all placeholders in the format <c>{{Key}}</c>
    /// with their corresponding values from the provided model.
    /// </summary>
    /// <param name="path">The full file system path to the template file.</param>
    /// <param name="model">A dictionary containing placeholder keys and their replacement values.</param>
    /// <returns>The fully rendered template content as a string.</returns>
    /// <remarks>
    /// Any placeholder without a matching key in the model will be replaced with an empty string.
    /// </remarks>
    private static string Render(string path, IDictionary<string, string> model)
    {
        var content = File.ReadAllText(path);
        foreach (var kv in model)
        {
            content = content.Replace("{{" + kv.Key + "}}", kv.Value ?? string.Empty);
        }

        return content;
    }
}