namespace Medoz.ThemeProvider;
using System;
using Microsoft.AspNetCore.Components;

public partial class ThemeProvider : ComponentBase
{
#nullable enable
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    private Theme? _theme;
    [Parameter]
    public Theme? Theme
    {
        get => _theme;
        set
        {
            if (_theme == value)
            {
                return;
            }

            if (_theme != null)
            {
                _theme.Changed -= OnThemeChanged;
            }

            _theme = value;

            if (_theme != null)
            {
                _theme.Changed += OnThemeChanged;
            }
        }
    }
#nullable disable
    private void OnThemeChanged(object sender, System.EventArgs e)
    {
        this.StateHasChanged();
    }

    public void Dispose()
    {
        if (_theme != null)
        {
            _theme.Changed -= OnThemeChanged;
        }
    }
}
