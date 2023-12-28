using System;
using System.Collections.Generic;
using System.Linq;
public class Player : Character
{
    public List<Creature> AvailableCreatures { get; set; } = new List<Creature>();
    public List<Creature> DroneScannedCreatures { get; set; } = new List<Creature>();

    public void UpsertDroneScannedCreatures(GameCreatures gameCreatures)
    {
        int droneScanCount = Util.GetNumericValue();
        for (int i = 0; i < droneScanCount; i++)
        {
            var data = Util.GetNumericValues();
            var playerDrone = Drones.FirstOrDefault(x => x.Id == data[0]);
            if (playerDrone != null)
            {
                var foundCreature = gameCreatures.CreatureById(data[1]);
                var foundDroneScannedCreature = DroneScannedCreatures.Find(x => x.Id == foundCreature.Id);

                if (foundDroneScannedCreature == null)
                {
                    DroneScannedCreatures.Add(foundCreature);
                    AvailableCreatures.Remove(foundCreature);
                }
            }
        }
    }

    public void UpdateRadarInfo()
    {
        var radarBlipCount = Util.GetNumericValue();
        for (int i = 0; i < radarBlipCount; i++)
        {
            var data = (Console.ReadLine().Split(' '));
            var playerDrone = Drones.FirstOrDefault(x => x.Id == int.Parse(data[0]));
            if (playerDrone != null)
            {
                playerDrone.UpsertRadar(int.Parse(data[0]), int.Parse(data[1]), data[2]);
            }
        }
    }

    public void Update()
    {
        for (int i = 0; i < _droneCount; i++)
        {
            Drones[i].Action(AvailableCreatures);
        }
    }
}
