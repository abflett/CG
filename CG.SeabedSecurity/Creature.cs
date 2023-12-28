using System;

public class Creature
{
    public int Id { get; set; }
    public int Color { get; set; }
    public int CreatureType { get; set; }
    public string Radar { get; set; }
    public int X { get; set; } // Current
    public int Y { get; set; }
    public int Vx { get; set; } // Velocity
    public int Vy { get; set; }
    public bool PlayerScanned { get; set; } = false;
    public int Px { get; set; } = 0; // Previous
    public int Py { get; set; } = 0;
    public int Nx { get; set; } = 0; // Next
    public int Ny { get; set; } = 0;

    public void UpdateRadar(string radar)
    {
        Radar = radar;
    }

    public void UpdateLocVel(int x, int y, int vx, int vy)
    {
        Px = X;
        Py = Y;
        X = x;
        Y = y;
        Vx = vx;
        Vy = vy;
        CalculateEndValues();
    }

    private void CalculateEndValues()
    {
        Nx = X + Vx;
        Ny = Y + Vy;

        if (Nx < (int)CreatureBounds.StartX)
        {
            var x = ((int)CreatureBounds.StartX - Nx);
            Console.Error.WriteLine($"Minus Bounced X: {-x}");
        }
        if (Ny < (int)CreatureBounds.StartY)
        {
            var y = ((int)CreatureBounds.StartY - Ny);
            Console.Error.WriteLine($"Minus Bounced Y: {-y}");
        }

        if (Nx > (int)CreatureBounds.EndX)
        {
            var x = ((int)CreatureBounds.EndX - Nx);
            Console.Error.WriteLine($"Positive Bounced X: {-x}");
        }
        if (Ny > (int)CreatureBounds.EndX)
        {
            var y = ((int)CreatureBounds.EndY - Ny);
            Console.Error.WriteLine($"Positive Bounced Y: {-y}");
        }

        Console.Error.WriteLine($"EndX: {Nx}, EndY: {Ny}, PreviousX: {Px}, PreviousY: {Py}, X: {X}, Y: {Y}");
    }
}