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

    public bool IsEmpty() => string.IsNullOrEmpty(ColorCode) && String.IsNullOrEmpty(ColorName);

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        return (obj as Color).ColorCode == this.ColorCode && (obj as Color).ColorName == this.ColorName;
    }

    // override object.GetHashCode
    public override int GetHashCode()
    {
        // TODO: write your implementation of GetHashCode() here
        throw new System.NotImplementedException();
        return base.GetHashCode();
    }
}