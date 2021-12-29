namespace Medoz.ThemeProvider;
using System;

public class Theme
{
    public string DefaultForeground { get; set; }
    public string DefaultBackground { get; set; }
    public string SurfaceForeground { get; set; }
    public string SurfaceBackground { get; set; }
    public string PrimaryForeground { get; set; }
    public string PrimaryVariantForeground { get; set; }
    public string SecondaryForeground { get; set; }
    public string SecondaryVariantForeground { get; set; }
    public string PrimaryBackground { get; set; }
    public string PrimaryVariantBackground { get; set; }
    public string SecondaryBackground { get; set; }
    public string SecondaryVariantBackground { get; set; }

    public string Success { get; set; }
    public string Info { get; set; }
    public string Warning { get; set; }
    public string Error { get; set; }

    public Theme() { }
}