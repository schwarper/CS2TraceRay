using System;

namespace CS2TraceRay.Class;

internal static class Address
{
    public static unsafe nint GetAbsoluteAddress(nint addr, nint offset, int size)
    {
        if (addr == IntPtr.Zero)
            throw new Exception("Failed to find RayTrace signature.");

        int code = *(int*)(addr + offset);
        return addr + code + size;
    }
}