using System.Collections.Generic;

public class Character
{
    protected int _droneCount = 0;
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
            var foundCreature = gameCreatures.CreatureById(Util.GetNumericValue());
            var foundScannedCreature = ScannedCreatures.Find(x => x.Id == foundCreature.Id);
            if (foundScannedCreature == null)
            {
                ScannedCreatures.Add(foundCreature);
            }
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
}