namespace Medoz.ThemeProvider;
using System;
using System.Linq;
using System.Collections.Generic;

public class ThemeService : IThemeService
{
    public ThemeService()
    {
        Initialize();
    }

    protected virtual void Initialize()
    {
        _theme = new Theme();
        rootTheme = new Theme();
        themeDictionary = new Dictionary<string, Theme>();
    }
#pragma warning disable CS8618
    protected Theme rootTheme { get; set; }
    protected IDictionary<string, Theme> themeDictionary { get; set; }
    private Theme _theme;
#pragma warning restore CS8618
    public Theme Theme
    {
        set
        {
            if (value is not null)
            {
                _theme.Class = value.Class;
                _theme.Primary = value.Primary;
                _theme.PrimaryVariant = value.PrimaryVariant;
                _theme.OnPrimary = value.OnPrimary;
                _theme.Secondary = value.Secondary;
                _theme.SecondaryVariant = value.SecondaryVariant;
                _theme.OnSecondary = value.OnSecondary;
                _theme.Background = value.Background;
                _theme.OnBackground = value.OnBackground;
                _theme.Surface = value.Surface;
                _theme.OnSurface = value.OnSurface;
                _theme.Error = value.Error;
                _theme.OnError = value.OnError;
            }
            else
            {
                _theme.Class = string.Empty;
                _theme.Primary = Color.Empty;
                _theme.PrimaryVariant = Color.Empty;
                _theme.OnPrimary = Color.Empty;
                _theme.Secondary = Color.Empty;
                _theme.SecondaryVariant = Color.Empty;
                _theme.OnSecondary = Color.Empty;
                _theme.Background = Color.Empty;
                _theme.OnBackground = Color.Empty;
                _theme.Surface = Color.Empty;
                _theme.OnSurface = Color.Empty;
                _theme.Error = Color.Empty;
                _theme.OnError = Color.Empty;
            }
            _theme.ThemeHasChanged();
        }
        get => _theme;
    }

    public void AddTheme(Theme theme)
    {
        if (string.IsNullOrEmpty(theme.Class))
        {
            rootTheme = theme;
        }
        else
        {
            themeDictionary[theme.Class] = theme;
        }
    }

    public Theme GetTheme(string themeName)
    {
        if (string.IsNullOrEmpty(themeName) || !themeDictionary.Any(x => x.Key == themeName))
        {
            return rootTheme;
        }
        return themeDictionary[themeName];
    }

    public void ApplyTheme(string themeName)
    {
        Theme = GetTheme(themeName);
    }
}