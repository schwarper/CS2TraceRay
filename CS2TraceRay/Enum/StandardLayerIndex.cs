namespace CS2TraceRay.Enum;

/// <summary>
/// Standard layer indices used for content masking
/// </summary>
public enum StandardLayerIndex
{
    /// <summary>PlayerClip</summary>
    PlayerClip = LayerIndex.FirstUser,
    /// <summary>NpcClip</summary>
    NpcClip,
    /// <summary>BlockLos</summary>
    BlockLos,
    /// <summary>BlockLight</summary>
    BlockLight,
    /// <summary>Ladder</summary>
    Ladder,
    /// <summary>Pickup</summary>
    Pickup,
    /// <summary>BlockSound</summary>
    BlockSound,
    /// <summary>NoDraw</summary>
    NoDraw,
    /// <summary>Window</summary>
    Window,
    /// <summary>PassBullets</summary>
    PassBullets,
    /// <summary>WorldGeometry</summary>
    WorldGeometry,
    /// <summary>Water</summary>
    Water,
    /// <summary>Slime</summary>
    Slime,
    /// <summary>TouchAll</summary>
    TouchAll,
    /// <summary>Player</summary>
    Player,
    /// <summary>Npc</summary>
    Npc,
    /// <summary>Debris</summary>
    Debris,
    /// <summary>PhysicsProp</summary>
    PhysicsProp,
    /// <summary>NavIgnore</summary>
    NavIgnore,
    /// <summary>NavLocalIgnore</summary>
    NavLocalIgnore,
    /// <summary>PostProcessingVolume</summary>
    PostProcessingVolume,
    /// <summary>UnusedLayer3</summary>
    UnusedLayer3,
    /// <summary>CarriedObject</summary>
    CarriedObject,
    /// <summary>Pushaway</summary>
    Pushaway,
    /// <summary>ServerEntityOnClient</summary>
    ServerEntityOnClient,
    /// <summary>CarriedWeapon</summary>
    CarriedWeapon,
    /// <summary>StaticLevel</summary>
    StaticLevel,
    /// <summary>FirstModSpecific</summary>
    FirstModSpecific
}