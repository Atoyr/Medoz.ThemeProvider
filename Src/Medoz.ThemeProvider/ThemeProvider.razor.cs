namespace Medoz.ThemeProvider;
using System;
using Microsoft.AspNetCore.Components;

public partial class ThemeProvider : ComponentBase
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public Theme? Theme { get; set; }
}
