using System.Collections.Generic;

public class GameCreatures
{
    public List<Creature> Creatures { get; set; } = new List<Creature>();
    public int CreatureCount { get; set; } = 0;
    public int VisibleCreatureCount { get; set; } = 0;

    public GameCreatures(int creatureCount)
    {
        CreatureCount = creatureCount;
    }

    public void Add(int id, int color, int creatureType)
    {
        Creatures.Add(new Creature
        {
            Id = id,
            Color = color,
            CreatureType = creatureType
        });
    }

    public void UpdateRadar(int id, string radar)
    {
        Creature creature = Creatures.Find(x => x.Id == id);
        creature.UpdateRadar(radar);
    }

    public void UpdateLocVel(int id, int x, int y, int vx, int vy)
    {
        Creature creature = Creatures.Find(x => x.Id == id);
        creature.UpdateLocVel(x, y, vx, vy);
    }

    public Creature CreatureById(int Id)
    {
        return Creatures.Find(x => x.Id == Id);
    }
}