using System.Numerics;
using System.Runtime.InteropServices;
using System;

namespace CS2TraceRay.Struct;

/// <summary>
/// Represents a 3D mesh consisting of a set of vertices and bounding box information.
/// Often used in complex collision or trace geometry.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct Mesh
{
    /// <summary>
    /// The minimum bounding coordinates (AABB) of the mesh.
    /// </summary>
    public Vector3 Mins;

    /// <summary>
    /// The maximum bounding coordinates (AABB) of the mesh.
    /// </summary>
    public Vector3 Maxs;

    /// <summary>
    /// Pointer to an array of vertices in memory.
    /// Each vertex is typically a Vector3 or a custom vertex format.
    /// </summary>
    public IntPtr Vertices;

    /// <summary>
    /// Number of vertices in the mesh.
    /// </summary>
    public int NumVertices;
}