using System.Collections.Generic;
using System.Linq;

class Player
{
    public int InitX { get; set; }
    public int InitY { get; set; }
    public int Gold { get; set; }
    public int TouchedSiteId { get; set; } // -1 if none
    public int Turn { get; set; } = 0;
    public Site TargetSite { get; set; }
    public string QueenAction { get; set; } = "WAIT";
    public string TrainAction { get; set; } = "TRAIN";
    public int ArcherBarracks { get; set; } = 0;
    public int KnightBarracks { get; set; } = 0;
    public int ArcherCount { get; set; } = 0;
    public int KnightCount { get; set; } = 0;

    public void UpdateInfo(int gold, int touchedSiteId)
    {
        Gold = gold;
        TouchedSiteId = touchedSiteId;
    }

    public void Update(GameSites gameSites, GameUnits gameUnits)
    {
        var queen = gameUnits.Units.Find(x => x.Owner == 0 && x.UnitType == -1);
        if (InitX == 0)
        {
            InitX = queen.X;
            InitY = queen.Y;
        }

        var enemyQueen = gameUnits.Units.Find(x => x.Owner == 1 && x.UnitType == -1);
        ArcherBarracks = gameSites.Sites.Where(x => x.Owner == 0 && x.StructureType == 2 && x.Param2 == 1).Count();
        KnightBarracks = gameSites.Sites.Where(x => x.Owner == 0 && x.StructureType == 2 && x.Param2 == 0).Count();
        ArcherCount = gameUnits.Units.Where(x => x.Owner == 0 && x.UnitType == 1).Count();
        KnightCount = gameUnits.Units.Where(x => x.Owner == 0 && x.UnitType == 0).Count();


        SetQueenAction(gameSites, queen);
        SetTrainAction(gameSites, enemyQueen);
    }

    private void SetQueenAction(GameSites gameSites, Unit queen)
    {
        Site closestSite = FindClosestViableSiteToQueen(queen, gameSites.Sites);

        // need to add gold mines for Wood1

        if (closestSite == null)
        {
            QueenAction = "WAIT"; // todo: move to start location
        }
        else if (TouchedSiteId == closestSite.Id && ArcherBarracks < 1)
        {
            QueenAction = $"BUILD {TouchedSiteId} BARRACKS-ARCHER";
        }
        else if (TouchedSiteId == closestSite.Id && KnightBarracks < 3)
        {
            QueenAction = $"BUILD {TouchedSiteId} BARRACKS-KNIGHT";
        }
        else if (ArcherBarracks >= 1 && KnightBarracks >= 3)
        {
            QueenAction = $"MOVE {InitX} {InitY}";
        }
        else
        {
            QueenAction = $"MOVE {closestSite.X} {closestSite.Y}";
        }
    }

    private void SetTrainAction(GameSites gameSites, Unit enemyQueen)
    {
        Site closestKnightsBarracks = FindClosestKnightsBarracksToEnemyQueen(enemyQueen, gameSites.Sites);
        Site clostestArcherBarracks = FindClosestArcherBarracksToEnemyQueen(enemyQueen, gameSites.Sites);

        if (ArcherCount < 6)
        {
            if (clostestArcherBarracks == null)
            {
                TrainAction = $"TRAIN";
            }
            else if (Gold >= 100)
            {
                TrainAction = $"TRAIN {clostestArcherBarracks.Id}";
            }
            else
            {
                TrainAction = $"TRAIN";
            }
        }
        else if (Gold >= 80)
        {
            if (closestKnightsBarracks == null)
            {
                TrainAction = $"TRAIN";
            }
            else
            {
                TrainAction = $"TRAIN {closestKnightsBarracks.Id}";
            }

        }
        else
        {
            TrainAction = $"TRAIN";
        }
    }

    private static Site FindClosestViableSiteToQueen(Unit queen, List<Site> gameSites)
    {
        var sites = gameSites.Where(x => x.StructureType == -1);
        return sites.MinBy(site => Util.CalculateDistance(queen.X, queen.Y, site.X, site.Y));
    }

    private static Site FindClosestKnightsBarracksToEnemyQueen(Unit queen, List<Site> gameSites)
    {
        var sites = gameSites.Where(x => x.StructureType == 2 && x.Owner == 0 && x.Param1 == 0 && x.Param2 == 0);
        return sites.MinBy(site => Util.CalculateDistance(queen.X, queen.Y, site.X, site.Y));
    }

    private static Site FindClosestArcherBarracksToEnemyQueen(Unit queen, List<Site> gameSites)
    {
        var sites = gameSites.Where(x => x.StructureType == 2 && x.Owner == 0 && x.Param1 == 0 && x.Param2 == 1);
        return sites.MinBy(site => Util.CalculateDistance(queen.X, queen.Y, site.X, site.Y));
    }
}