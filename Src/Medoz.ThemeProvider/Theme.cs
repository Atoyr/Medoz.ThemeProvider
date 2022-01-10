namespace Medoz.ThemeProvider;
using System;
using System.Text;
using System.Text.RegularExpressions;

public class Theme
{
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

    private const string DEFAULT_PRIMARY_CLASS_NAME = "theme__primary";
    private string _primaryClassName = DEFAULT_PRIMARY_CLASS_NAME;
    public string PrimaryClassName
    {
        get => _primaryClassName;
        set
        {
            if(string.IsNullOrEmpty(value))
            {
                _primaryClassName = DEFAULT_PRIMARY_CLASS_NAME;
            }
            else if (hasSpace(value))
            {
                throw new Exception();
            }
            else
            {
                _primaryClassName = value;
            }
        }
    }

    private const string DEFAULT_PRIMARY_VARIANT_CLASS_NAME = "theme__primary-variant";
    private string _primaryVariantClassName = DEFAULT_PRIMARY_VARIANT_CLASS_NAME;
    public string PrimaryVariantClassName
    {
        get => _primaryVariantClassName;
        set
        {
            if(string.IsNullOrEmpty(value))
            {
                _primaryVariantClassName = DEFAULT_PRIMARY_VARIANT_CLASS_NAME;
            }
            else if (hasSpace(value))
            {
                throw new Exception();
            }
            else
            {
                _primaryVariantClassName = value;
            }
        }
    }

    private const string DEFAULT_SECONDARY_CLASS_NAME = "theme__secondary";
    private string _secondaryClassName = DEFAULT_SECONDARY_CLASS_NAME;
    public string SecondaryClassName
    {
        get => _secondaryClassName;
        set
        {
            if(string.IsNullOrEmpty(value))
            {
                _secondaryClassName = DEFAULT_SECONDARY_CLASS_NAME;
            }
            else if (hasSpace(value))
            {
                throw new Exception();
            }
            else
            {
                _secondaryClassName = value;
            }
        }
    }

    private const string DEFAULT_SECONDARY_VARIANT_CLASS_NAME = "theme__secondary-variant";
    private string _secondaryVariantClassName = DEFAULT_SECONDARY_VARIANT_CLASS_NAME;
    public string SecondaryVariantClassName
    {
        get => _secondaryVariantClassName;
        set
        {
            if(string.IsNullOrEmpty(value))
            {
                _secondaryVariantClassName = DEFAULT_SECONDARY_VARIANT_CLASS_NAME;
            }
            else if (hasSpace(value))
            {
                throw new Exception();
            }
            else
            {
                _secondaryVariantClassName = value;
            }
        }
    }

    private const string DEFAULT_BACKGROUND_CLASS_NAME = "theme__surface";
    private string _backgroundClassName = DEFAULT_BACKGROUND_CLASS_NAME;
    public string BackgroundClassName
    {
        get => _backgroundClassName;
        set
        {
            if(string.IsNullOrEmpty(value))
            {
                _backgroundClassName = DEFAULT_BACKGROUND_CLASS_NAME;
            }
            else if (hasSpace(value))
            {
                throw new Exception();
            }
            else
            {
                _backgroundClassName = value;
            }
        }
    }

    private const string DEFAULT_SURFACE_CLASS_NAME = "theme__surface";
    private string _surfaceClassName = DEFAULT_SURFACE_CLASS_NAME;
    public string SurfaceClassName
    {
        get => _surfaceClassName;
        set
        {
            if(string.IsNullOrEmpty(value))
            {
                _surfaceClassName = DEFAULT_SURFACE_CLASS_NAME;
            }
            else if (hasSpace(value))
            {
                throw new Exception();
            }
            else
            {
                _surfaceClassName = value;
            }
        }
    }

    private const string DEFAULT_ERROR_CLASS_NAME = "theme__error";
    private string _errorClassName = DEFAULT_ERROR_CLASS_NAME;
    public string ErrorClassName
    {
        get => _errorClassName;
        set
        {
            if(string.IsNullOrEmpty(value))
            {
                _errorClassName = DEFAULT_ERROR_CLASS_NAME;
            }
            else if (hasSpace(value))
            {
                throw new Exception();
            }
            else
            {
                _errorClassName = value;
            }
        }
    }
#pragma warning disable CS8618
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
            sb.AppendLine($"--primary-variant: {PrimaryVariant.ColorCode}; ");
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
            sb.AppendLine($"--secondary-variant: {SecondaryVariant.ColorCode}; ");
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

    protected virtual string GenerateCssClass()
    {
        var sb = new StringBuilder();
        sb.Append(GenerateCssClass(PrimaryClassName, Primary.IsEmpty() ? string.Empty : "--primary", OnPrimary.IsEmpty() ? string.Empty : "--on-primary"));
        sb.Append(GenerateCssClass(PrimaryVariantClassName, PrimaryVariant.IsEmpty() ? string.Empty : "--primary-variant", OnPrimary.IsEmpty() ? string.Empty : "--on-primary-variant"));
        sb.Append(GenerateCssClass(SecondaryClassName, Secondary.IsEmpty() ? string.Empty : "--secondary", OnSecondary.IsEmpty() ? string.Empty : "--on-secondary"));
        sb.Append(GenerateCssClass(SecondaryVariantClassName, SecondaryVariant.IsEmpty() ? string.Empty : "--secondary-variant", OnSecondary.IsEmpty() ? string.Empty : "--on-secondary-variant"));
        sb.Append(GenerateCssClass(BackgroundClassName, Background.IsEmpty() ? string.Empty : "--background", OnBackground.IsEmpty() ? string.Empty : "--on-background"));
        sb.Append(GenerateCssClass(SurfaceClassName, Surface.IsEmpty() ? string.Empty : "--surface", OnSurface.IsEmpty() ? string.Empty : "--on-surface"));
        sb.Append(GenerateCssClass(ErrorClassName, Error.IsEmpty() ? string.Empty : "--error", OnError.IsEmpty() ? string.Empty : "--on-error"));
        return sb.ToString();
    }

    protected virtual string GenerateCssClass(string className, string backgroundVarName, string foregroundVarName)
    {
        var sb = new StringBuilder();
        if (!string.IsNullOrEmpty(className) && !(string.IsNullOrEmpty(backgroundVarName) && string.IsNullOrEmpty(foregroundVarName)))
        {
            sb.Append($".{className} ");
            sb.AppendLine("{");
            if (!string.IsNullOrEmpty(backgroundVarName))
            {
                sb.AppendLine($"background-color : var({backgroundVarName});");
            }
            if (!string.IsNullOrEmpty(foregroundVarName))
            {
                sb.AppendLine($"color : var({foregroundVarName});");
            }
            sb.AppendLine("}");
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
        sb.AppendLine(GenerateCssClass());
        sb.AppendLine("</style>");
        return sb.ToString();
    }

    public void ThemeHasChanged()
    {
        OnChanged();
    }

    public void Copy(Theme from)
    {
        this.Class = from.Class;
        this.Primary = from.Primary;
        this.PrimaryVariant = from.PrimaryVariant;
        this.OnPrimary = from.OnPrimary;
        this.Secondary = from.Secondary;
        this.SecondaryVariant = from.SecondaryVariant;
        this.OnSecondary = from.OnSecondary;
        this.Background = from.Background;
        this.OnBackground = from.OnBackground;
        this.Surface = from.Surface;
        this.OnSurface = from.OnSurface;
        this.Error = from.Error;
        this.OnError = from.OnError;
    }

    protected virtual void OnChanged()
    {
        Changed?.Invoke(this, EventArgs.Empty);
    }

    private bool hasSpace(string value) => Regex.Match(value, " ").Success;
}