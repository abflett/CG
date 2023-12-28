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

    public void Update()
    {
        for (int i = 0; i < _droneCount; i++)
        {
            Drones[i].Action(AvailableCreatures);
        }
    }
}
