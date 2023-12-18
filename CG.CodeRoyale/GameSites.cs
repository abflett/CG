using System.Collections.Generic;
class GameSites
{
    public int NumberOfSites { get; set; }
    public List<Site> Sites { get; set; } = new List<Site>();

    public GameSites(int numberOfSites)
    {
        NumberOfSites = numberOfSites;
    }

    public void AddSite(int siteId, int x, int y, int radius)
    {
        Sites.Add(new Site
        {
            Id = siteId,
            X = x,
            Y = y,
            Radius = radius
        });
    }

    public void UpdateSiteInfo(int siteId, int ignore1, int ignore2, int structureType, int owner, int param1, int param2)
    {
        Site site = Sites.Find(x => x.Id == siteId);
        site.UpdateSiteInfo(ignore1, ignore2, structureType, owner, param1, param2);
    }
}