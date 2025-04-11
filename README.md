# CS2TraceRay
A trace ray library developed for use in Counter Strike 2, in conjunction with the CounterStrikeSharp API. This enables the use of trace ray with TraceMask, Contents and skip enums.

If you want to donate or need a help about plugin, you can contact me in discord private/server

Discord nickname: schwarper

Discord link : Discord server

# Nuget
[![NuGet Badge](https://img.shields.io/nuget/v/CS2TraceRay)](https://www.nuget.org/packages/CS2TraceRay)
[![NuGet-Badge](https://img.shields.io/nuget/dt/CS2TraceRay)](https://www.nuget.org/packages/CS2TraceRay)

# Example
[TraceRay Example](https://github.com/schwarper/CS2TraceRay/blob/main/CS2TraceRayExample/CS2TraceRayExample.cs)
```csharp
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
```
