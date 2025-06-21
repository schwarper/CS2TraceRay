using System.Numerics;
using System.Runtime.InteropServices;

namespace CS2TraceRay.Struct;

/// <summary>
/// Represents a 3D capsule shape defined by two centers and a radius.
/// Commonly used in collision detection and physics systems.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct Capsule
{
    /// <summary>
    /// The center point of one end of the capsule.
    /// </summary>
    public Vector3 CenterA;

    /// <summary>
    /// The center point of the opposite end of the capsule.
    /// </summary>
    public Vector3 CenterB;

    /// <summary>
    /// The radius of the capsule.
    /// </summary>
    public float Radius;
}