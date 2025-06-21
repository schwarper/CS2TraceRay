using System.Numerics;
using System.Runtime.InteropServices;

namespace CS2TraceRay.Struct;

[StructLayout(LayoutKind.Sequential)]
public struct Hull
{
    public Vector3 Mins;
    public Vector3 Maxs;
}