using System;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Utils;
using CS2TraceRay.Enum;
using CS2TraceRay.Struct;

namespace CS2TraceRay.Class;

/// <summary>
/// Provides extension methods for <see cref="CCSPlayerController"/> and <see cref="CCSPlayerPawn"/> classes
/// to support various player-related operations including trace rays and position calculations.
/// </summary>
public static class PlayerExtensions
{
    /// <summary>
    /// Performs a game trace from the player's eye position in the direction they are looking.
    /// </summary>
    /// <param name="player">The player controller to trace from.</param>
    /// <param name="mask">The trace mask to use for collision detection.</param>
    /// <param name="contents">The content flags to filter the trace.</param>
    /// <param name="skipPlayer">Optional player whose pawn should be ignored in the trace.</param>
    /// <returns>A <see cref="CGameTrace"/> object containing the trace results, or null if the trace couldn't be performed.</returns>
    public static CGameTrace? GetGameTraceByEyePosition(this CCSPlayerController player, TraceMask mask, Contents contents, CCSPlayerController? skipPlayer)
    {
        return player.PlayerPawn.Value?.GetGameTraceByEyePosition(mask, contents, skipPlayer);
    }

    /// <summary>
    /// Performs a game trace from the player pawn's eye position in the direction they are looking.
    /// </summary>
    /// <param name="playerPawn">The player pawn to trace from.</param>
    /// <param name="mask">The trace mask to use for collision detection.</param>
    /// <param name="contents">The contents flags to filter the trace.</param>
    /// <param name="skipPlayer">Optional player whose pawn should be ignored in the trace.</param>
    /// <returns>A <see cref="CGameTrace"/> object containing the trace results, or null if the trace couldn't be performed.</returns>
    public static CGameTrace? GetGameTraceByEyePosition(this CCSPlayerPawn playerPawn, TraceMask mask, Contents contents, CCSPlayerController? skipPlayer)
    {
        if (playerPawn.GetEyePosition() is not { } eyePosition)
            return null;

        IntPtr skip = skipPlayer?.PlayerPawn.Value?.Handle ?? IntPtr.Zero;
        QAngle eyeAngles = playerPawn.EyeAngles;
        CGameTrace _trace = TraceRay.TraceShape(eyePosition, eyeAngles, mask, contents, skip);

        return _trace;
    }

    /// <summary>
    /// Gets the eye position of the player in world coordinates.
    /// </summary>
    /// <param name="player">The player controller to get the eye position from.</param>
    /// <returns>A <see cref="Vector"/> representing the eye position, or null if the position couldn't be determined.</returns>
    public static Vector? GetEyePosition(this CCSPlayerController player)
    {
        return player.PlayerPawn.Value?.GetEyePosition();
    }

    /// <summary>
    /// Gets the eye position of the player pawn in world coordinates.
    /// </summary>
    /// <param name="playerPawn">The player pawn to get the eye position from.</param>
    /// <returns>A <see cref="Vector"/> representing the eye position, or null if the position couldn't be determined.</returns>
    public static Vector? GetEyePosition(this CCSPlayerPawn playerPawn)
    {
        return playerPawn.AbsOrigin is not { } absOrigin || playerPawn.CameraServices is not { } cameraServices
            ? null
            : new Vector(absOrigin.X, absOrigin.Y, absOrigin.Z + cameraServices.OldPlayerViewOffsetZ);
    }

    /// <summary>
    /// Gets the vertical distance from the player to the ground below them.
    /// </summary>
    /// <param name="player">The player controller to measure from.</param>
    /// <returns>The distance in units, or 0 if the player is on the ground or the measurement couldn't be taken.</returns>
    public static float GetGroundDistance(this CCSPlayerController player)
    {
        return player.PlayerPawn.Value?.GetGroundDistance() ?? 0;
    }

    /// <summary>
    /// Gets the vertical distance from the player pawn to the ground below them.
    /// </summary>
    /// <param name="playerPawn">The player pawn to measure from.</param>
    /// <returns>The distance in units, or 0 if the player is on the ground or the measurement couldn't be taken.</returns>
    public static float GetGroundDistance(this CCSPlayerPawn playerPawn)
    {
        if (playerPawn.GroundEntity.IsValid ||
            playerPawn.AbsOrigin is not { } absOrigin)
            return 0.0f;

        CGameTrace _trace = TraceRay.TraceShape(absOrigin, new QAngle(90, 0, 0), TraceMask.MaskAll, Contents.Sky, 0);
        return _trace.Distance();
    }
    
    /// <summary>
    /// Retrieves the bitmask representing the content layers this pawn interacts with (trace mask).
    /// Commonly used in trace and collision filtering logic.
    /// </summary>
    /// <param name="pawn">The player pawn instance.</param>
    /// <returns>The interaction bitmask from the pawn's collision attributes.</returns>
    public static ulong GetInteractsWith(this CCSPlayerPawn pawn)
        => pawn.Collision.CollisionAttribute.InteractsWith;

    /// <summary>
    /// Retrieves the hierarchy ID used for organizing entity relationships during collision detection.
    /// This ID helps optimize trace results by skipping or including entities based on hierarchy context.
    /// </summary>
    /// <param name="pawn">The player pawn instance.</param>
    /// <returns>The hierarchy ID from the pawn's collision attributes.</returns>
    public static ushort GetHierarchyId(this CCSPlayerPawn pawn)
        => pawn.Collision.CollisionAttribute.HierarchyId;
}