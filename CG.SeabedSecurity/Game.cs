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

            _player.UpsertScannedCreatures(_gameCreatures); // Only on surface
            _enemy.UpsertScannedCreatures(_gameCreatures);

            _player.UpsertDrones(); // drone information
            _enemy.UpsertDrones();

            _player.UpsertDroneScannedCreatures(_gameCreatures); // drone scanned but not scanned data
            _gameCreatures.UpdateVisibleCreatures(); // Only in light range, powered vs not
            _player.UpdateRadarInfo();
            _player.Update();
        }
    }
}