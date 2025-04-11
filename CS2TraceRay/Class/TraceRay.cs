using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Memory;
using CounterStrikeSharp.API.Modules.Utils;
using CS2TraceRay.Enum;
using System.Runtime.InteropServices;

namespace CS2TraceRay.Class;

/// <summary>
/// Provides static methods for performing trace operations in CS2.
/// </summary>
public static unsafe class TraceRay
{
    private static readonly nint TraceFunc = NativeAPI.FindSignature(Addresses.ServerPath, GameData.GetSignature("TraceFunc"));
    private static readonly nint GameTraceManager = NativeAPI.FindSignature(Addresses.ServerPath, GameData.GetSignature("GameTraceManager"));
    private static readonly TraceShapeDelegate _traceShape = Marshal.GetDelegateForFunctionPointer<TraceShapeDelegate>(TraceFunc);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate bool TraceShapeDelegate(
        nint GameTraceManager,
        nint vecStart,
        nint vecEnd,
        nint skip,
        ulong mask,
        ulong content,
        CGameTrace* pGameTrace
    );

    /// <summary>
    /// Performs a trace from origin in the direction of angle with specified mask and content flags, skipping a player controller
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, QAngle angle, TraceMask mask, Contents content, CCSPlayerController skip)
    {
        return TraceShape(origin, angle, (ulong)mask, (ulong)content, GetSafeSkipHandle(skip));
    }

    /// <summary>
    /// Performs a trace from origin in the direction of angle with specified mask and content flags
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, QAngle angle, TraceMask mask, ulong content, nint skip)
    {
        return TraceShape(origin, angle, (ulong)mask, content, skip);
    }

    /// <summary>
    /// Performs a trace from origin in the direction of angle with specified mask and content flags
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, QAngle angle, ulong mask, Contents content, nint skip)
    {
        return TraceShape(origin, angle, mask, (ulong)content, skip);
    }

    /// <summary>
    /// Performs a trace from origin in the direction of angle with specified mask and content flags
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, QAngle angle, TraceMask mask, Contents content, nint skip)
    {
        return TraceShape(origin, angle, (ulong)mask, (ulong)content, skip);
    }

    /// <summary>
    /// Performs a trace from origin in the direction of angle with specified mask and content flags
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, QAngle angle, Contents mask, ulong content, nint skip)
    {
        return TraceShape(origin, angle, (ulong)mask, content, skip);
    }

    /// <summary>
    /// Performs a trace from origin in the direction of angle with specified mask and content flags
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, QAngle angle, Contents mask, Contents content, nint skip)
    {
        return TraceShape(origin, angle, (ulong)mask, (ulong)content, skip);
    }

    /// <summary>
    /// Performs a trace from origin in the direction of angle with specified content flags
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, QAngle angle, Contents content, nint skip)
    {
        return TraceShape(origin, angle, (ulong)content, (ulong)content, skip);
    }

    /// <summary>
    /// Performs a trace from origin in the direction of angle with specified mask flags
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, QAngle angle, TraceMask mask, nint skip)
    {
        return TraceShape(origin, angle, (ulong)mask, (ulong)mask, skip);
    }

    /// <summary>
    /// Performs a trace from origin in the direction of angle with raw mask value
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, QAngle angle, ulong mask, nint skip)
    {
        return TraceShape(origin, angle, mask, mask, skip);
    }

    /// <summary>
    /// Performs a trace from origin in the direction of angle with specified content flags, skipping a player controller
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, QAngle angle, Contents content, CCSPlayerController skip)
    {
        return TraceShape(origin, angle, (ulong)content, (ulong)content, GetSafeSkipHandle(skip));
    }

    /// <summary>
    /// Performs a trace from origin in the direction of angle with specified mask and raw content value, skipping a player controller
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, QAngle angle, TraceMask mask, ulong content, CCSPlayerController skip)
    {
        return TraceShape(origin, angle, (ulong)mask, content, GetSafeSkipHandle(skip));
    }

    /// <summary>
    /// Performs a trace from origin in the direction of angle with raw mask and content flags, skipping a player controller
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, QAngle angle, ulong mask, Contents content, CCSPlayerController skip)
    {
        return TraceShape(origin, angle, mask, (ulong)content, GetSafeSkipHandle(skip));
    }

    /// <summary>
    /// Performs a trace from origin in the direction of angle with specified mask and raw content value, skipping a player controller
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, QAngle angle, Contents mask, ulong content, CCSPlayerController skip)
    {
        return TraceShape(origin, angle, (ulong)mask, content, GetSafeSkipHandle(skip));
    }

    /// <summary>
    /// Performs a trace from origin in the direction of angle with raw mask and content values, skipping a player controller
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, QAngle angle, ulong mask, ulong content, CCSPlayerController skip)
    {
        return TraceShape(origin, angle, mask, content, GetSafeSkipHandle(skip));
    }

    /// <summary>
    /// Performs a trace from origin in the direction of angle with specified mask and content flags, skipping a player controller
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, QAngle angle, Contents mask, Contents content, CCSPlayerController skip)
    {
        return TraceShape(origin, angle, (ulong)mask, (ulong)content, GetSafeSkipHandle(skip));
    }

    /// <summary>
    /// Performs a trace from origin in the direction of angle with specified mask flags, skipping a player controller
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, QAngle angle, TraceMask mask, CCSPlayerController skip)
    {
        return TraceShape(origin, angle, (ulong)mask, (ulong)mask, GetSafeSkipHandle(skip));
    }

    /// <summary>
    /// Performs a trace from origin in the direction of angle with raw mask value, skipping a player controller
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, QAngle angle, ulong mask, CCSPlayerController skip)
    {
        return TraceShape(origin, angle, mask, mask, GetSafeSkipHandle(skip));
    }

    /// <summary>
    /// Performs a trace from origin in the direction of angle with specified mask and content flags, skipping a player pawn
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, QAngle angle, TraceMask mask, Contents content, CCSPlayerPawn skip)
    {
        return TraceShape(origin, angle, (ulong)mask, (ulong)content, skip.Handle);
    }

    /// <summary>
    /// Performs a trace from origin in the direction of angle with specified content flags, skipping a player pawn
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, QAngle angle, Contents content, CCSPlayerPawn skip)
    {
        return TraceShape(origin, angle, (ulong)content, (ulong)content, skip.Handle);
    }

    /// <summary>
    /// Performs a trace from origin in the direction of angle with specified mask and raw content value, skipping a player pawn
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, QAngle angle, TraceMask mask, ulong content, CCSPlayerPawn skip)
    {
        return TraceShape(origin, angle, (ulong)mask, content, skip.Handle);
    }

    /// <summary>
    /// Performs a trace from origin in the direction of angle with raw mask and content flags, skipping a player pawn
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, QAngle angle, ulong mask, Contents content, CCSPlayerPawn skip)
    {
        return TraceShape(origin, angle, mask, (ulong)content, skip.Handle);
    }

    /// <summary>
    /// Performs a trace from origin in the direction of angle with specified mask and raw content value, skipping a player pawn
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, QAngle angle, Contents mask, ulong content, CCSPlayerPawn skip)
    {
        return TraceShape(origin, angle, (ulong)mask, content, skip.Handle);
    }

    /// <summary>
    /// Performs a trace from origin in the direction of angle with raw mask and content values, skipping a player pawn
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, QAngle angle, ulong mask, ulong content, CCSPlayerPawn skip)
    {
        return TraceShape(origin, angle, mask, content, skip.Handle);
    }

    /// <summary>
    /// Performs a trace from origin in the direction of angle with specified mask and content flags, skipping a player pawn
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, QAngle angle, Contents mask, Contents content, CCSPlayerPawn skip)
    {
        return TraceShape(origin, angle, (ulong)mask, (ulong)content, skip.Handle);
    }

    /// <summary>
    /// Performs a trace from origin in the direction of angle with specified mask flags, skipping a player pawn
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, QAngle angle, TraceMask mask, CCSPlayerPawn skip)
    {
        return TraceShape(origin, angle, (ulong)mask, (ulong)mask, skip.Handle);
    }

    /// <summary>
    /// Performs a trace from origin in the direction of angle with raw mask value, skipping a player pawn
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, QAngle angle, ulong mask, CCSPlayerPawn skip)
    {
        return TraceShape(origin, angle, mask, mask, skip.Handle);
    }

    /// <summary>
    /// Performs a trace from origin to end with specified mask and content flags
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, Vector end, TraceMask mask, ulong content, nint skip)
    {
        return TraceShape(origin, end, (ulong)mask, content, skip);
    }

    /// <summary>
    /// Performs a trace from origin to end with raw mask and content flags
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, Vector end, ulong mask, Contents content, nint skip)
    {
        return TraceShape(origin, end, mask, (ulong)content, skip);
    }

    /// <summary>
    /// Performs a trace from origin to end with specified mask and content flags
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, Vector end, TraceMask mask, Contents content, nint skip)
    {
        return TraceShape(origin, end, (ulong)mask, (ulong)content, skip);
    }

    /// <summary>
    /// Performs a trace from origin to end with specified mask and raw content value
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, Vector end, Contents mask, ulong content, nint skip)
    {
        return TraceShape(origin, end, (ulong)mask, content, skip);
    }

    /// <summary>
    /// Performs a trace from origin to end with specified mask and content flags
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, Vector end, Contents mask, Contents content, nint skip)
    {
        return TraceShape(origin, end, (ulong)mask, (ulong)content, skip);
    }

    /// <summary>
    /// Performs a trace from origin to end with specified content flags
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, Vector end, Contents content, nint skip)
    {
        return TraceShape(origin, end, (ulong)content, (ulong)content, skip);
    }

    /// <summary>
    /// Performs a trace from origin to end with specified mask flags
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, Vector end, TraceMask mask, nint skip)
    {
        return TraceShape(origin, end, (ulong)mask, (ulong)mask, skip);
    }

    /// <summary>
    /// Performs a trace from origin to end with raw mask value
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, Vector end, ulong mask, nint skip)
    {
        return TraceShape(origin, end, mask, mask, skip);
    }

    /// <summary>
    /// Performs a trace from origin to end with specified mask and content flags, skipping a player controller
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, Vector end, TraceMask mask, Contents content, CCSPlayerController skip)
    {
        return TraceShape(origin, end, (ulong)mask, (ulong)content, GetSafeSkipHandle(skip));
    }

    /// <summary>
    /// Performs a trace from origin to end with specified content flags, skipping a player controller
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, Vector end, Contents content, CCSPlayerController skip)
    {
        return TraceShape(origin, end, (ulong)content, (ulong)content, GetSafeSkipHandle(skip));
    }

    /// <summary>
    /// Performs a trace from origin to end with specified mask and raw content value, skipping a player controller
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, Vector end, TraceMask mask, ulong content, CCSPlayerController skip)
    {
        return TraceShape(origin, end, (ulong)mask, content, GetSafeSkipHandle(skip));
    }

    /// <summary>
    /// Performs a trace from origin to end with raw mask and content flags, skipping a player controller
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, Vector end, ulong mask, Contents content, CCSPlayerController skip)
    {
        return TraceShape(origin, end, mask, (ulong)content, GetSafeSkipHandle(skip));
    }

    /// <summary>
    /// Performs a trace from origin to end with specified mask and raw content value, skipping a player controller
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, Vector end, Contents mask, ulong content, CCSPlayerController skip)
    {
        return TraceShape(origin, end, (ulong)mask, content, GetSafeSkipHandle(skip));
    }

    /// <summary>
    /// Performs a trace from origin to end with raw mask and content values, skipping a player controller
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, Vector end, ulong mask, ulong content, CCSPlayerController skip)
    {
        return TraceShape(origin, end, mask, content, GetSafeSkipHandle(skip));
    }

    /// <summary>
    /// Performs a trace from origin to end with specified mask and content flags, skipping a player controller
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, Vector end, Contents mask, Contents content, CCSPlayerController skip)
    {
        return TraceShape(origin, end, (ulong)mask, (ulong)content, GetSafeSkipHandle(skip));
    }

    /// <summary>
    /// Performs a trace from origin to end with specified mask flags, skipping a player controller
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, Vector end, TraceMask mask, CCSPlayerController skip)
    {
        return TraceShape(origin, end, (ulong)mask, (ulong)mask, skip.Handle);
    }

    /// <summary>
    /// Performs a trace from origin to end with raw mask value, skipping a player controller
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, Vector end, ulong mask, CCSPlayerController skip)
    {
        return TraceShape(origin, end, mask, mask, GetSafeSkipHandle(skip));
    }

    /// <summary>
    /// Performs a trace from origin to end with specified mask and content flags, skipping a player pawn
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, Vector end, TraceMask mask, Contents content, CCSPlayerPawn skip)
    {
        return TraceShape(origin, end, (ulong)mask, (ulong)content, skip.Handle);
    }

    /// <summary>
    /// Performs a trace from origin to end with specified content flags, skipping a player pawn
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, Vector end, Contents content, CCSPlayerPawn skip)
    {
        return TraceShape(origin, end, (ulong)content, (ulong)content, skip.Handle);
    }

    /// <summary>
    /// Performs a trace from origin to end with specified mask and raw content value, skipping a player pawn
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, Vector end, TraceMask mask, ulong content, CCSPlayerPawn skip)
    {
        return TraceShape(origin, end, (ulong)mask, content, skip.Handle);
    }

    /// <summary>
    /// Performs a trace from origin to end with raw mask and content flags, skipping a player pawn
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, Vector end, ulong mask, Contents content, CCSPlayerPawn skip)
    {
        return TraceShape(origin, end, mask, (ulong)content, skip.Handle);
    }

    /// <summary>
    /// Performs a trace from origin to end with specified mask and raw content value, skipping a player pawn
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, Vector end, Contents mask, ulong content, CCSPlayerPawn skip)
    {
        return TraceShape(origin, end, (ulong)mask, content, skip.Handle);
    }

    /// <summary>
    /// Performs a trace from origin to end with raw mask and content values, skipping a player pawn
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, Vector end, ulong mask, ulong content, CCSPlayerPawn skip)
    {
        return TraceShape(origin, end, mask, content, skip.Handle);
    }

    /// <summary>
    /// Performs a trace from origin to end with specified mask and content flags, skipping a player pawn
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, Vector end, Contents mask, Contents content, CCSPlayerPawn skip)
    {
        return TraceShape(origin, end, (ulong)mask, (ulong)content, skip.Handle);
    }

    /// <summary>
    /// Performs a trace from origin to end with specified mask flags, skipping a player pawn
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, Vector end, TraceMask mask, CCSPlayerPawn skip)
    {
        return TraceShape(origin, end, (ulong)mask, (ulong)mask, skip.Handle);
    }

    /// <summary>
    /// Performs a trace from origin to end with raw mask value, skipping a player pawn
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, Vector end, ulong mask, CCSPlayerPawn skip)
    {
        return TraceShape(origin, end, mask, mask, skip.Handle);
    }

    /// <summary>
    /// Performs a trace from origin in the direction of angle with specified mask and content flags (both as TraceMask)
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, QAngle angle, TraceMask mask, TraceMask content, nint skip)
    {
        return TraceShape(origin, angle, (ulong)mask, (ulong)content, skip);
    }

    /// <summary>
    /// Performs a trace from origin to end with specified mask (as Contents) and content (as TraceMask), skipping a player controller
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, Vector end, Contents mask, TraceMask content, CCSPlayerController skip)
    {
        return TraceShape(origin, end, (ulong)mask, (ulong)content, GetSafeSkipHandle(skip));
    }

    /// <summary>
    /// Performs a trace from origin in the direction of angle with specified mask and content flags (both as TraceMask), skipping a player pawn
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, QAngle angle, TraceMask mask, TraceMask content, CCSPlayerPawn skip)
    {
        return TraceShape(origin, angle, (ulong)mask, (ulong)content, skip.Handle);
    }

    /// <summary>
    /// Performs a trace from origin in the direction of angle with specified mask (as Contents) and content (as TraceMask)
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, QAngle angle, Contents mask, TraceMask content, nint skip)
    {
        return TraceShape(origin, angle, (ulong)mask, (ulong)content, skip);
    }

    /// <summary>
    /// Performs a trace from origin in the direction of angle with specified mask and content flags (both as TraceMask), skipping a player controller
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, QAngle angle, TraceMask mask, TraceMask content, CCSPlayerController skip)
    {
        return TraceShape(origin, angle, (ulong)mask, (ulong)content, GetSafeSkipHandle(skip));
    }

    /// <summary>
    /// Performs a trace from origin in the direction of angle with specified mask (as Contents) and content (as TraceMask), skipping a player controller
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, QAngle angle, Contents mask, TraceMask content, CCSPlayerController skip)
    {
        return TraceShape(origin, angle, (ulong)mask, (ulong)content, GetSafeSkipHandle(skip));
    }

    /// <summary>
    /// Performs a trace from origin in the direction of angle with specified mask (as Contents) and content (as TraceMask), skipping a player pawn
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, QAngle angle, Contents mask, TraceMask content, CCSPlayerPawn skip)
    {
        return TraceShape(origin, angle, (ulong)mask, (ulong)content, skip.Handle);
    }

    /// <summary>
    /// Performs a trace from origin to end with specified mask and content flags (both as TraceMask)
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, Vector end, TraceMask mask, TraceMask content, nint skip)
    {
        return TraceShape(origin, end, (ulong)mask, (ulong)content, skip);
    }

    /// <summary>
    /// Performs a trace from origin to end with specified mask (as Contents) and content (as TraceMask)
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, Vector end, Contents mask, TraceMask content, nint skip)
    {
        return TraceShape(origin, end, (ulong)mask, (ulong)content, skip);
    }

    /// <summary>
    /// Performs a trace from origin to end with specified mask and content flags (both as TraceMask), skipping a player controller
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, Vector end, TraceMask mask, TraceMask content, CCSPlayerController skip)
    {
        return TraceShape(origin, end, (ulong)mask, (ulong)content, GetSafeSkipHandle(skip));
    }

    /// <summary>
    /// Performs a trace from origin to end with specified mask and content flags (both as TraceMask), skipping a player pawn
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, Vector end, TraceMask mask, TraceMask content, CCSPlayerPawn skip)
    {
        return TraceShape(origin, end, (ulong)mask, (ulong)content, skip.Handle);
    }

    /// <summary>
    /// Performs a trace from origin to end with specified mask (as Contents) and content (as TraceMask), skipping a player pawn
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, Vector end, Contents mask, TraceMask content, CCSPlayerPawn skip)
    {
        return TraceShape(origin, end, (ulong)mask, (ulong)content, skip.Handle);
    }

    /// <summary>
    /// Performs a trace from origin in the direction of angle with specified mask and content flags
    /// </summary>
    /// <param name="origin">Starting position of the trace</param>
    /// <param name="angle">Direction of the trace</param>
    /// <param name="mask">Trace mask flags as ulong</param>
    /// <param name="content">Content flags as ulong</param>
    /// <param name="skip">Entity to skip (nint handle)</param>
    /// <returns>CGameTrace containing the trace results</returns>
    public static CGameTrace TraceShape(Vector origin, QAngle angle, ulong mask, ulong content, nint skip)
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
    /// <param name="skip">Entity to skip (nint handle)</param>
    /// <returns>CGameTrace containing the trace results</returns>
    public static CGameTrace TraceShape(Vector origin, Vector end, ulong mask, ulong content, nint skip)
    {
        CGameTrace* _trace = stackalloc CGameTrace[1];
        nint _gameTraceManagerAddress = Address.GetAbsoluteAddress(GameTraceManager, 3, 7);

        _traceShape(*(nint*)_gameTraceManagerAddress, origin.Handle, end.Handle, skip, mask, content, _trace);

        return *_trace;
    }

    private static nint GetSafeSkipHandle(CCSPlayerController player)
    {
        return player.PlayerPawn.Value is not { } playerPawn ? nint.Zero : playerPawn.Handle;
    }
}