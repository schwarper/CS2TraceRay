using System;
using System.Runtime.InteropServices;

namespace CS2TraceRay.Struct;

/// <summary>
/// Represents a filter used during ray tracing operations to determine which entities should be included or excluded from the trace.
/// This structure closely reflects the trace filter system of the Source 2 engine.
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 72)]
public unsafe struct CTraceFilter
{
    /// <summary>
    /// Delegate pointing to the virtual destructor for the filter object.
    /// </summary>
    public delegate void DestructorDelegate(CTraceFilter* filter);

    /// <summary>
    /// Delegate used to evaluate whether a specific entity should be hit by the ray trace.
    /// </summary>
    public delegate bool ShouldHitEntityDelegate(CTraceFilter* filter, IntPtr entity);

    /// <summary>
    /// Initializes a new instance of the <see cref="CTraceFilter"/> struct, configuring it to ignore specific entities and owners.
    /// </summary>
    /// <param name="entityIdToIgnore">The entity ID to exclude from the trace.</param>
    /// <param name="ownerId">Optional owner ID to exclude. Default is 0xFFFFFFFF (none).</param>
    /// <param name="hierarchyId">Optional hierarchy ID to exclude. Default is 0xFFFF (none).</param>
    public CTraceFilter(uint entityIdToIgnore, uint ownerId = 0xFFFFFFFF, ushort hierarchyId = 0xFFFF)
    {
        Vtable = null;

        m_nInteractsWith = 0;
        m_nInteractsExclude = 0x20311;
        m_nInteractsAs = 0x40000;

        m_nOwnerIdsToIgnore[0] = ownerId;
        m_nOwnerIdsToIgnore[1] = 0xFFFFFFFF;

        m_nEntityIdsToIgnore[0] = entityIdToIgnore;
        m_nEntityIdsToIgnore[1] = 0xFFFFFFFF;

        m_nHierarchyIds[0] = hierarchyId;
        m_nHierarchyIds[1] = 0xFFFF;

        m_nObjectSetMask = 7;
        m_nCollisionGroup = 4;
        m_nBits = 0b01000001;

        m_bHitEntities = true;
        m_bHitTriggers = true;
        m_bTestHitboxes = true;
        m_bTraceComplexEntities = false;
        m_bOnlyHitIfHasPhysics = false;
        m_bIterateEntities = true;
    }

    /// <summary>
    /// Pointer to the virtual function table used internally by the engine.
    /// </summary>
    [FieldOffset(0x00)] public void* Vtable;

    /// <summary>
    /// Mask of interaction types to include in the trace.
    /// </summary>
    [FieldOffset(0x08)] public ulong m_nInteractsWith;

    /// <summary>
    /// Mask of interaction types to exclude from the trace.
    /// </summary>
    [FieldOffset(0x10)] public ulong m_nInteractsExclude;

    /// <summary>
    /// Mask of interaction types that this object interacts as.
    /// </summary>
    [FieldOffset(0x18)] public ulong m_nInteractsAs;

    /// <summary>
    /// Array of up to two owner IDs to ignore during the trace.
    /// </summary>
    [FieldOffset(0x20)] public fixed uint m_nOwnerIdsToIgnore[2];

    /// <summary>
    /// Array of up to two entity IDs to ignore during the trace.
    /// </summary>
    [FieldOffset(0x28)] public fixed uint m_nEntityIdsToIgnore[2];

    /// <summary>
    /// Array of up to two hierarchy IDs to ignore during the trace.
    /// </summary>
    [FieldOffset(0x30)] public fixed ushort m_nHierarchyIds[2];

    /// <summary>
    /// Bitmask specifying which object sets should be considered.
    /// </summary>
    [FieldOffset(0x34)] public byte m_nObjectSetMask;

    /// <summary>
    /// Collision group the trace belongs to.
    /// </summary>
    [FieldOffset(0x35)] public byte m_nCollisionGroup;

    /// <summary>
    /// Miscellaneous behavior flags encoded as bit flags.
    /// </summary>
    [FieldOffset(0x36)] public byte m_nBits;

    /// <summary>
    /// Specifies whether entities should be included in the trace.
    /// </summary>
    [FieldOffset(0x37)] public bool m_bHitEntities;

    /// <summary>
    /// Specifies whether trigger volumes should be hit.
    /// </summary>
    [FieldOffset(0x38)] public bool m_bHitTriggers;

    /// <summary>
    /// Indicates whether hitboxes should be tested during the trace.
    /// </summary>
    [FieldOffset(0x39)] public bool m_bTestHitboxes;

    /// <summary>
    /// Indicates whether to trace through complex entities such as physics proxies.
    /// </summary>
    [FieldOffset(0x3A)] public bool m_bTraceComplexEntities;

    /// <summary>
    /// If set, only entities with physics will be considered in the trace.
    /// </summary>
    [FieldOffset(0x3B)] public bool m_bOnlyHitIfHasPhysics;

    /// <summary>
    /// Indicates whether the trace system should iterate over entities to apply filtering.
    /// </summary>
    [FieldOffset(0x3C)] public bool m_bIterateEntities;
}