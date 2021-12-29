namespace Medoz.ThemeProvider;
using System;
using System.Text;

public class Theme
{
    /// <summary>
    /// The theme primary color
    /// </summary>
    public Color Primary { get; set; } = Color.Empty();

    /// <summary>
    /// The theme primary variant color
    /// </summary>
    public Color PrimaryVariant { get; set; } = Color.Empty();

    /// <summary>
    /// Text color on top of a primary background
    /// </summary>
    public Color OnPrimary { get; set; } = Color.Empty();

    /// <summary>
    /// The theme secondary color
    /// </summary>
    public Color Secondary { get; set; } = Color.Empty();

    /// <summary>
    /// The theme secondary variant color
    /// </summary>
    public Color SecondaryVariant { get; set; } = Color.Empty();

    /// <summary>
    /// Text color on top of a secondary background
    /// </summary>
    public Color OnSecondary { get; set; } = Color.Empty();

    /// <summary>
    /// The theme background color
    /// </summary>
    public Color Background { get; set; } = Color.Empty();

    /// <summary>
    /// Text color on top of a background
    /// </summary>
    public Color OnBackground { get; set; } = Color.Empty();

    /// <summary>
    /// The theme surface color
    /// </summary>
    public Color Surface { get; set; } = Color.Empty();

    /// <summary>
    /// Text color on top of a surface background
    /// </summary>
    public Color OnSurface { get; set; } = Color.Empty();

    /// <summary>
    /// The theme error color
    /// </summary>
    public Color Error { get; set; } = Color.Empty();

    /// <summary>
    /// Text color on top of a error background
    /// </summary>
    public Color OnError { get; set; } = Color.Empty();

    public Theme() { }

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
        sb.AppendLine(":root");
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