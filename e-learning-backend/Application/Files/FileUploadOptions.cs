namespace e_learning_backend.Application.Files;

/// <summary>
/// Provides configuration options related to file uploads within the application.
/// </summary>
/// <remarks>
/// These values are automatically bound from the <c>FileUpload</c> section 
/// of the <c>appsettings.json</c> configuration file.
/// <para>
/// During application startup, the <see cref="RootPath"/> property is also set 
/// dynamically in <c>Program.cs</c> using the computed <c>uploadsPath</c> value.
/// </para>
/// <para>
/// Example configuration in <c>appsettings.json</c>:
/// </para>
/// <code lang="json">
/// "FileUpload": {
///   "RootPath": "wwwroot/uploads",
///   "MaxBytes": 52428800
/// }
/// </code>
/// <para>
/// In <c>Program.cs</c>, this configuration is registered as follows:
/// </para>
/// <code lang="csharp">
/// // --------------------------------------------------------------------------------------------------------
/// // FILE UPLOAD CONFIGURATION
/// // --------------------------------------------------------------------------------------------------------
/// builder.Services.Configure&lt;FileUploadOptions&gt;(builder.Configuration.GetSection("FileUpload"));
/// builder.Services.PostConfigure&lt;FileUploadOptions&gt;(opts =&gt; opts.RootPath = uploadsPath);
/// </code>
/// </remarks>
public class FileUploadOptions
{
    /// <summary>
    /// Gets or sets the absolute physical path of the directory
    /// where uploaded files are stored (for example, <c>wwwroot/uploads</c>).
    /// </summary>
    public string RootPath { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the maximum size (in bytes) allowed for a single uploaded file.
    /// </summary>
    /// <remarks>
    /// Example: <c>52428800</c> bytes = <c>50 MB</c>.
    /// </remarks>
    public long MaxBytes { get; set; }
}