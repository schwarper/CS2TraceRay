using System;

namespace CS2TraceRay.Class;

internal static class Address
{
    public static unsafe IntPtr GetAbsoluteAddress(IntPtr addr, IntPtr offset, int size)
    {
        if (addr == IntPtr.Zero)
            throw new Exception("Failed to find RayTrace signature.");

        int code = *(int*)(addr + offset);
        return addr + code + size;
    }
}