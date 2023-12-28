using System.Collections.Generic;

public class GameCreatures
{
    public List<Creature> Creatures { get; set; } = new List<Creature>();

    public GameCreatures()
    {
        var creatureCount = Util.GetNumericValue();
        for (int i = 0; i < creatureCount; i++)
        {
            var data = Util.GetNumericValues();
            Creatures.Add(new Creature { Id = data[0], Color = data[1], CreatureType = data[2] });
        }
    }

    public void UpdateVisibleCreatures()
    {
        var visibleCreatureCount = Util.GetNumericValue();
        for (int i = 0; i < visibleCreatureCount; i++)
        {
            var data = Util.GetNumericValues();
            Creature creature = Creatures.Find(x => x.Id == data[0]);
            creature.UpdateCreature(data[1], data[2], data[3], data[4]); // update creature: x, y, vx, vy
        }
    }

    public Creature CreatureById(int Id)
    {
        return Creatures.Find(x => x.Id == Id);
    }
}