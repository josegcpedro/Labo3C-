
using ConsoleTables;
class Weapon : IBuyable, IWeapon
{
    public List<string> PromptHeader { get; } = new List<string>(){ "#", "Nom", "Dégats mininimum", "Dégats maximum", "Utilisations restantes" };
    public string Name  { get; private set; } 
    public ICanFight? Owner { get; set; }
    public string? Description  { get; private set; } 
    public float HealthModifier  { get; private set; } 
    public float SpeedModifier  { get; private set; } 
    public float ForceModifier  { get; private set; } 
    public float AgilityModifier  { get; private set; } 
    public int MinDamage  { get; private set; } 
    public int MaxDamage  { get; private set; } 
    public int ComputedMinDamage 
    {
        get =>  Owner == null ? MinDamage : (int)Math.Round(MinDamage * Owner.Force / 100f);
    }
    public int ComputedMaxDamage 
    {
        get =>  Owner == null ? MaxDamage : (int)Math.Round(MaxDamage * Owner.Force / 100f);
    }
    public int MaxUses  { get; private set; } 
    public int Uses  { get; private set; } 

    private Random _random = new Random();

    public Weapon(
        string name,
        string description,
        float healthModifier,
        float speedModifier,
        float forceModifier,
        float agilityModifier,
        int minDamage,
        int maxDamage,
        int maxUses
        )
    {
        Name = name;
        Description = description;
        HealthModifier = healthModifier;
        SpeedModifier = speedModifier;
        ForceModifier = forceModifier;
        AgilityModifier = agilityModifier;
        MinDamage = minDamage;
        MaxDamage = maxDamage;
        MaxUses = maxUses;
    }

    public Weapon(
        string name,
        string description,
        int minDamage,
        int maxDamage,
        int maxUses
    ) : this(name, description, 1, 1, 1, 1, minDamage, maxDamage, maxUses){ }

    public string Use(FighterSlot target)
    {
        int damage = 0;
        if (Owner != null && Uses < MaxUses)
        {
            damage = _random.Next(ComputedMinDamage, ComputedMaxDamage + 1);
            Uses++;
        }
        
        bool hasHit = target.Hit(damage);
        return BuildUsageMessage(target.Fighter, damage, !hasHit);
    }

    private string BuildUsageMessage(ICanFight target, int damage, bool dodged)
    {
        string message = 
            (Owner == null ? "Quelqu'un" : Owner.NickName) + 
            " frappe " + target.NickName +
            " avec " + Name;
        if (dodged) message += " mais " + target.NickName + " esquive le coup.";
        else message += " et lui inflige " + damage + " dégats.";
        
        return message;
    }

    public void FormatPrompt(int index, ConsoleTable table, string context)
    {
        table.AddRow(
            index,
            Name,
            ComputedMinDamage,
            ComputedMaxDamage,
            (MaxUses - Uses) + "/" + MaxUses);
    }

    public IBuyable Clone()
    {
        return new Weapon(
            Name,
            Description,
            HealthModifier,
            SpeedModifier,
            ForceModifier,
            AgilityModifier,
            MinDamage,
            MaxDamage,
            MaxUses
        );
    }
}