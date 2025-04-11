using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Utils;
using CS2TraceRay.Class;
using CS2TraceRay.Enum;

namespace CS2TraceRayExample;

public class Test : BasePlugin
{
    public override string ModuleName => "TraceRay Example";
    public override string ModuleVersion => "CS2TraceRay";
    public override string ModuleAuthor => "schwarper";

    [ConsoleCommand("css_test_ground")]
    public void OnTestGround(CCSPlayerController? player, CommandInfo _)
    {
        if (player == null)
            return;

        float groundDistance = GetGroundDistance(player);
        Server.PrintToChatAll($"Ground distance => {groundDistance}");
    }

    [ConsoleCommand("css_test_player")]
    public void OnTestPlayer(CCSPlayerController? player, CommandInfo _)
    {
        if (player == null)
            return;

        CCSPlayerController? target = GetPlayer(player);
        if (target == null)
        {
            Server.PrintToChatAll($"Target cannot be found.");
            return;
        }

        Server.PrintToChatAll($"Player => {target.PlayerName}");
    }

    [ConsoleCommand("css_test_weapon")]
    public void OnTestWeapon(CCSPlayerController? player, CommandInfo _)
    {
        if (player == null)
            return;

        CBasePlayerWeapon? target = GetWeapon(player);
        if (target == null)
        {
            Server.PrintToChatAll($"Weapon cannot be found.");
            return;
        }

        Server.PrintToChatAll($"Weapon => {target.DesignerName}");
    }

    private static float GetGroundDistance(CCSPlayerController player)
    {
        if (player.PlayerPawn.Value is not { } playerPawn ||
            playerPawn.GroundEntity.IsValid is true ||
            playerPawn.AbsOrigin is not { } absOrigin)
            return 0.0f;

        CGameTrace _trace = TraceRay.TraceShape(absOrigin, new QAngle(90, 0, 0), TraceMask.MaskAll, Contents.Sky, 0);
        return _trace.Distance;
    }

    private static CCSPlayerController? GetPlayer(CCSPlayerController player)
    {
        if (player.PlayerPawn.Value is not { } playerPawn)
            return null;

        Vector eyePos = GetEyePosition(player);
        QAngle eyeAngles = playerPawn.EyeAngles;
        CGameTrace _trace = TraceRay.TraceShape(eyePos, eyeAngles, TraceMask.MaskShot, Contents.Player, player);

        return _trace.HitPlayer(out CCSPlayerController? target) && target != null ? target : null;
    }

    private static CBasePlayerWeapon? GetWeapon(CCSPlayerController player)
    {
        if (player.PlayerPawn.Value is not { } playerPawn)
            return null;

        Vector eyePos = GetEyePosition(player);
        QAngle eyeAngles = playerPawn.EyeAngles;
        CGameTrace _trace = TraceRay.TraceShape(eyePos, eyeAngles, TraceMask.MaskShot, Contents.CarriedWeapon, player);

        return _trace.HitWeapon(out CBasePlayerWeapon? weapon) && weapon != null ? weapon : null;
    }

    public static Vector GetEyePosition(CCSPlayerController player)
    {
        Vector absorigin = player.PlayerPawn.Value!.AbsOrigin!;
        CPlayer_CameraServices camera = player.PlayerPawn.Value!.CameraServices!;

        return new Vector(absorigin.X, absorigin.Y, absorigin.Z + camera.OldPlayerViewOffsetZ);
    }
}