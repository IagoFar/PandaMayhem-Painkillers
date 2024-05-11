using Exiled.Events.EventArgs.Player;
using Exiled.API.Enums;
using UnityEngine;
using CustomPlayerEffects;

public class EventHandlers
{
    private readonly Config _config;

    public EventHandlers(Config config)
    {
        _config = config;
    }

    public void EatingPainkillers(UsingItemEventArgs ev)
    {
        if (ev.Item.Type == ItemType.Painkillers)
        {
            float deathChance = _config.DeathPercentage / 100f;

            if (UnityEngine.Random.value <= deathChance)
            {
                ev.Player.Kill("Unsafe painkillers");
                ev.Player.Broadcast(5, "Ups, that wasn't medicine");
            }
            else
            {
                byte currentMovementSpeed = ev.Player.GetEffectIntensity<MovementBoost>();
                byte additionalMovementSpeed = 5;
                byte newMovementSpeed = (byte)Mathf.Min(currentMovementSpeed + additionalMovementSpeed, 255);

                ev.Player.ChangeEffectIntensity(EffectType.MovementBoost, newMovementSpeed);
            }
            
        }
    }
}