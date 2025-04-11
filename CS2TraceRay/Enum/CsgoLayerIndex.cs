namespace CS2TraceRay.Enum;

/// <summary>
/// Specific layer indices used for content masking
/// </summary>
public enum CsgoLayerIndex
{
    /// <summary>Team 1 layer</summary>
    Team1 = StandardLayerIndex.FirstModSpecific,

    /// <summary>Team 2 layer</summary>
    Team2,

    /// <summary>Grenade collision layer</summary>
    GrenadeClip,

    /// <summary>Drone collision layer</summary>
    DroneClip,

    /// <summary>Movable physics objects layer</summary>
    Moveable,

    /// <summary>Opaque surfaces layer</summary>
    Opaque,

    /// <summary>Monster/NPC layer</summary>
    Monster,

    /// <summary>Unused/reserved layer</summary>
    UnusedLayer,

    /// <summary>Thrown grenade entities layer</summary>
    ThrownGrenade
}