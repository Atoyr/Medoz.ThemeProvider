using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using Medoz.ThemeProvider;

namespace Medoz.ThemeProvider.Test.Pages;

public partial class Index : ComponentBase
{
    [CascadingParameter]
    public Theme Theme { get; set; }

    protected string Style(Color tc, Color bg)
    {
        return $"display: flex; flex: 0 0 20%; color: {tc.ColorCode}; background: {bg.ColorCode}; min-width: 20px; min-height: 20px;";
    }

}