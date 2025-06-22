using System;
using System.Numerics;
using System.Runtime.InteropServices;
using CS2TraceRay.Enum;

namespace CS2TraceRay.Struct;

/// <summary>
/// Represents a polymorphic ray shape used in spatial queries and collision detection.
/// This structure can represent a line, sphere, hull (AABB), capsule, or mesh—depending on the constructor used.
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public struct Ray
{
    /// <summary>
    /// The ray data interpreted as a line.
    /// </summary>
    [FieldOffset(0)] public Line Line;

    /// <summary>
    /// The ray data interpreted as a sphere.
    /// </summary>
    [FieldOffset(0)] public Sphere Sphere;

    /// <summary>
    /// The ray data interpreted as an axis-aligned bounding box (AABB).
    /// </summary>
    [FieldOffset(0)] public Hull Hull;

    /// <summary>
    /// The ray data interpreted as a capsule.
    /// </summary>
    [FieldOffset(0)] public Capsule Capsule;

    /// <summary>
    /// The ray data interpreted as a mesh with custom vertices.
    /// </summary>
    [FieldOffset(0)] public Mesh Mesh;

    /// <summary>
    /// The active ray shape type, used to determine how the union should be interpreted.
    /// </summary>
    [FieldOffset(40)] public RayType Type;

    /// <summary>
    /// Initializes a ray as a simple line with no radius.
    /// </summary>
    /// <param name="startOffset">The start offset of the line from the origin.</param>
    public Ray(Vector3 startOffset)
    {
        this = default;
        Line = new Line { StartOffset = startOffset, Radius = 0f };
        Type = RayType.Line;
    }

    /// <summary>
    /// Initializes a ray as a sphere if the radius is positive, otherwise defaults to a line.
    /// </summary>
    /// <param name="center">Center of the sphere or line.</param>
    /// <param name="radius">Radius of the sphere.</param>
    public Ray(Vector3 center, float radius)
    {
        this = default;
        if (radius > 0f)
        {
            Sphere = new Sphere { Center = center, Radius = radius };
            Type = RayType.Sphere;
        }
        else
        {
            Line = new Line { StartOffset = center, Radius = 0f };
            Type = RayType.Line;
        }
    }

    /// <summary>
    /// Initializes a ray as a hull (AABB) if bounds are not equal, otherwise defaults to a line.
    /// </summary>
    /// <param name="mins">Minimum bounding box coordinates.</param>
    /// <param name="maxs">Maximum bounding box coordinates.</param>
    public Ray(Vector3 mins, Vector3 maxs)
    {
        this = default;
        if (mins != maxs)
        {
            Hull = new Hull { Mins = mins, Maxs = maxs };
            Type = RayType.Hull;
        }
        else
        {
            Line = new Line { StartOffset = mins, Radius = 0f };
            Type = RayType.Line;
        }
    }

    /// <summary>
    /// Initializes a ray as a capsule if the endpoints are distinct and the radius is positive; otherwise falls back to simpler shapes.
    /// </summary>
    /// <param name="centerA">First endpoint of the capsule.</param>
    /// <param name="centerB">Second endpoint of the capsule.</param>
    /// <param name="radius">Radius of the capsule.</param>
    public Ray(Vector3 centerA, Vector3 centerB, float radius)
    {
        this = default;
        if (centerA != centerB)
        {
            if (radius > 0f)
            {
                Capsule = new Capsule { CenterA = centerA, CenterB = centerB, Radius = radius };
                Type = RayType.Capsule;
            }
            else
            {
                Line = new Line { StartOffset = centerA, Radius = 0f };
                Type = RayType.Line;
            }
        }
        else
        {
            this = new Ray(centerA, radius);
        }
    }

    /// <summary>
    /// Initializes a ray as a mesh with custom vertex data.
    /// </summary>
    /// <param name="mins">Minimum bounding box coordinates of the mesh.</param>
    /// <param name="maxs">Maximum bounding box coordinates of the mesh.</param>
    /// <param name="vertices">An array of 3D vertices representing the mesh.</param>
    public Ray(Vector3 mins, Vector3 maxs, Vector3[] vertices)
    {
        this = default;
        unsafe
        {
            fixed (Vector3* ptr = vertices)
            {
                Mesh = new Mesh
                {
                    Mins = mins,
                    Maxs = maxs,
                    Vertices = (IntPtr)ptr,
                    NumVertices = vertices.Length
                };
                Type = RayType.Mesh;
            }
        }
    }
}
