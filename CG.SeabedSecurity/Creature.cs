public class Creature
{
    public int Id { get; set; }
    public int Color { get; set; }
    public int CreatureType { get; set; }
    public string Radar { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Vx { get; set; }
    public int Vy { get; set; }

    public void UpdateRadar(string radar)
    {
        Radar = radar;
    }

    public void UpdateLocVel(int x, int y, int vx, int vy)
    {
        X = x;
        Y = y;
        Vx = vx;
        Vy = vy;
    }
}