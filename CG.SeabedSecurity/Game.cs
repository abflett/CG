public class Game
{
    private readonly GameCreatures _gameCreatures;
    private readonly Player _player = new();
    private readonly Enemy _enemy = new();

    public Game()
    {
        _gameCreatures = new GameCreatures(_player);
    }

    public void Run()
    {
        while (true)
        {
            _player.UpdateScore();
            _enemy.UpdateScore();

            _player.UpsertScannedCreatures(_gameCreatures);
            _enemy.UpsertScannedCreatures(_gameCreatures);

            _player.UpsertDrones();
            _enemy.UpsertDrones();

            // Todo: find out what this does.
            int droneScanCount = Util.GetNumericValue();
            for (int i = 0; i < droneScanCount; i++)
            {
                var data = Util.GetNumericValues();
                int droneId = data[0];
                int creatureId = data[1];
            }

            _gameCreatures.UpdateVisibleCreatures();
            _gameCreatures.UpdateRadarInfo();
            _player.Update();
        }
    }
}