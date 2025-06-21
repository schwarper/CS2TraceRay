using System.Numerics;
using System.Runtime.InteropServices;
using System;

namespace CS2TraceRay.Struct;

[StructLayout(LayoutKind.Explicit)]
public struct Ray
{
    [FieldOffset(0)] public Line Line;
    [FieldOffset(0)] public Sphere Sphere;
    [FieldOffset(0)] public Hull Hull;
    [FieldOffset(0)] public Capsule Capsule;
    [FieldOffset(0)] public Mesh Mesh;

    // To do find the correct offset for Type
    [FieldOffset(64)] public RayType Type;

    public Ray(Vector3 startOffset)
    {
        this = default;
        Line = new Line { StartOffset = startOffset, Radius = 0f };
        Type = RayType.Line;
    }

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