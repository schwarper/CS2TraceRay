using System.Numerics;
using System.Runtime.InteropServices;

namespace CS2TraceRay.Struct;

/// <summary>
/// Represents an axis-aligned bounding box (AABB) used for spatial queries and collision detection.
/// Defined by minimum and maximum 3D coordinates.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct Hull
{
    /// <summary>
    /// The minimum corner of the bounding box (usually the lowest x, y, z values).
    /// </summary>
    public Vector3 Mins;

    /// <summary>
    /// The maximum corner of the bounding box (usually the highest x, y, z values).
    /// </summary>
    public Vector3 Maxs;
}