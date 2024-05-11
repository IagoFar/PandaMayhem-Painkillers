using Exiled.API.Features;

public class PandaMayhem_Painkillers : Plugin<Config>
{
    public EventHandlers EventHandler;

    public override void OnEnabled()
    {
        EventHandler = new EventHandlers(Config);
        Exiled.Events.Handlers.Player.UsingItem += EventHandler.EatingPainkillers;
        base.OnEnabled();
    }

    public override void OnDisabled()
    {
        Exiled.Events.Handlers.Player.UsingItem -= EventHandler.EatingPainkillers;
        EventHandler = null;
        base.OnDisabled();
    }
}