using System;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Utils;
using CS2TraceRay.Enum;
using CS2TraceRay.Struct;
using Vector = CounterStrikeSharp.API.Modules.Utils.Vector;

namespace CS2TraceRay.Class;

/// <summary>
/// Provides extension methods for <see cref="TraceRay"/> class
/// </summary>
public static partial class TraceRay
{
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
    public static CGameTrace TraceShape(Vector origin, QAngle angle, TraceMask mask, ulong content, IntPtr skip)
    {
        return TraceShape(origin, angle, (ulong)mask, content, skip);
    }

    /// <summary>
    /// Performs a trace from origin in the direction of angle with specified mask and content flags
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, QAngle angle, ulong mask, Contents content, IntPtr skip)
    {
        return TraceShape(origin, angle, mask, (ulong)content, skip);
    }

    /// <summary>
    /// Performs a trace from origin in the direction of angle with specified mask and content flags
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, QAngle angle, TraceMask mask, Contents content, IntPtr skip)
    {
        return TraceShape(origin, angle, (ulong)mask, (ulong)content, skip);
    }

    /// <summary>
    /// Performs a trace from origin in the direction of angle with specified mask and content flags
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, QAngle angle, Contents mask, ulong content, IntPtr skip)
    {
        return TraceShape(origin, angle, (ulong)mask, content, skip);
    }

    /// <summary>
    /// Performs a trace from origin in the direction of angle with specified mask and content flags
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, QAngle angle, Contents mask, Contents content, IntPtr skip)
    {
        return TraceShape(origin, angle, (ulong)mask, (ulong)content, skip);
    }

    /// <summary>
    /// Performs a trace from origin in the direction of angle with specified content flags
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, QAngle angle, Contents content, IntPtr skip)
    {
        return TraceShape(origin, angle, (ulong)content, (ulong)content, skip);
    }

    /// <summary>
    /// Performs a trace from origin in the direction of angle with specified mask flags
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, QAngle angle, TraceMask mask, IntPtr skip)
    {
        return TraceShape(origin, angle, (ulong)mask, (ulong)mask, skip);
    }

    /// <summary>
    /// Performs a trace from origin in the direction of angle with raw mask value
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, QAngle angle, ulong mask, IntPtr skip)
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
    public static CGameTrace TraceShape(Vector start, Vector end, TraceMask mask, ulong content, IntPtr skip)
    {
        return TraceShape(start, end, (ulong)mask, content, skip);
    }

    /// <summary>
    /// Performs a trace from origin to end with raw mask and content flags
    /// </summary>
    public static CGameTrace TraceShape(Vector start, Vector end, ulong mask, Contents content, IntPtr skip)
    {
        return TraceShape(start, end, mask, (ulong)content, skip);
    }

    /// <summary>
    /// Performs a trace from origin to end with specified mask and content flags
    /// </summary>
    public static CGameTrace TraceShape(Vector start, Vector end, TraceMask mask, Contents content, IntPtr skip)
    {
        return TraceShape(start, end, (ulong)mask, (ulong)content, skip);
    }

    /// <summary>
    /// Performs a trace from origin to end with specified mask and raw content value
    /// </summary>
    public static CGameTrace TraceShape(Vector start, Vector end, Contents mask, ulong content, IntPtr skip)
    {
        return TraceShape(start, end, (ulong)mask, content, skip);
    }

    /// <summary>
    /// Performs a trace from origin to end with specified mask and content flags
    /// </summary>
    public static CGameTrace TraceShape(Vector start, Vector end, Contents mask, Contents content, IntPtr skip)
    {
        return TraceShape(start, end, (ulong)mask, (ulong)content, skip);
    }

    /// <summary>
    /// Performs a trace from origin to end with specified content flags
    /// </summary>
    public static CGameTrace TraceShape(Vector start, Vector end, Contents content, IntPtr skip)
    {
        return TraceShape(start, end, (ulong)content, (ulong)content, skip);
    }

    /// <summary>
    /// Performs a trace from origin to end with specified mask flags
    /// </summary>
    public static CGameTrace TraceShape(Vector start, Vector end, TraceMask mask, IntPtr skip)
    {
        return TraceShape(start, end, (ulong)mask, (ulong)mask, skip);
    }

    /// <summary>
    /// Performs a trace from origin to end with raw mask value
    /// </summary>
    public static CGameTrace TraceShape(Vector start, Vector end, ulong mask, IntPtr skip)
    {
        return TraceShape(start, end, mask, mask, skip);
    }

    /// <summary>
    /// Performs a trace from origin to end with specified mask and content flags, skipping a player controller
    /// </summary>
    public static CGameTrace TraceShape(Vector start, Vector end, TraceMask mask, Contents content, CCSPlayerController skip)
    {
        return TraceShape(start, end, (ulong)mask, (ulong)content, GetSafeSkipHandle(skip));
    }

    /// <summary>
    /// Performs a trace from origin to end with specified content flags, skipping a player controller
    /// </summary>
    public static CGameTrace TraceShape(Vector start, Vector end, Contents content, CCSPlayerController skip)
    {
        return TraceShape(start, end, (ulong)content, (ulong)content, GetSafeSkipHandle(skip));
    }

    /// <summary>
    /// Performs a trace from origin to end with specified mask and raw content value, skipping a player controller
    /// </summary>
    public static CGameTrace TraceShape(Vector start, Vector end, TraceMask mask, ulong content, CCSPlayerController skip)
    {
        return TraceShape(start, end, (ulong)mask, content, GetSafeSkipHandle(skip));
    }

    /// <summary>
    /// Performs a trace from origin to end with raw mask and content flags, skipping a player controller
    /// </summary>
    public static CGameTrace TraceShape(Vector start, Vector end, ulong mask, Contents content, CCSPlayerController skip)
    {
        return TraceShape(start, end, mask, (ulong)content, GetSafeSkipHandle(skip));
    }

    /// <summary>
    /// Performs a trace from origin to end with specified mask and raw content value, skipping a player controller
    /// </summary>
    public static CGameTrace TraceShape(Vector start, Vector end, Contents mask, ulong content, CCSPlayerController skip)
    {
        return TraceShape(start, end, (ulong)mask, content, GetSafeSkipHandle(skip));
    }

    /// <summary>
    /// Performs a trace from origin to end with raw mask and content values, skipping a player controller
    /// </summary>
    public static CGameTrace TraceShape(Vector start, Vector end, ulong mask, ulong content, CCSPlayerController skip)
    {
        return TraceShape(start, end, mask, content, GetSafeSkipHandle(skip));
    }

    /// <summary>
    /// Performs a trace from origin to end with specified mask and content flags, skipping a player controller
    /// </summary>
    public static CGameTrace TraceShape(Vector start, Vector end, Contents mask, Contents content, CCSPlayerController skip)
    {
        return TraceShape(start, end, (ulong)mask, (ulong)content, GetSafeSkipHandle(skip));
    }

    /// <summary>
    /// Performs a trace from origin to end with specified mask flags, skipping a player controller
    /// </summary>
    public static CGameTrace TraceShape(Vector start, Vector end, TraceMask mask, CCSPlayerController skip)
    {
        return TraceShape(start, end, (ulong)mask, (ulong)mask, skip.Handle);
    }

    /// <summary>
    /// Performs a trace from origin to end with raw mask value, skipping a player controller
    /// </summary>
    public static CGameTrace TraceShape(Vector start, Vector end, ulong mask, CCSPlayerController skip)
    {
        return TraceShape(start, end, mask, mask, GetSafeSkipHandle(skip));
    }

    /// <summary>
    /// Performs a trace from origin to end with specified mask and content flags, skipping a player pawn
    /// </summary>
    public static CGameTrace TraceShape(Vector start, Vector end, TraceMask mask, Contents content, CCSPlayerPawn skip)
    {
        return TraceShape(start, end, (ulong)mask, (ulong)content, skip.Handle);
    }

    /// <summary>
    /// Performs a trace from origin to end with specified content flags, skipping a player pawn
    /// </summary>
    public static CGameTrace TraceShape(Vector start, Vector end, Contents content, CCSPlayerPawn skip)
    {
        return TraceShape(start, end, (ulong)content, (ulong)content, skip.Handle);
    }

    /// <summary>
    /// Performs a trace from origin to end with specified mask and raw content value, skipping a player pawn
    /// </summary>
    public static CGameTrace TraceShape(Vector start, Vector end, TraceMask mask, ulong content, CCSPlayerPawn skip)
    {
        return TraceShape(start, end, (ulong)mask, content, skip.Handle);
    }

    /// <summary>
    /// Performs a trace from origin to end with raw mask and content flags, skipping a player pawn
    /// </summary>
    public static CGameTrace TraceShape(Vector start, Vector end, ulong mask, Contents content, CCSPlayerPawn skip)
    {
        return TraceShape(start, end, mask, (ulong)content, skip.Handle);
    }

    /// <summary>
    /// Performs a trace from origin to end with specified mask and raw content value, skipping a player pawn
    /// </summary>
    public static CGameTrace TraceShape(Vector start, Vector end, Contents mask, ulong content, CCSPlayerPawn skip)
    {
        return TraceShape(start, end, (ulong)mask, content, skip.Handle);
    }

    /// <summary>
    /// Performs a trace from origin to end with raw mask and content values, skipping a player pawn
    /// </summary>
    public static CGameTrace TraceShape(Vector start, Vector end, ulong mask, ulong content, CCSPlayerPawn skip)
    {
        return TraceShape(start, end, mask, content, skip.Handle);
    }

    /// <summary>
    /// Performs a trace from origin to end with specified mask and content flags, skipping a player pawn
    /// </summary>
    public static CGameTrace TraceShape(Vector start, Vector end, Contents mask, Contents content, CCSPlayerPawn skip)
    {
        return TraceShape(start, end, (ulong)mask, (ulong)content, skip.Handle);
    }

    /// <summary>
    /// Performs a trace from origin to end with specified mask flags, skipping a player pawn
    /// </summary>
    public static CGameTrace TraceShape(Vector start, Vector end, TraceMask mask, CCSPlayerPawn skip)
    {
        return TraceShape(start, end, (ulong)mask, (ulong)mask, skip.Handle);
    }

    /// <summary>
    /// Performs a trace from origin to end with raw mask value, skipping a player pawn
    /// </summary>
    public static CGameTrace TraceShape(Vector start, Vector end, ulong mask, CCSPlayerPawn skip)
    {
        return TraceShape(start, end, mask, mask, skip.Handle);
    }

    /// <summary>
    /// Performs a trace from origin in the direction of angle with specified mask and content flags (both as TraceMask)
    /// </summary>
    public static CGameTrace TraceShape(Vector origin, QAngle angle, TraceMask mask, TraceMask content, IntPtr skip)
    {
        return TraceShape(origin, angle, (ulong)mask, (ulong)content, skip);
    }

    /// <summary>
    /// Performs a trace from origin to end with specified mask (as Contents) and content (as TraceMask), skipping a player controller
    /// </summary>
    public static CGameTrace TraceShape(Vector start, Vector end, Contents mask, TraceMask content, CCSPlayerController skip)
    {
        return TraceShape(start, end, (ulong)mask, (ulong)content, GetSafeSkipHandle(skip));
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
    public static CGameTrace TraceShape(Vector origin, QAngle angle, Contents mask, TraceMask content, IntPtr skip)
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
    public static CGameTrace TraceShape(Vector start, Vector end, TraceMask mask, TraceMask content, IntPtr skip)
    {
        return TraceShape(start, end, (ulong)mask, (ulong)content, skip);
    }

    /// <summary>
    /// Performs a trace from origin to end with specified mask (as Contents) and content (as TraceMask)
    /// </summary>
    public static CGameTrace TraceShape(Vector start, Vector end, Contents mask, TraceMask content, IntPtr skip)
    {
        return TraceShape(start, end, (ulong)mask, (ulong)content, skip);
    }

    /// <summary>
    /// Performs a trace from origin to end with specified mask and content flags (both as TraceMask), skipping a player controller
    /// </summary>
    public static CGameTrace TraceShape(Vector start, Vector end, TraceMask mask, TraceMask content, CCSPlayerController skip)
    {
        return TraceShape(start, end, (ulong)mask, (ulong)content, GetSafeSkipHandle(skip));
    }

    /// <summary>
    /// Performs a trace from origin to end with specified mask and content flags (both as TraceMask), skipping a player pawn
    /// </summary>
    public static CGameTrace TraceShape(Vector start, Vector end, TraceMask mask, TraceMask content, CCSPlayerPawn skip)
    {
        return TraceShape(start, end, (ulong)mask, (ulong)content, skip.Handle);
    }

    /// <summary>
    /// Performs a trace from origin to end with specified mask (as Contents) and content (as TraceMask), skipping a player pawn
    /// </summary>
    public static CGameTrace TraceShape(Vector start, Vector end, Contents mask, TraceMask content, CCSPlayerPawn skip)
    {
        return TraceShape(start, end, (ulong)mask, (ulong)content, skip.Handle);
    }

    private static IntPtr GetSafeSkipHandle(CCSPlayerController player)
    {
        return player.PlayerPawn.Value is not { } playerPawn ? IntPtr.Zero : playerPawn.Handle;
    }
}