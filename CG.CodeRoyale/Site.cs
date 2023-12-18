public class Site
{
    public int Id { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Radius { get; set; }
    public int Ignore1 { get; set; } // used in future leagues
    public int Ignore2 { get; set; } // used in future leagues
    public int StructureType { get; set; } // -1 = No structure, 2 = Barracks
    public int Owner { get; set; } // -1 = No structure, 0 = Friendly, 1 = Enemy
    public int Param1 { get; set; } // -1 = No structure, When barracks, the number of turns before a new set of creeps can be trained (if 0, then training may be started this turn)
    public int Param2 { get; set; } // -1 = No structure, When barracks: the creep type: 0 for KNIGHT, 1 for ARCHER

    public void UpdateSiteInfo(int ignore1, int ignore2, int structureType, int owner, int param1, int param2)
    {
        Ignore1 = ignore1;
        Ignore2 = ignore2;
        StructureType = structureType;
        Owner = owner;
        Param1 = param1;
        Param2 = param2;
    }

    public bool HasStucture()
    {
        return StructureType != -1;
    }
}