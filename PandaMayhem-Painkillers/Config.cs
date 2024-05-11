using Exiled.API.Interfaces;

public class Config : IConfig
{
    public bool IsEnabled { get; set; }
    public bool Debug { get; set; }
    public int DeathPercentage { get; set; } = 5;
    public int MovementBoost { get; set; } = 5;
}