using System;
using System.Collections.Generic;
public class Player
{
    public int Score { get; set; } = 0;
    public int DroneCount { get; set; } = 0;
    public int ScanCount { get; set; } = 0;
    public int RadarBlipCount { get; set; } = 0;
    public List<Drone> Drones { get; set; } = new List<Drone>();
    public List<Creature> ScannedCreatures { get; set; } = new List<Creature>();

    public void UpdateScannedCreature(Creature creature)
    {
        var foundCreature = ScannedCreatures.Find(x => x.Id == creature.Id);
        if (foundCreature == null)
        {
            ScannedCreatures.Add(creature);
        }
    }

    public void UpdateDrones(int id, int x, int y, int emergency, int battery)
    {
        var drone = Drones.Find(x => x.Id == id);
        if (drone == null)
        {
            Drones.Add(new Drone
            {
                Id = id,
                X = x,
                Y = y,
                Emergency = emergency,
                Battery = battery
            });
        }
        else
        {
            drone.X = x;
            drone.Y = y;
            drone.Emergency = emergency;
            drone.Battery = battery;
        }
    }

    public void UpdateDroneRadar(string[] data)
    {
        var foundDrone = Drones.Find(x => x.Id == int.Parse(data[0]));
        if (foundDrone != null)
        {
            foundDrone.Radar.CreatureId = int.Parse(data[1]);
            foundDrone.Radar.RelativePosition = data[2];
        }
    }

    public void Update(GameCreatures gameCreatures)
    {
        for (int i = 0; i < DroneCount; i++)
        {
            Console.Error.WriteLine($"Drone{i}/{DroneCount} Action.");
            Drones[i].Action();
        }
    }
}