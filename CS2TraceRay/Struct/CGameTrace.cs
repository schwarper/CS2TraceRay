using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace CS2TraceRay.Struct;

/// <summary>
/// Represents the results of a game trace operation, containing information about what was hit.
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 0xB8)]
public unsafe struct CGameTrace
{
    /// <summary>
    /// The surface that was hit by the trace.
    /// </summary>
    [FieldOffset(0x00)] public IntPtr Surface;

    /// <summary>
    /// The entity that was hit by the trace.
    /// </summary>
    [FieldOffset(0x08)] public IntPtr HitEntity;

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
}