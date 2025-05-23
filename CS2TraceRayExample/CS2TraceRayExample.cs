﻿using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Commands;
using CS2TraceRay.Class;
using CS2TraceRay.Enum;

namespace CS2TraceRayExample;

public class TraceRayExamplePlugin : BasePlugin
{
    public override string ModuleName => "TraceRay Example Plugin";
    public override string ModuleVersion => "1.0.0";
    public override string ModuleAuthor => "schwarper";
    public override string ModuleDescription => "Demonstrates CS2TraceRay functionality with practical examples";

    [ConsoleCommand("css_test_trace")]
    public void OnCommandTestTrace(CCSPlayerController? player, CommandInfo info)
    {
        if (player == null)
            return;

        CGameTrace? _trace = player.GetGameTraceByEyePosition(TraceMask.MaskAll, Contents.NoDraw, player);
        if (_trace == null)
        {
            player.PrintToChat("Trace failed - no valid trace results");
            return;
        }

        CEntityInstance entityInstance = new(_trace.Value.HitEntity);

        if (string.IsNullOrEmpty(entityInstance.DesignerName))
        {
            player.PrintToChat("Trace failed - no valid entity results");
            return;
        }

        player.PrintToChat($"Entity designername => {entityInstance.DesignerName}");
    }

    [ConsoleCommand("css_trace_ground", "Measures distance to ground below player")]
    public void OnCommandTraceGround(CCSPlayerController? player, CommandInfo info)
    {
        if (player == null)
            return;

        float groundDistance = player.GetGroundDistance();
        player.PrintToChat($"Ground distance: {groundDistance:F2}");
    }

    [ConsoleCommand("css_trace_player", "Traces from player's eyes to detect other players")]
    public void OnTracePlayerCommand(CCSPlayerController? player, CommandInfo command)
    {
        if (player == null) return;

        CGameTrace? trace = player.GetGameTraceByEyePosition(
            TraceMask.MaskShot,
            Contents.Player,
            player
        );

        if (!trace.HasValue)
        {
            player.PrintToChat("Trace failed - no valid trace results");
            return;
        }

        if (!trace.Value.HitPlayer(out CCSPlayerController? target) || target == null)
        {
            player.PrintToChat("No player detected in trace");
            return;
        }

        player.PrintToChat($"Detected player: {target.PlayerName} (Distance: {trace.Value.Distance():F2})");
    }

    [ConsoleCommand("css_trace_weapon", "Detects weapons in player's line of sight")]
    public void OnTraceWeaponCommand(CCSPlayerController? player, CommandInfo command)
    {
        if (player == null) return;

        CGameTrace? trace = player.GetGameTraceByEyePosition(
            TraceMask.MaskShot,
            Contents.CarriedWeapon,
            player
        );

        if (!trace.HasValue)
        {
            player.PrintToChat("Trace failed - no valid trace results");
            return;
        }

        if (!trace.Value.HitWeapon(out CBasePlayerWeapon? weapon) || weapon == null)
        {
            player.PrintToChat("No weapon detected in trace");
            return;
        }

        player.PrintToChat($"Detected weapon: {weapon.DesignerName} (Distance: {trace.Value.Distance():F2})");
    }

    [ConsoleCommand("css_trace_c4", "Detects planted C4 in player's line of sight")]
    public void OnTraceC4Command(CCSPlayerController? player, CommandInfo command)
    {
        if (player == null)
            return;

        CGameTrace? trace = player.GetGameTraceByEyePosition(
            TraceMask.MaskShot,
            Contents.CarriedWeapon,
            player
        );

        if (!trace.HasValue)
        {
            player.PrintToChat("Trace failed - no valid trace results");
            return;
        }

        if (!trace.Value.HitPlantedC4(out CPlantedC4? c4) || c4 == null)
        {
            player.PrintToChat("No planted c4 detected in trace");
            return;
        }

        player.PrintToChat($"Detected Planted C4 at distance: {trace.Value.Distance():F2}");
    }
}