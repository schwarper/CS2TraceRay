using System.Numerics;
using System.Runtime.InteropServices;

namespace CS2TraceRay.Struct;

[StructLayout(LayoutKind.Sequential)]
public struct Sphere
{
    public Vector3 Center;
    public float Radius;
}