using CounterStrikeSharp.API.Core;
using CS2TraceRay.Enum;
using System;
using System.Numerics;

namespace CS2TraceRay.Class;

/// <summary>
/// Provides extension methods for <see cref="CGameTrace"/> class
/// </summary>
public static class GameTraceExtensions
{
    /// <summary>
    /// Determines if the trace hit anything.
    /// </summary>
    public static bool DidHit(this CGameTrace gameTrace)
    {
        return gameTrace.Fraction < 1.0f && !gameTrace.AllSolid;
    }

    /// <summary>
    /// Gets the distance between the start and end positions of the trace.
    /// </summary>
    public static float Distance(this CGameTrace gametrace)
    {
        return Vector3.Distance(gametrace.StartPos, gametrace.EndPos);
    }

    /// <summary>
    /// Gets the normalized direction vector of the trace.
    /// </summary>
    public static Vector3 Direction(this CGameTrace gametrace)
    {
        return Vector3.Normalize(gametrace.EndPos - gametrace.StartPos);
    }

    /// <summary>
    /// Attempts to get the entity of type <typeparamref name="T"/> if the trace hit an entity
    /// with a designer name matching the specified pattern.
    /// </summary>
    /// <typeparam name="T">The type of entity to check for.</typeparam>
    /// <param name="gametrace">The gametrace</param>
    /// <param name="entity">The entity that was hit, if any.</param>
    /// <param name="designerName">The designer name pattern to match.</param>
    /// <param name="matchType">The type of matching to perform.</param>
    /// <returns>True if an entity of type <typeparamref name="T"/> matching the pattern was hit, false otherwise.</returns>
    public static bool HitEntityByDesignerName<T>(this CGameTrace gametrace, out T? entity, string designerName, DesignerNameMatchType matchType = DesignerNameMatchType.Equals) where T : CEntityInstance
    {
        if ((T?)Activator.CreateInstance(typeof(T), gametrace.HitEntity) is { } entityInstance)
        {
            bool isMatch = matchType switch
            {
                DesignerNameMatchType.Equals => entityInstance.DesignerName == designerName,
                DesignerNameMatchType.StartsWith => entityInstance.DesignerName.StartsWith(designerName, StringComparison.OrdinalIgnoreCase),
                DesignerNameMatchType.EndsWith => entityInstance.DesignerName.EndsWith(designerName, StringComparison.OrdinalIgnoreCase),
                _ => false
            };

            if (isMatch)
            {
                entity = entityInstance;
                return true;
            }
        }

        entity = null;
        return false;
    }

    /// <summary>
    /// Attempts to get the player controller if the trace hit a player.
    /// </summary>
    /// <param name="gametrace">The gametrace</param>
    /// <param name="player">The player controller that was hit, if any.</param>
    /// <returns>True if a player was hit, false otherwise.</returns>
    public static bool HitPlayer(this CGameTrace gametrace, out CCSPlayerController? player)
    {
        if (gametrace.HitEntityByDesignerName(out CCSPlayerPawn? playerPawn, "player", DesignerNameMatchType.Equals))
        {
            player = playerPawn?.OriginalController.Value;
            return player != null;
        }

        player = null;
        return false;
    }

    /// <summary>
    /// Attempts to get the weapon if the trace hit a weapon.
    /// </summary>
    /// <param name="gametrace">The gametrace</param>
    /// <param name="weapon">The weapon that was hit, if any.</param>
    /// <returns>True if a weapon was hit, false otherwise.</returns>
    public static bool HitWeapon(this CGameTrace gametrace, out CBasePlayerWeapon? weapon)
    {
        return gametrace.HitEntityByDesignerName(out weapon, "weapon_", DesignerNameMatchType.StartsWith);
    }

    /// <summary>
    /// Attempts to get the chicken if the trace hit a chicken.
    /// </summary>
    /// <param name="gametrace">The gametrace</param>
    /// <param name="chicken">The chicken that was hit, if any.</param>
    /// <returns>True if a chicken was hit, false otherwise.</returns>
    public static bool HitChicken(this CGameTrace gametrace, out CChicken? chicken)
    {
        return gametrace.HitEntityByDesignerName(out chicken, "chicken", DesignerNameMatchType.Equals);
    }

    /// <summary>
    /// Attempts to get the button if the trace hit a button.
    /// </summary>
    /// <param name="gametrace">The gametrace</param>
    /// <param name="button">The button that was hit, if any.</param>
    /// <returns>True if a button was hit, false otherwise.</returns>
    public static bool HitButton(this CGameTrace gametrace, out CBaseButton? button)
    {
        return gametrace.HitEntityByDesignerName(out button, "func_door", DesignerNameMatchType.Equals);
    }

    /// <summary>
    /// Attempts to get the buyzone if the trace hit a buyzone.
    /// </summary>
    /// <param name="gametrace">The gametrace</param>
    /// <param name="buyzone">The buyzone that was hit, if any.</param>
    /// <returns>True if a buyzone was hit, false otherwise.</returns>
    public static bool HitBuyzone(this CGameTrace gametrace, out CBuyZone? buyzone)
    {
        return gametrace.HitEntityByDesignerName(out buyzone, "func_buyzone", DesignerNameMatchType.Equals);
    }

    /// <summary>
    /// Attempts to get the sky if the trace hit the sky.
    /// </summary>
    /// <param name="gametrace">The gametrace</param>
    /// <param name="sky">The sky that was hit, if any.</param>
    /// <returns>True if the sky was hit, false otherwise.</returns>
    public static bool HitSky(this CGameTrace gametrace, out CEnvSky? sky)
    {
        return gametrace.HitEntityByDesignerName(out sky, "env_sky", DesignerNameMatchType.Equals);
    }

    /// <summary>
    /// Attempts to get the door if the trace hit a door.
    /// </summary>
    /// <param name="gametrace">The gametrace</param>
    /// <param name="door">The door that was hit, if any.</param>
    /// <returns>True if a door was hit, false otherwise.</returns>
    public static bool HitDoor(this CGameTrace gametrace, out CBaseDoor? door)
    {
        return gametrace.HitEntityByDesignerName(out door, "func_door", DesignerNameMatchType.Equals);
    }

    /// <summary>
    /// Attempts to get the rotating door if the trace hit a rotating door.
    /// </summary>
    /// <param name="gametrace">The gametrace</param>
    /// <param name="door">The rotating door that was hit, if any.</param>
    /// <returns>True if a rotating door was hit, false otherwise.</returns>
    public static bool HitDoor(this CGameTrace gametrace, out CRotDoor? door)
    {
        return gametrace.HitEntityByDesignerName(out door, "func_door_rotating", DesignerNameMatchType.Equals);
    }

    /// <summary>
    /// Attempts to get the ladder if the trace hit a ladder.
    /// </summary>
    /// <param name="gametrace">The gametrace</param>
    /// <param name="ladder">The ladder that was hit, if any.</param>
    /// <returns>True if a ladder was hit, false otherwise.</returns>
    public static bool HitLadder(this CGameTrace gametrace, out CFuncLadder? ladder)
    {
        return gametrace.HitEntityByDesignerName(out ladder, "func_ladder", DesignerNameMatchType.Equals);
    }

    /// <summary>
    /// Attempts to get the grenade if the trace hit a grenade.
    /// </summary>
    /// <param name="gametrace">The gametrace</param>
    /// <param name="grenade">The grenade that was hit, if any.</param>
    /// <returns>True if a grenade was hit, false otherwise.</returns>
    public static bool HitGrenade(this CGameTrace gametrace, out CBaseCSGrenade? grenade)
    {
        return gametrace.HitEntityByDesignerName(out grenade, "grenade", DesignerNameMatchType.Equals);
    }

    /// <summary>
    /// Attempts to get the planted C4 if the trace hit a planted C4.
    /// </summary>
    /// <param name="gametrace">The gametrace</param>
    /// <param name="c4">The planted C4 that was hit, if any.</param>
    /// <returns>True if a planted C4 was hit, false otherwise.</returns>
    public static bool HitPlantedC4(this CGameTrace gametrace, out CPlantedC4? c4)
    {
        return gametrace.HitEntityByDesignerName(out c4, "planted_c4", DesignerNameMatchType.Equals);
    }

    /// <summary>
    /// Attempts to get the world text if the trace hit a point world text.
    /// </summary>
    /// <param name="gametrace">The gametrace</param>
    /// <param name="pointWorldText">The point world text that was hit, if any.</param>
    /// <returns>True if a point world text was hit, false otherwise.</returns>
    public static bool HitPointWorldText(this CGameTrace gametrace, out CPointWorldText? pointWorldText)
    {
        return gametrace.HitEntityByDesignerName(out pointWorldText, "point_worldtext", DesignerNameMatchType.Equals);
    }

    /// <summary>
    /// Attempts to get the C4 if the trace hit a C4 weapon.
    /// </summary>
    /// <param name="gametrace">The gametrace</param>
    /// <param name="c4">The C4 weapon that was hit, if any.</param>
    /// <returns>True if a C4 weapon was hit, false otherwise.</returns>
    public static bool HitC4(this CGameTrace gametrace, out CC4? c4)
    {
        return gametrace.HitEntityByDesignerName(out c4, "weapon_c4", DesignerNameMatchType.Equals);
    }

    /// <summary>
    /// Attempts to get the world entity if the trace hit the world.
    /// </summary>
    /// <param name="gametrace">The gametrace</param>
    /// <param name="world">The world entity that was hit, if any.</param>
    /// <returns>True if the world was hit, false otherwise.</returns>
    public static bool HitWorld(this CGameTrace gametrace, out CWorld? world)
    {
        return gametrace.HitEntityByDesignerName(out world, "worldent", DesignerNameMatchType.Equals);
    }
}