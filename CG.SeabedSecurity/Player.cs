using System;
using System.Collections.Generic;
public class Player
{
    private int _droneCount = 0;
    public int Score { get; set; } = 0;
    public List<Drone> Drones { get; set; } = new List<Drone>();
    public List<Creature> ScannedCreatures { get; set; } = new List<Creature>();

    public void UpdateScore()
    {
        Score = Util.GetNumericValue();
    }

    public void UpsertScannedCreatures(GameCreatures gameCreatures)
    {
        var scanCount = Util.GetNumericValue();
        for (int i = 0; i < scanCount; i++)
        {
            UpdateScannedCreature(gameCreatures.CreatureById(Util.GetNumericValue()));
        }
    }

    private void UpdateScannedCreature(Creature creature)
    {
        var foundCreature = ScannedCreatures.Find(x => x.Id == creature.Id);
        if (foundCreature == null)
        {
            ScannedCreatures.Add(creature);
        }
    }

    public void UpsertDrones()
    {
        _droneCount = Util.GetNumericValue();
        for (int i = 0; i < _droneCount; i++)
        {
            var data = Util.GetNumericValues();
            var drone = Drones.Find(x => x.Id == data[0]);
            if (drone == null)
            {
                Drones.Add(new Drone
                {
                    Id = data[0],
                    X = data[1],
                    Y = data[2],
                    Emergency = data[3],
                    Battery = data[4]
                });
            }
            else
            {
                drone.X = data[1];
                drone.Y = data[2];
                drone.Emergency = data[3];
                drone.Battery = data[4];
            }
        }
    }

    public void UpdateDroneRadar()
    {
        var radarBlipCount = Util.GetNumericValue();
        for (int i = 0; i < radarBlipCount; i++)
        {
            var data = (Console.ReadLine().Split(' '));

            // Todo: Many radar blips for each creature, probably used in higher tiers.
            var foundDrone = Drones.Find(x => x.Id == int.Parse(data[0]));
            if (foundDrone != null)
            {
                foundDrone.Radar.CreatureId = int.Parse(data[1]);
                foundDrone.Radar.RelativePosition = data[2];
            }
        }
    }

    public void Update(GameCreatures gameCreatures)
    {
        for (int i = 0; i < _droneCount; i++)
        {
            Drones[i].Action();
        }
    }
}