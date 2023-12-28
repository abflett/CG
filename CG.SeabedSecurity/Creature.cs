public class Creature
{
    public int Id { get; set; } = 0;
    public int Color { get; set; } = 0;
    public int CreatureType { get; set; } = 0;
    public int X { get; set; } = 0; // Actual
    public int Y { get; set; } = 0;
    public int Vx { get; set; } = 0; // Velocity
    public int Vy { get; set; } = 0;

    public int Nx { get; set; } = 0; // Next
    public int Ny { get; set; } = 0;

    public void UpdateCreature(int x, int y, int vx, int vy)
    {
        X = x;
        Y = y;
        Vx = vx;
        Vy = vy;

        Nx = X + Vx;
        Ny = Y + Vy;
    }
}