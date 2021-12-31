namespace Medoz.ThemeProvider;
using System;
using System.Linq;
using System.Collections.Generic;

public interface IThemeService
{
    public Theme Theme { get; set; }
    public void AddTheme(Theme theme);
    public Theme GetTheme(string className);
    public void ApplyTheme(string className);
}