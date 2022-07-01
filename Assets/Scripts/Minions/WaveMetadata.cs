using System.Collections.Generic;
using System.Linq;

public static class WaveMetadata 
{
    public static List<SpawnEvent> GenerateMinionGroup(
        string minionName, int groupSize, float spawnInterval, float endInterval)
    {
        List<SpawnEvent> spawnGroup = new List<SpawnEvent>();
        for (int i = 0; i < groupSize; i++)
        {
            SpawnEvent se = new SpawnEvent {MinionPrefabName = minionName, TimeUntilNextSpawn = spawnInterval};
            if (i == groupSize - 1)
            {   
                se.TimeUntilNextSpawn = endInterval;
            }
            spawnGroup.Add(se);
        }
        return spawnGroup;
    }

    private static List<SpawnEvent> MistShinobiGroup = new List<SpawnEvent> {
        new SpawnEvent { MinionPrefabName = "MistShinobi", TimeUntilNextSpawn = 0.2f},
        new SpawnEvent { MinionPrefabName = "MistShinobi", TimeUntilNextSpawn = 0.2f},
        new SpawnEvent { MinionPrefabName = "MistShinobi", TimeUntilNextSpawn = 0.2f},
        new SpawnEvent { MinionPrefabName = "MistShinobi", TimeUntilNextSpawn = 0.2f},
        new SpawnEvent { MinionPrefabName = "MistShinobi", TimeUntilNextSpawn = 2f},
    };

    private static List<SpawnEvent> MinionsOnlyGroup = new List<SpawnEvent> {
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 0.2f},
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 0.2f},
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 0.2f},
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 0.2f},
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 2f},
    };

    private static List<SpawnEvent> SandCell = new List<SpawnEvent> {
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 0.2f},
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 0.2f},
        new SpawnEvent { MinionPrefabName = "SandShinobi", TimeUntilNextSpawn = 0.2f},
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 0.2f},
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 2f},
    };

    private static List<SpawnEvent> SandCellEarlyBarrier = new List<SpawnEvent> {
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 0.2f},
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 0.2f},
        new SpawnEvent { MinionPrefabName = "SandShinobiEarlyBarrier", TimeUntilNextSpawn = 0.2f},
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 0.2f},
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 2f},
    };

    private static List<SpawnEvent> SandCellLateBarrier = new List<SpawnEvent> {
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 0.2f},
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 0.2f},
        new SpawnEvent { MinionPrefabName = "SandShinobiLateBarrier", TimeUntilNextSpawn = 0.2f},
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 0.2f},
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 2f},
    };

    private static List<SpawnEvent> TripleMix = new List<SpawnEvent> {
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 0.2f},
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 0.2f},
        new SpawnEvent { MinionPrefabName = "SandShinobi", TimeUntilNextSpawn = 0.2f},
        new SpawnEvent { MinionPrefabName = "MistShinobi", TimeUntilNextSpawn = 0.2f},
        new SpawnEvent { MinionPrefabName = "MistShinobi", TimeUntilNextSpawn = 2f},
    };

    private static List<SpawnEvent> SandPhalanx = new List<SpawnEvent> {
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 0.1f},
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 0.1f},
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 0.1f},
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 0.05f},
        new SpawnEvent { MinionPrefabName = "SandShinobi", TimeUntilNextSpawn = 0.05f},
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 0.1f},
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 0.1f},
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 0.1f},
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 1f},
    };
    private static List<SpawnEvent> SandPhalanxEarly = new List<SpawnEvent> {
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 0.1f},
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 0.1f},
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 0.1f},
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 0.05f},
        new SpawnEvent { MinionPrefabName = "SandShinobiEarlyBarrier", TimeUntilNextSpawn = 0.05f},
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 0.1f},
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 0.1f},
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 0.1f},
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 1f},
    };

    private static List<SpawnEvent> SandPhalanxLate = new List<SpawnEvent> {
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 0.1f},
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 0.1f},
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 0.1f},
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 0.05f},
        new SpawnEvent { MinionPrefabName = "SandShinobiLateBarrier", TimeUntilNextSpawn = 0.05f},
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 0.1f},
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 0.1f},
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 0.1f},
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 1f},
    };

    private static List<SpawnEvent> StormTrooperSquad = new List<SpawnEvent> {
        new SpawnEvent { MinionPrefabName = "MistShinobi", TimeUntilNextSpawn = 0.05f},
        new SpawnEvent { MinionPrefabName = "MistShinobi", TimeUntilNextSpawn = 0.05f},
        new SpawnEvent { MinionPrefabName = "MistShinobi", TimeUntilNextSpawn = 0.05f},
        new SpawnEvent { MinionPrefabName = "MistShinobi", TimeUntilNextSpawn = 0.05f},
        new SpawnEvent { MinionPrefabName = "MistShinobi", TimeUntilNextSpawn = 0.05f},
        new SpawnEvent { MinionPrefabName = "MistShinobi", TimeUntilNextSpawn = 0.05f},
        new SpawnEvent { MinionPrefabName = "MistShinobi", TimeUntilNextSpawn = 0.05f},
        new SpawnEvent { MinionPrefabName = "MistShinobi", TimeUntilNextSpawn = 0.05f},
        new SpawnEvent { MinionPrefabName = "MistShinobi", TimeUntilNextSpawn = 0.05f},
        new SpawnEvent { MinionPrefabName = "MistShinobi", TimeUntilNextSpawn = 1f},
    };

    public static Wave Wave1 = new Wave {
        SpawnEvents = GenerateMinionGroup("Minion", 2, 1f, 1)
    };
    public static Wave Wave2 = new Wave {
        SpawnEvents = SandCellLateBarrier
            .Concat(SandCellLateBarrier)
            .Concat(SandCellLateBarrier)
            .ToList()
    };
    public static Wave Wave3 = new Wave {
        SpawnEvents =  SandCellEarlyBarrier
            .Concat(SandCellEarlyBarrier)
            .Concat(SandCellEarlyBarrier)
            .ToList(),
    };
    public static Wave Wave4 = new Wave {
        SpawnEvents = TripleMix
            .Concat(TripleMix)
            .Concat(TripleMix)
            .Concat(TripleMix)
            .ToList(),
    };

    public static Wave Wave5 = new Wave {
        SpawnEvents = SandPhalanx
            .Concat(MistShinobiGroup)
            .Concat(SandPhalanx)
            .Concat(MistShinobiGroup)
            .ToList(),
    };

    public static Wave Wave6 = new Wave {
        SpawnEvents = StormTrooperSquad
            .Concat(StormTrooperSquad)
            .Concat(StormTrooperSquad)
            .Concat(StormTrooperSquad)
            .Concat(StormTrooperSquad)
            .ToList(),
    };
    public static Wave Wave7 = new Wave {
        SpawnEvents = SandPhalanx
            .Concat(SandPhalanx)
            .Concat(GenerateMinionGroup("Minion", 50, 0.1f, 1))
            .Concat(SandPhalanx)
            .Concat(GenerateMinionGroup("Minion", 50, 0.1f, 1))
            .Concat(SandPhalanx)
            .ToList(),
    };
    public static Wave Wave8 = new Wave {
        SpawnEvents = SandPhalanx
            .Concat(SandPhalanx)
            .Concat(GenerateMinionGroup("Minion", 50, 0.1f, 1))
            .Concat(StormTrooperSquad)
            .Concat(SandPhalanx)
            .Concat(GenerateMinionGroup("Minion", 50, 0.1f, 1))
            .Concat(StormTrooperSquad)
            .Concat(SandPhalanx)
            .Concat(GenerateMinionGroup("Minion", 50, 0.1f, 1))
            .Concat(StormTrooperSquad)
            .ToList(),
    };
    public static Wave Wave9 = new Wave {
        SpawnEvents = SandPhalanxEarly
            .Concat(SandPhalanxLate)
            .Concat(StormTrooperSquad)
            .Concat(StormTrooperSquad)
            .Concat(GenerateMinionGroup("Minion", 200, 0.01f, 1))
            .Concat(StormTrooperSquad)
            .Concat(StormTrooperSquad)
            .ToList(),
    };

    public static List<Wave> Waves = new List<Wave> {
        Wave1,
        Wave2,
        Wave3,
        Wave4,
        Wave5,
        Wave6,
        Wave7,
        Wave8,
        Wave9
    };

    public static int TotalMinions = Waves.Select(wv => wv.SpawnEvents.Count).Sum();
}