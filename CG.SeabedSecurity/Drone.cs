using System;
using System.Collections.Generic;

public class Drone
{
    public int Id { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Emergency { get; set; }
    public int Battery { get; set; }

    public void Action(List<Creature> AvailableCreatures)
    {
        Creature closestCreature = AvailableCreatures[0];
        double distance = 10000;

        foreach (var creature in AvailableCreatures)
        {
            double creatureDis = Util.CalculateDistance(X, Y, creature.Nx, creature.Ny);
            if (distance > creatureDis)
            {
                distance = creatureDis;
                closestCreature = creature;
            }
        }

        if (distance <= 800)
        {
            Console.WriteLine($"MOVE {closestCreature.Nx} {closestCreature.Ny} 0");
            Console.Error.WriteLine($"Target: {closestCreature.Id}, Close: {distance}");
        }
        else if (distance <= 2000)
        {
            Console.WriteLine($"MOVE {closestCreature.Nx} {closestCreature.Ny} 1");
            Console.Error.WriteLine($"Target: {closestCreature.Id}, Far: {distance}");
        }
        else
        {
            Console.WriteLine($"MOVE {closestCreature.Nx} {closestCreature.Ny} 0");
            Console.Error.WriteLine($"Target: {closestCreature.Id}, Too Far: {distance}");
        }

        //Console.WriteLine($"MOVE {closestCreature.Nx} {closestCreature.Ny} 1");  // MOVE <x> <y> <light (1|0)> | WAIT <light (1|0)>
    }
}