namespace Medoz.ThemeProvider;
using System;
using System.Text;

public class Theme
{
#pragma warning disable CS8618
    public string Class { get; set; }
    /// <summary>
    /// The theme primary color
    /// </summary>
    public Color Primary { get; set; }

    /// <summary>
    /// The theme primary variant color
    /// </summary>
    public Color PrimaryVariant { get; set; }

    /// <summary>
    /// Text color on top of a primary background
    /// </summary>
    public Color OnPrimary { get; set; }

    /// <summary>
    /// The theme secondary color
    /// </summary>
    public Color Secondary { get; set; }

    /// <summary>
    /// The theme secondary variant color
    /// </summary>
    public Color SecondaryVariant { get; set; }

    /// <summary>
    /// Text color on top of a secondary background
    /// </summary>
    public Color OnSecondary { get; set; }

    /// <summary>
    /// The theme background color
    /// </summary>
    public Color Background { get; set; }

    /// <summary>
    /// Text color on top of a background
    /// </summary>
    public Color OnBackground { get; set; }

    /// <summary>
    /// The theme surface color
    /// </summary>
    public Color Surface { get; set; }

    /// <summary>
    /// Text color on top of a surface background
    /// </summary>
    public Color OnSurface { get; set; }

    /// <summary>
    /// The theme error color
    /// </summary>
    public Color Error { get; set; }

    /// <summary>
    /// Text color on top of a error background
    /// </summary>
    public Color OnError { get; set; }

    public Theme()
    {
        Initialize();
    }
#pragma warning restore CS8618
    protected virtual void Initialize()
    {
        Class = string.Empty;
        Primary = Color.Empty;
        PrimaryVariant = Color.Empty;
        OnPrimary = Color.Empty;
        Secondary = Color.Empty;
        SecondaryVariant = Color.Empty;
        OnSecondary = Color.Empty;
        Background = Color.Empty;
        OnBackground = Color.Empty;
        Surface = Color.Empty;
        OnSurface = Color.Empty;
        Error = Color.Empty;
        OnError = Color.Empty;
    }

    public event EventHandler<EventArgs>? Changed;

    protected virtual string GenerateStyle()
    {
        var sb = new StringBuilder();
        if (!Primary.IsEmpty())
        {
            sb.AppendLine($"--primary: {Primary.ColorCode}; ");
        }
        if (!PrimaryVariant.IsEmpty())
        {
            sb.AppendLine($"--primary-variant {PrimaryVariant.ColorCode}; ");
        }
        if (!OnPrimary.IsEmpty())
        {
            sb.AppendLine($"--on-primary: {OnPrimary.ColorCode}; ");
        }
        if (!Secondary.IsEmpty())
        {
            sb.AppendLine($"--secondary: {Secondary.ColorCode}; ");
        }
        if (!SecondaryVariant.IsEmpty())
        {
            sb.AppendLine($"--secondary-variant {SecondaryVariant.ColorCode}; ");
        }
        if (!OnSecondary.IsEmpty())
        {
            sb.AppendLine($"--on-secondary: {OnSecondary.ColorCode}; ");
        }
        if (!Background.IsEmpty())
        {
            sb.AppendLine($"--background: {Background.ColorCode}; ");
        }
        if (!OnBackground.IsEmpty())
        {
            sb.AppendLine($"--on-background: {OnBackground.ColorCode}; ");
        }
        if (!Surface.IsEmpty())
        {
            sb.AppendLine($"--surface: {Surface.ColorCode}; ");
        }
        if (!OnSurface.IsEmpty())
        {
            sb.AppendLine($"--on-surface: {OnSurface.ColorCode}; ");
        }
        if (!Error.IsEmpty())
        {
            sb.AppendLine($"--error: {Error.ColorCode}; ");
        }
        if (!OnError.IsEmpty())
        {
            sb.AppendLine($"--on-error: {OnError.ColorCode}; ");
        }

        return sb.ToString();
    }

    public string GetStyleTag()
    {
        var sb = new StringBuilder();
        sb.AppendLine("<style>");
        if (string.IsNullOrWhiteSpace(Class))
        {
            sb.AppendLine(":root");
        }
        else
        {
            sb.AppendLine($".{Class.Split(' ')[0]}");
        }
        sb.AppendLine("{");
        sb.AppendLine(GenerateStyle());
        sb.AppendLine("}");
        sb.AppendLine("</style>");
        return sb.ToString();
    }

    public void ThemeHasChanged()
    {
        OnChanged();
    }

    protected virtual void OnChanged()
    {
        Changed?.Invoke(this, EventArgs.Empty);
    }
}