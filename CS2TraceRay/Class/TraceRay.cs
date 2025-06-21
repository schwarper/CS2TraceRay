using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Memory;
using CounterStrikeSharp.API.Modules.Utils;
using CS2TraceRay.Struct;
using System;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace CS2TraceRay.Class;

/// <summary>
/// Provides static methods for performing trace operations in CS2.
/// </summary>
public static unsafe partial class TraceRay
{
    private static readonly IntPtr TraceFunc;
    private static readonly IntPtr CTraceFilterVtable;
    private static readonly IntPtr GameTraceManager;
    private static readonly TraceShapeDelegate _traceShape;
    private static readonly TraceShapeRayFilterDelegate _traceShapeRayFilter;

    static TraceRay()
    {
        TraceFunc = NativeAPI.FindSignature(Addresses.ServerPath, GameData.GetSignature("TraceFunc"));
        CTraceFilterVtable = NativeAPI.FindSignature(Addresses.ServerPath, GameData.GetSignature("CTraceFilterVtable"));
        GameTraceManager = NativeAPI.FindSignature(Addresses.ServerPath, GameData.GetSignature("GameTraceManager"));
        _traceShape = Marshal.GetDelegateForFunctionPointer<TraceShapeDelegate>(TraceFunc);
        _traceShapeRayFilter = Marshal.GetDelegateForFunctionPointer<TraceShapeRayFilterDelegate>(CTraceFilterVtable);
    }

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

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private unsafe delegate bool TraceShapeRayFilterDelegate(
        nint GameTraceManager,
        Ray* trace,
        nint vecStart,
        nint vecEnd,
        CTraceFilter* traceFilter,
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

    /// <summary>
    /// Performs a hull-based ray trace using the provided shape, direction, and filter information.
    /// This method wraps the native _traceShapeRayFilter call, setting up necessary filter and trace data on the stack.
    /// </summary>
    /// <param name="angle">
    /// The direction of the trace, represented as a QAngle (pitch, yaw, roll).
    /// </param>
    /// <param name="end">
    /// The world-space end point of the trace.
    /// </param>
    /// <param name="filter">
    /// The filter used to determine which entities or collisions should be excluded during the trace.
    /// </param>
    /// <param name="ray">
    /// A pointer to the shape of the ray (e.g., line, sphere, hull, capsule, mesh) to be traced.
    /// </param>
    /// <returns>
    /// Returns a <see cref="CGameTrace"/> structure containing the result of the trace operation, including hit data, entity, and surface details.
    /// </returns>
    public static CGameTrace TraceHull(QAngle angle, Vector end, CTraceFilter filter, ref Ray* ray)
    {
        IntPtr _vtable = Address.GetAbsoluteAddress(CTraceFilterVtable, 3, 7);
        IntPtr _gameTraceManager = Address.GetAbsoluteAddress(GameTraceManager, 3, 7);
        
        CGameTrace* _trace = stackalloc CGameTrace[1];
        CTraceFilter* _filter = stackalloc CTraceFilter[1];

        *_filter = filter;
        _filter->Vtable = (void*)_vtable;

        _traceShapeRayFilter(*(nint*)_gameTraceManager, ray, angle.Handle, end.Handle, _filter, _trace);

        return *_trace;
    }
}