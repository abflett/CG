public class Game
{
    private int[] _inputs;
    private readonly GameCreatures _gameCreatures;
    private readonly Player _player = new();
    private readonly Player _enemy = new();

    public Game()
    {
        _gameCreatures = new GameCreatures(); // add creatures: id, color, and type
    }

    public void Run()
    {
        while (true)
        {
            _player.UpdateScore();
            _enemy.UpdateScore();
            _player.UpsertScannedCreatures(_gameCreatures); // add scanned creatures
            _enemy.UpsertScannedCreatures(_gameCreatures);
            _player.UpsertDrones(); // add or update drones: id, x, y, emergency, and battery
            _enemy.UpsertDrones();

            int droneScanCount = Util.GetNumericValue(); // Todo: find out what this does.
            for (int i = 0; i < droneScanCount; i++)
            {
                _inputs = Util.GetNumericValues();
                int droneId = _inputs[0];
                int creatureId = _inputs[1];
            }

            _gameCreatures.UpdateVisibleCreatures(); // update creatures x, y, vx, and vy
            _player.UpdateDroneRadar();
            _player.Update(_gameCreatures);
        }
    }
}