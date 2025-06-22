using System.Numerics;
using System.Runtime.InteropServices;

namespace CS2TraceRay.Struct;

/// <summary>
/// Represents a sphere used for spatial queries or collision detection.
/// Defined by its center position and radius.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct Sphere
{
    /// <summary>
    /// The center point of the sphere in world or local space.
    /// </summary>
    public Vector3 Center;

    /// <summary>
    /// The radius of the sphere.
    /// </summary>
    public float Radius;
}
