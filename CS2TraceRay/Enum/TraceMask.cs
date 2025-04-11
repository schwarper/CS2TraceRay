using System;

namespace CS2TraceRay.Enum;

/// <summary>
/// Predefined trace masks for common collision detection scenarios
/// </summary>
[Flags]
public enum TraceMask : ulong
{
    /// <summary>Matches everything</summary>
    MaskAll = ~0ul,

    /// <summary>Everything that is normally solid</summary>
    MaskSolid = Contents.Solid | Contents.Window | Contents.Player | Contents.Npc | Contents.PassBullets,

    /// <summary>Everything that blocks player movement</summary>
    MaskPlayerSolid = Contents.Solid | Contents.PlayerClip | Contents.Window | Contents.Player | Contents.Npc | Contents.PassBullets,

    /// <summary>Blocks NPC movement</summary>
    MaskNpcSolid = Contents.Solid | Contents.NpcClip | Contents.Window | Contents.Player | Contents.Npc | Contents.PassBullets,

    /// <summary>Blocks fluid movement</summary>
    MaskNpcFluid = Contents.Solid | Contents.NpcClip | Contents.Window | Contents.Player | Contents.Npc,

    /// <summary>Water physics contents</summary>
    MaskWater = Contents.Water | Contents.Slime,

    /// <summary>Contents that bullets see as solid</summary>
    MaskShot = Contents.Solid | Contents.Player | Contents.Npc | Contents.Window | Contents.Debris | Contents.Hitbox,

    /// <summary>Bullet collision (world+brush only, no monsters)</summary>
    MaskShotBrushOnly = Contents.Solid | Contents.Window | Contents.Debris,

    /// <summary>Non-raycasted weapons collision (includes grates)</summary>
    MaskShotHull = Contents.Solid | Contents.Player | Contents.Npc | Contents.Window | Contents.Debris | Contents.PassBullets,

    /// <summary>Portal gun trace collision</summary>
    MaskShotPortal = Contents.Solid | Contents.Window | Contents.Player | Contents.Npc,

    /// <summary>Solid contents (world+brush only, no monsters)</summary>
    MaskSolidBrushOnly = Contents.Solid | Contents.Window | Contents.PassBullets,

    /// <summary>Player movement collision (world+brush only, no monsters)</summary>
    MaskPlayerSolidBrushOnly = Contents.Solid | Contents.Window | Contents.PlayerClip | Contents.PassBullets,

    /// <summary>NPC movement collision (world+brush only, no monsters)</summary>
    MaskNpcSolidBrushOnly = Contents.Solid | Contents.Window | Contents.NpcClip | Contents.PassBullets
}