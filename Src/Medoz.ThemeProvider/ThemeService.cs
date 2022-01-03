namespace Medoz.ThemeProvider;
using System;
using System.Linq;
using System.Collections.Generic;

public class ThemeService : IThemeService
{
#pragma warning disable CS8618
    public ThemeService()
    {
        Initialize();
    }
#pragma warning restore CS8618
    protected virtual void Initialize()
    {
        _theme = new Theme();
        rootTheme = new Theme();
        themeDictionary = new Dictionary<string, Theme>();
    }
    protected Theme rootTheme { get; set; }
    protected IDictionary<string, Theme> themeDictionary { get; set; }
    private Theme _theme;
    public Theme Theme
    {
        set
        {
            if (value is not null)
            {
                _theme.Copy(value);
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