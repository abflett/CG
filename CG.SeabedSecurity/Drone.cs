using System;
using System.Collections.Generic;
using System.Linq;

public class Drone
{
    public int Id { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Emergency { get; set; }
    public int Battery { get; set; }
    public List<Radar> Radars { get; set; } = new List<Radar>();


    public void UpsertRadar(int droneId, int creatureId, string location)
    {
        var radar = Radars.Find(x => x.CreatureId == creatureId);
        if (radar != null)
        {
            radar.DroneId = droneId;
            radar.RelativePosition = location;
        }
        else
        {
            Radars.Add(new Radar { DroneId = droneId, CreatureId = creatureId, RelativePosition = location });
        }
    }

    public void Action(List<Creature> AvailableCreatures)
    {
        var tlCount = 0;
        var trCount = 0;
        var blCount = 0;
        var brCount = 0;

        foreach (var creature in AvailableCreatures)
        {
            var radar = Radars.FirstOrDefault(x => x.CreatureId == creature.Id);
            if (radar.RelativePosition == "TL")
            {
                tlCount++;
            }
            else if (radar.RelativePosition == "TR")
            {
                trCount++;
            }
            else if (radar.RelativePosition == "BL")
            {
                blCount++;
            }
            else if (radar.RelativePosition == "BR")
            {
                brCount++;
            }
        }

        // Determine the direction with the highest count
        var highestCountDirection = GetHighestCountDirection(tlCount, trCount, blCount, brCount);

        // Print the corresponding Console.WriteLine statement
        switch (highestCountDirection)
        {
            case "TL":
                Console.WriteLine($"MOVE {X - 600} {Y - 600} 1");
                break;
            case "TR":
                Console.WriteLine($"MOVE {X + 600} {Y - 600} 1");
                break;
            case "BL":
                Console.WriteLine($"MOVE {X - 600} {Y + 600} 1");
                break;
            case "BR":
                Console.WriteLine($"MOVE {X + 600} {Y + 600} 1");
                break;
        }
    }

    private string GetHighestCountDirection(int tlCount, int trCount, int blCount, int brCount)
    {
        int maxCount = Math.Max(tlCount, Math.Max(trCount, Math.Max(blCount, brCount)));

        // fix random movement

        if (maxCount == tlCount) return "TL";
        if (maxCount == trCount) return "TR";
        if (maxCount == blCount) return "BL";
        if (maxCount == brCount) return "BR";

        // Default to TL if there is a tie or invalid counts
        return "TL";
    }
}