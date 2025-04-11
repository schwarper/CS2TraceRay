using System;

namespace CS2TraceRay.Enum;

/// <summary>
/// Bitmask flags representing collision layers and content types in CS2.
/// Used for trace operations to filter what should be hit.
/// </summary>
[Flags]
public enum Contents : ulong
{
    /// <summary>Empty</summary>
    Empty = 0,

    /// <summary>Solid</summary>
    Solid = 1ul << LayerIndex.Solid,
    /// <summary>Hitbox</summary>
    Hitbox = 1ul << LayerIndex.Hitbox,
    /// <summary>Trigger</summary>
    Trigger = 1ul << LayerIndex.Trigger,
    /// <summary>Sky</summary>
    Sky = 1ul << LayerIndex.Sky,

    /// <summary>PlayerClip</summary>
    PlayerClip = 1ul << StandardLayerIndex.PlayerClip,
    /// <summary>NpcClip</summary>
    NpcClip = 1ul << StandardLayerIndex.NpcClip,
    /// <summary>BlockLos</summary>
    BlockLos = 1ul << StandardLayerIndex.BlockLos,
    /// <summary>BlockLight</summary>
    BlockLight = 1ul << StandardLayerIndex.BlockLight,
    /// <summary>Ladder</summary>
    Ladder = 1ul << StandardLayerIndex.Ladder,
    /// <summary>Pickup</summary>
    Pickup = 1ul << StandardLayerIndex.Pickup,
    /// <summary>BlockSound</summary>
    BlockSound = 1ul << StandardLayerIndex.BlockSound,
    /// <summary>NoDraw</summary>
    NoDraw = 1ul << StandardLayerIndex.NoDraw,
    /// <summary>Window</summary>
    Window = 1ul << StandardLayerIndex.Window,
    /// <summary>PassBullets</summary>
    PassBullets = 1ul << StandardLayerIndex.PassBullets,
    /// <summary>WorldGeometry</summary>
    WorldGeometry = 1ul << StandardLayerIndex.WorldGeometry,
    /// <summary>Water</summary>
    Water = 1ul << StandardLayerIndex.Water,
    /// <summary>Slime</summary>
    Slime = 1ul << StandardLayerIndex.Slime,
    /// <summary>TouchAll</summary>
    TouchAll = 1ul << StandardLayerIndex.TouchAll,
    /// <summary>Player</summary>
    Player = 1ul << StandardLayerIndex.Player,
    /// <summary>Npc</summary>
    Npc = 1ul << StandardLayerIndex.Npc,
    /// <summary>Debris</summary>
    Debris = 1ul << StandardLayerIndex.Debris,
    /// <summary>PhysicsProp</summary>
    PhysicsProp = 1ul << StandardLayerIndex.PhysicsProp,
    /// <summary>NavIgnore</summary>
    NavIgnore = 1ul << StandardLayerIndex.NavIgnore,
    /// <summary>NavLocalIgnore</summary>
    NavLocalIgnore = 1ul << StandardLayerIndex.NavLocalIgnore,
    /// <summary>PostProcessingVolume</summary>
    PostProcessingVolume = 1ul << StandardLayerIndex.PostProcessingVolume,
    /// <summary>UnusedLayer3</summary>
    UnusedLayer3 = 1ul << StandardLayerIndex.UnusedLayer3,
    /// <summary>CarriedObject</summary>
    CarriedObject = 1ul << StandardLayerIndex.CarriedObject,
    /// <summary>Pushaway</summary>
    Pushaway = 1ul << StandardLayerIndex.Pushaway,
    /// <summary>ServerEntityOnClient</summary>
    ServerEntityOnClient = 1ul << StandardLayerIndex.ServerEntityOnClient,
    /// <summary>CarriedWeapon</summary>
    CarriedWeapon = 1ul << StandardLayerIndex.CarriedWeapon,
    /// <summary>StaticLevel</summary>
    StaticLevel = 1ul << StandardLayerIndex.StaticLevel,

    /// <summary>CsgoTeam1</summary>
    CsgoTeam1 = 1ul << CsgoLayerIndex.Team1,
    /// <summary>CsgoTeam2</summary>
    CsgoTeam2 = 1ul << CsgoLayerIndex.Team2,
    /// <summary>CsgoGrenadeClip</summary>
    CsgoGrenadeClip = 1ul << CsgoLayerIndex.GrenadeClip,
    /// <summary>CsgoDroneClip</summary>
    CsgoDroneClip = 1ul << CsgoLayerIndex.DroneClip,
    /// <summary>CsgoMoveable</summary>
    CsgoMoveable = 1ul << CsgoLayerIndex.Moveable,
    /// <summary>CsgoOpaque</summary>
    CsgoOpaque = 1ul << CsgoLayerIndex.Opaque,
    /// <summary>CsgoMonster</summary>
    CsgoMonster = 1ul << CsgoLayerIndex.Monster,
    /// <summary>CsgoUnusedLayer</summary>
    CsgoUnusedLayer = 1ul << CsgoLayerIndex.UnusedLayer,
    /// <summary>CsgoThrownGrenade</summary>
    CsgoThrownGrenade = 1ul << CsgoLayerIndex.ThrownGrenade,
}