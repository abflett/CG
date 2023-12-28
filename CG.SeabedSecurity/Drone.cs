using System;
using System.Collections.Generic;

public class Drone
{
    public int Id { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Emergency { get; set; }
    public int Battery { get; set; }
    public Radar Radar { get; set; } = new(); // Todo: fix this
    public List<Creature> ScannedCreatures { get; set; } = new();

    public void Action()
    {
        Console.WriteLine("WAIT 1");  // MOVE <x> <y> <light (1|0)> | WAIT <light (1|0)>
    }
}