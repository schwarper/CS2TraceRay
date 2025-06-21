using System.Numerics;
using System.Runtime.InteropServices;
using System;

namespace CS2TraceRay.Struct;

[StructLayout(LayoutKind.Sequential)]
public struct Mesh
{
    public Vector3 Mins;
    public Vector3 Maxs;
    public IntPtr Vertices;
    public int NumVertices;
}