using System;
public class Game
{
    private int[] _inputs;
    public GameCreatures GameCreatures;
    public Player Player { get; set; } = new();
    public Player Enemy { get; set; } = new();

    public Game()
    {
        GameCreatures = new GameCreatures(Util.GetNumericValue());
        for (int i = 0; i < GameCreatures.CreatureCount; i++)
        {
            _inputs = Util.GetNumericValues();
            GameCreatures.Add(_inputs[0], _inputs[1], _inputs[2]);
        }
    }

    public void Run()
    {
        while (true)
        {
            Player.Score = Util.GetNumericValue();
            Enemy.Score = Util.GetNumericValue();

            Player.ScanCount = Util.GetNumericValue();
            for (int i = 0; i < Player.ScanCount; i++)
            {
                Player.UpdateScannedCreature(GameCreatures.CreatureById(Util.GetNumericValue()));
            }

            Enemy.ScanCount = Util.GetNumericValue();
            for (int i = 0; i < Enemy.ScanCount; i++)
            {
                Enemy.UpdateScannedCreature(GameCreatures.CreatureById(Util.GetNumericValue()));
            }

            Player.DroneCount = Util.GetNumericValue();
            for (int i = 0; i < Player.DroneCount; i++)
            {
                _inputs = Util.GetNumericValues();
                Player.UpdateDrones(_inputs[0], _inputs[1], _inputs[2], _inputs[3], _inputs[4]);
            }

            Enemy.DroneCount = Util.GetNumericValue();
            for (int i = 0; i < Enemy.DroneCount; i++)
            {
                _inputs = Util.GetNumericValues();
                Enemy.UpdateDrones(_inputs[0], _inputs[1], _inputs[2], _inputs[3], _inputs[4]);
            }

            int droneScanCount = Util.GetNumericValue();
            for (int i = 0; i < droneScanCount; i++)
            {
                _inputs = Util.GetNumericValues();
                int droneId = _inputs[0];
                int creatureId = _inputs[1];
            }

            GameCreatures.VisibleCreatureCount = Util.GetNumericValue();
            for (int i = 0; i < GameCreatures.VisibleCreatureCount; i++)
            {
                _inputs = Util.GetNumericValues();
                GameCreatures.UpdateLocVel(_inputs[0], _inputs[1], _inputs[2], _inputs[3], _inputs[4]);
            }

            Player.RadarBlipCount = Util.GetNumericValue();
            for (int i = 0; i < Player.RadarBlipCount; i++)
            {
                Player.UpdateDroneRadar(Console.ReadLine().Split(' '));
            }

            Player.Update(GameCreatures);
        }
    }
}