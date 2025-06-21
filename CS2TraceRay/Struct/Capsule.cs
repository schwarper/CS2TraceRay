using System.Numerics;
using System.Runtime.InteropServices;

namespace CS2TraceRay.Struct;

[StructLayout(LayoutKind.Sequential)]
public struct Capsule
{
    public Vector3 CenterA;
    public Vector3 CenterB;
    public float Radius;
}