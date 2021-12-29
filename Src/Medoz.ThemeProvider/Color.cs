namespace Medoz.ThemeProvider;

public class Color
{
    public string ColorCode { get; }
    public string ColorName { get; }

    internal Color(string colorCode, string colorName)
    {
        ColorCode = colorCode;
        ColorName = colorName;
    }

    public static Color Empty() => new Color("","");

    public bool IsEmpty() => string.IsNullOrEmpty(ColorCode) && String.IsNullOrEmpty(ColorName);

#nullable enable
    public override bool Equals(object? obj)
    {
        if (obj is not null && obj is Color target)
        {
            return target.ColorCode == this.ColorCode && target.ColorName == this.ColorName;
        }
        else
        {
            return false;
        }
    }

    // override object.GetHashCode
    public override int GetHashCode()
    {
        // TODO: write your implementation of GetHashCode() here
        return base.GetHashCode();
    }
#nullable disable
}