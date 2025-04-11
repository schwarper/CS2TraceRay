﻿using CounterStrikeSharp.API.Core;
using System.Numerics;
using System.Runtime.InteropServices;

namespace CS2TraceRay.Class;

/// <summary>
/// Represents the results of a game trace operation, containing information about what was hit.
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 0xB8)]
public unsafe struct CGameTrace
{
    /// <summary>
    /// The surface that was hit by the trace.
    /// </summary>
    [FieldOffset(0x00)] public nint Surface;

    /// <summary>
    /// The entity that was hit by the trace.
    /// </summary>
    [FieldOffset(0x08)] public nint HitEntity;

    /// <summary>
    /// Pointer to the hitbox data if a hitbox was hit.
    /// </summary>
    [FieldOffset(0x10)] public CTraceHitbox* HitboxData;

    /// <summary>
    /// The contents at the point of impact.
    /// </summary>
    [FieldOffset(0x50)] public uint Contents;

    /// <summary>
    /// The starting position of the trace.
    /// </summary>
    [FieldOffset(0x78)] public Vector3 StartPos;

    /// <summary>
    /// The end position of the trace.
    /// </summary>
    [FieldOffset(0x84)] public Vector3 EndPos;

    /// <summary>
    /// The surface normal at the point of impact.
    /// </summary>
    [FieldOffset(0x90)] public Vector3 Normal;

    /// <summary>
    /// The exact position where the trace hit.
    /// </summary>
    [FieldOffset(0x9C)] public Vector3 Position;

    /// <summary>
    /// Fraction of the trace completed when the hit occurred (0.0-1.0).
    /// </summary>
    [FieldOffset(0xAC)] public float Fraction;

    /// <summary>
    /// Whether the trace was completely inside a solid (no free space).
    /// </summary>
    [FieldOffset(0xB6)] public bool AllSolid;

    /// <summary>
    /// Gets the hitbox information if a hitbox was hit.
    /// </summary>
    public CTraceHitbox Hitbox => HitboxData != null ? *HitboxData : default;

    /// <summary>
    /// Determines if the trace hit anything.
    /// </summary>
    /// <returns>True if the trace hit something, false otherwise.</returns>
    public readonly bool DidHit => Fraction < 1.0f && !AllSolid;

    /// <summary>
    /// Gets the distance between the start and end positions of the trace.
    /// </summary>
    public readonly float Distance => Vector3.Distance(StartPos, EndPos);

    /// <summary>
    /// Gets the normalized direction vector of the trace.
    /// </summary>
    public readonly Vector3 Direction => Vector3.Normalize(EndPos - StartPos);

    /// <summary>
    /// Attempts to get the player controller if the trace hit a player.
    /// </summary>
    /// <param name="player">The player controller that was hit, if any.</param>
    /// <returns>True if a player was hit, false otherwise.</returns>
    public readonly bool HitPlayer(out CCSPlayerController? player)
    {
        if (new CCSPlayerPawn(HitEntity) is { } playerPawn && playerPawn.DesignerName == "player")
        {
            player = playerPawn.OriginalController.Value;
            return player != null;
        }

        player = null;
        return false;
    }

    /// <summary>
    /// Attempts to get the weapon if the trace hit a weapon.
    /// </summary>
    /// <param name="weapon">The weapon that was hit, if any.</param>
    /// <returns>True if a weapon was hit, false otherwise.</returns>
    public readonly bool HitWeapon(out CBasePlayerWeapon? weapon)
    {
        if (new CBasePlayerWeapon(HitEntity) is { } weaponEntity && weaponEntity.DesignerName.StartsWith("weapon_"))
        {
            weapon = weaponEntity;
            return true;
        }

        weapon = null;
        return false;
    }
}