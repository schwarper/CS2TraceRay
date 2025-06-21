using System.Numerics;
using System.Runtime.InteropServices;

namespace CS2TraceRay.Struct;

/// <summary>
/// Represents a cylindrical line used in trace or collision tests.
/// Defined by a starting offset and a radius around the path.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct Line
{
    /// <summary>
    /// The offset from the origin to the start point of the line.
    /// </summary>
    public Vector3 StartOffset;

    /// <summary>
    /// The radius of the line used to simulate thickness (e.g., swept sphere or capsule).
    /// </summary>
    public float Radius;
}