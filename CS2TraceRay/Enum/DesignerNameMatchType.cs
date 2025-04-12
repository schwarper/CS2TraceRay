namespace CS2TraceRay.Enum;

/// <summary>
/// Specifies the type of matching to perform on the designer name.
/// </summary>
public enum DesignerNameMatchType
{
    /// <summary>
    /// Matches if the designer name is exactly equal to the specified string.
    /// </summary>
    Equals,

    /// <summary>
    /// Matches if the designer name starts with the specified string.
    /// </summary>
    StartsWith,

    /// <summary>
    /// Matches if the designer name ends with the specified string.
    /// </summary>
    EndsWith
}
