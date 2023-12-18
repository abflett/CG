using System.Collections.Generic;
class GameUnits
{
    public int NumberOfUnits { get; set; }
    public List<Unit> Units = new();

    public GameUnits(int numberOfUnits)
    {
        NumberOfUnits = numberOfUnits;
    }

    public void AddUnit(int x, int y, int owner, int unitType, int health)
    {
        Units.Add(new Unit
        {
            X = x,
            Y = y,
            Owner = owner,
            UnitType = unitType,
            Health = health
        });
    }
}