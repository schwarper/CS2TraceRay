namespace CS2TraceRay.Enum;

/// <summary>
/// Defines base layer indices used for collision detection and tracing
/// </summary>
public enum LayerIndex
{
    /// <summary>Solid objects layer</summary>
    Solid = 0,

    /// <summary>Hitbox collision layer</summary>
    Hitbox,

    /// <summary>Trigger volume layer</summary>
    Trigger,

    /// <summary>Skybox layer</summary>
    Sky,

    /// <summary>First available layer for user-defined content</summary>
    FirstUser,

    /// <summary>Special value indicating layer not found</summary>
    NotFound = -1,

    /// <summary>Maximum allowed layer index</summary>
    MaxAllowed = 64
}