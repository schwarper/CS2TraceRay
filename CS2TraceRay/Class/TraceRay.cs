using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Memory;
using CounterStrikeSharp.API.Modules.Utils;
using System;
using System.Runtime.InteropServices;

namespace CS2TraceRay.Class;

/// <summary>
/// Provides static methods for performing trace operations in CS2.
/// </summary>
public static unsafe partial class TraceRay
{
    private static readonly IntPtr TraceFunc = NativeAPI.FindSignature(Addresses.ServerPath, GameData.GetSignature("TraceFunc"));
    private static readonly IntPtr GameTraceManager = NativeAPI.FindSignature(Addresses.ServerPath, GameData.GetSignature("GameTraceManager"));
    private static readonly TraceShapeDelegate _traceShape = Marshal.GetDelegateForFunctionPointer<TraceShapeDelegate>(TraceFunc);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate bool TraceShapeDelegate(
        IntPtr GameTraceManager,
        IntPtr vecStart,
        IntPtr vecEnd,
        IntPtr skip,
        ulong mask,
        ulong content,
        CGameTrace* pGameTrace
    );

    /// <summary>
    /// Performs a trace from origin in the direction of angle with specified mask and content flags
    /// </summary>
    /// <param name="origin">Starting position of the trace</param>
    /// <param name="angle">Direction of the trace</param>
    /// <param name="mask">Trace mask flags as ulong</param>
    /// <param name="content">Content flags as ulong</param>
    /// <param name="skip">Entity to skip (IntPtr handle)</param>
    /// <returns>CGameTrace containing the trace results</returns>
    public static CGameTrace TraceShape(Vector origin, QAngle angle, ulong mask, ulong content, IntPtr skip)
    {
        Vector _forward = new();
        NativeAPI.AngleVectors(angle.Handle, _forward.Handle, 0, 0);
        Vector _endOrigin = new(origin.X + _forward.X * 8192, origin.Y + _forward.Y * 8192, origin.Z + _forward.Z * 8192);

        return TraceShape(origin, _endOrigin, mask, content, skip);
    }

    /// <summary>
    /// Performs a trace from origin to end with specified mask and content flags
    /// </summary>
    /// <param name="origin">Starting position of the trace</param>
    /// <param name="end">Ending position of the trace</param>
    /// <param name="mask">Trace mask flags as ulong</param>
    /// <param name="content">Content flags as ulong</param>
    /// <param name="skip">Entity to skip (IntPtr handle)</param>
    /// <returns>CGameTrace containing the trace results</returns>
    public static CGameTrace TraceShape(Vector origin, Vector end, ulong mask, ulong content, IntPtr skip)
    {
        CGameTrace* _trace = stackalloc CGameTrace[1];
        IntPtr _gameTraceManagerAddress = Address.GetAbsoluteAddress(GameTraceManager, 3, 7);

        _traceShape(*(IntPtr*)_gameTraceManagerAddress, origin.Handle, end.Handle, skip, mask, content, _trace);

        return *_trace;
    }
}