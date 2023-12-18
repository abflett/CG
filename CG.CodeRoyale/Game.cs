using System;
class Game
{
    private int[] _inputs = null;

    public void Run()
    {
        Player player = new();

        GameSites gameSites = new(Util.GetNumericValue());
        for (int i = 0; i < gameSites.NumberOfSites; i++)
        {
            _inputs = Util.GetNumericValues();
            gameSites.AddSite(_inputs[0], _inputs[1], _inputs[2], _inputs[3]);
        }

        while (true)
        {
            _inputs = Util.GetNumericValues();

            player.UpdateInfo(_inputs[0], _inputs[1]);
            for (int i = 0; i < gameSites.NumberOfSites; i++)
            {
                _inputs = Util.GetNumericValues();
                gameSites.UpdateSiteInfo(_inputs[0], _inputs[1], _inputs[2], _inputs[3], _inputs[4], _inputs[5], _inputs[6]);
            }

            GameUnits gameUnits = new(Util.GetNumericValue());
            for (int i = 0; i < gameUnits.NumberOfUnits; i++)
            {
                _inputs = Util.GetNumericValues();
                gameUnits.AddUnit(_inputs[0], _inputs[1], _inputs[2], _inputs[3], _inputs[4]);
            }

            player.Update(gameSites, gameUnits);

            Console.WriteLine(player.QueenAction);
            Console.WriteLine(player.TrainAction);
        }
    }
}