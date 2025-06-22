namespace CS2TraceRay.Enum;

/// <summary>
/// Specifies the geometric shape of a ray used in tracing and collision detection operations.
/// Determines how the underlying ray data should be interpreted during a trace.
/// </summary>
public enum RayType
{
    /// <summary>
    /// A straight line with optional thickness (radius). Default shape for basic traces.
    /// </summary>
    Line,

    /// <summary>
    /// A spherical shape used for proximity or point-radius-based traces.
    /// </summary>
    Sphere,

    /// <summary>
    /// An axis-aligned bounding box (AABB) used for volume-based tracing.
    /// </summary>
    Hull,

    /// <summary>
    /// A capsule shape defined by two points and a radius. Suitable for player bounding volumes.
    /// </summary>
    Capsule,

    /// <summary>
    /// A custom mesh composed of multiple vertices for complex trace geometry.
    /// </summary>
    Mesh
}