
using System;
using System.Collections.Generic;

public class Game
{
    private int[] _inputs;
    private List<Creature> _creatures = new();
    private List<Drone> _playerDrones = new();
    private List<Drone> _enemyDrones = new();

    public void Run()
    {
        int creatureCount = Util.GetNumericValue();
        Console.Error.WriteLine($"CreatureCount: {creatureCount}");
        for (int i = 0; i < creatureCount; i++)
        {
            _inputs = Util.GetNumericValues();
            _creatures.Add(new Creature
            {
                Id = _inputs[0],
                Color = _inputs[1],
                CreatureType = _inputs[2]
            });
        }

        // game loop
        while (true)
        {
            int myScore = Util.GetNumericValue();
            int foeScore = Util.GetNumericValue();
            int myScanCount = Util.GetNumericValue();
            for (int i = 0; i < myScanCount; i++)
            {
                int creatureId = Util.GetNumericValue();
            }
            int foeScanCount = Util.GetNumericValue();
            for (int i = 0; i < foeScanCount; i++)
            {
                int creatureId = Util.GetNumericValue();
            }
            int myDroneCount = Util.GetNumericValue();
            for (int i = 0; i < myDroneCount; i++)
            {
                _inputs = Util.GetNumericValues();
                int droneId = _inputs[0];
                int droneX = _inputs[1];
                int droneY = _inputs[2];
                int emergency = _inputs[3];
                int battery = _inputs[4];
            }
            int foeDroneCount = Util.GetNumericValue();
            for (int i = 0; i < foeDroneCount; i++)
            {
                _inputs = Util.GetNumericValues();
                int droneId = _inputs[0];
                int droneX = _inputs[1];
                int droneY = _inputs[2];
                int emergency = _inputs[3];
                int battery = _inputs[4];
            }
            int droneScanCount = Util.GetNumericValue();
            for (int i = 0; i < droneScanCount; i++)
            {
                _inputs = Util.GetNumericValues();
                int droneId = _inputs[0];
                int creatureId = _inputs[1];
            }
            int visibleCreatureCount = Util.GetNumericValue();
            for (int i = 0; i < visibleCreatureCount; i++)
            {
                _inputs = Util.GetNumericValues();
                int creatureId = _inputs[0];
                int creatureX = _inputs[1];
                int creatureY = _inputs[2];
                int creatureVx = _inputs[3];
                int creatureVy = _inputs[4];
            }
            int radarBlipCount = Util.GetNumericValue();
            for (int i = 0; i < radarBlipCount; i++)
            {
                var inputs = Console.ReadLine().Split(' ');
                int droneId = int.Parse(inputs[0]);
                int creatureId = int.Parse(inputs[1]);
                string radar = inputs[2];

                Console.Error.WriteLine($"Radar: {radar}");
            }
            for (int i = 0; i < myDroneCount; i++)
            {

                // Write an action using Console.WriteLine()
                // To debug: Console.Error.WriteLine("Debug messages...");

                Console.WriteLine("WAIT 1"); // MOVE <x> <y> <light (1|0)> | WAIT <light (1|0)>

            }
        }
    }
}

