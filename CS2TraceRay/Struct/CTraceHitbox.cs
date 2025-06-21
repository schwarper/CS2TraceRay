using System.Runtime.InteropServices;

namespace CS2TraceRay.Struct;

/// <summary>
/// Represents trace hitbox information including hit group and hitbox ID.
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 0x44)]
public struct CTraceHitbox
{
    /// <summary>
    /// The hit group that was hit by the trace.
    /// Common values:
    /// 0 = Generic
    /// 1 = Head
    /// 2 = Chest
    /// 3 = Stomach
    /// 4 = Left Arm
    /// 5 = Right Arm
    /// 6 = Left Leg
    /// 7 = Right Leg
    /// </summary>
    [FieldOffset(0x38)]
    public int HitGroup;

    /// <summary>
    /// The specific hitbox ID that was hit by the trace.
    /// Hitbox IDs are model-specific and correspond to hitboxes defined in the model.
    /// </summary>
    [FieldOffset(0x40)]
    public int HitboxId;
}