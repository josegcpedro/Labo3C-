class Equipment : IHeroModifier, IBuyable
{
    public string Name  { get; private set; } 
    public string? Description  { get; private set; } 
    public float HealthModifier  { get; private set; } 
    public float SpeedModifier  { get; private set; } 
    public float ForceModifier  { get; private set; } 
    public float AgilityModifier  { get; private set; } 

    public Equipment(
        string name,
        string description,
        float healthModifier,
        float speedModifier,
        float forceModifier,
        float agilityModifier
    )
    {
        Name = name;
        Description = description;
        HealthModifier = healthModifier;
        SpeedModifier = speedModifier;
        ForceModifier = forceModifier;
        AgilityModifier = agilityModifier;
    }

    public IBuyable Clone()
    {
        return new Equipment(
            Name,
            Description,
            HealthModifier,
            SpeedModifier,
            ForceModifier,
            AgilityModifier
        );
    }
}