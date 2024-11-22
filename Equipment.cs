class Equipment : IHeroModifier, IBuyable
{
    public string Name  { get; private set; } 
    public string? Description  { get; private set; } 
    public float HealthModifier  { get; private set; } 
    public float SpeedModifier  { get; private set; } 
    public float ForceModifier  { get; private set; } 
    public float AgilityModifier  { get; private set; } 
    public double HealthMultiplier { get; set; } = 1;
    public double SpeedMultiplier { get; set; } = 1;
    public double ForceMultiplier { get; set; } = 1;
    public double AgilityMultiplier { get; set; } = 1;

    public Equipment(
        string name,
        string description,
        float healthModifier = 0, // Par défaut à 0
        float speedModifier = 0,
        float forceModifier = 0,
        float agilityModifier = 0,
        double healthMultiplier = 1, 
        double speedMultiplier = 1, 
        double forceMultiplier = 1, 
        double agilityMultiplier = 1
    )
    {
        Name = name;
        Description = description;
        HealthModifier = healthModifier;
        SpeedModifier = speedModifier;
        ForceModifier = forceModifier;
        AgilityModifier = agilityModifier;
        HealthMultiplier = healthMultiplier;
        SpeedMultiplier = speedMultiplier;
        ForceMultiplier = forceMultiplier;
        AgilityMultiplier = agilityMultiplier;
    }

    public IBuyable Clone()
    {
        return new Equipment(
            Name,
            Description,
            HealthModifier,
            SpeedModifier,
            ForceModifier,
            AgilityModifier,
            HealthMultiplier,
            SpeedMultiplier,
            ForceMultiplier,
            AgilityMultiplier
        );
    }
}