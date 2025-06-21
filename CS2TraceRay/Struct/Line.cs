using System.Numerics;
using System.Runtime.InteropServices;

namespace CS2TraceRay.Struct;

[StructLayout(LayoutKind.Sequential)]
public struct Line
{
    public Vector3 StartOffset;
    public float Radius;
}