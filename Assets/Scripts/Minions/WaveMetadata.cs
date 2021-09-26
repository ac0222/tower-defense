using System.Collections.Generic;
using System.Linq;

public static class WaveMetadata 
{
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
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 2f},
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
        new SpawnEvent { MinionPrefabName = "MistShinobi", TimeUntilNextSpawn = 2f},
    };

    public static Wave Wave1 = new Wave {
        SpawnEvents = MinionsOnlyGroup
            .Concat(MinionsOnlyGroup)
            .ToList(),
        Timing = 1
    };
    public static Wave Wave2 = new Wave {
        SpawnEvents = MinionsOnlyGroup
            .Concat(MinionsOnlyGroup)
            .Concat(MinionsOnlyGroup)
            .ToList(),
        Timing = 10
    };
    public static Wave Wave3 = new Wave {
        SpawnEvents = MinionsOnlyGroup
            .Concat(SandCell)
            .Concat(MinionsOnlyGroup)
            .Concat(SandCell)
            .ToList(),
        Timing = 20
    };
    public static Wave Wave4 = new Wave {
        SpawnEvents = SandCell
            .Concat(SandCell)
            .Concat(SandCell)
            .Concat(SandCell)
            .Concat(SandCell)
            .ToList(),
        Timing = 40
    };

    public static Wave Wave5 = new Wave {
        SpawnEvents = SandCell
            .Concat(SandCell)
            .Concat(TripleMix)
            .Concat(SandCell)
            .Concat(SandCell)
            .Concat(TripleMix)
            .ToList(),
        Timing = 60
    };

    public static Wave Wave6 = new Wave {
        SpawnEvents = TripleMix
            .Concat(TripleMix)
            .Concat(TripleMix)
            .Concat(TripleMix)
            .Concat(TripleMix)
            .Concat(TripleMix)
            .Concat(TripleMix)
            .ToList(),
        Timing = 90
    };
    public static Wave Wave7 = new Wave {
        SpawnEvents = SandPhalanx
            .Concat(SandPhalanx)
            .Concat(SandPhalanx)
            .Concat(SandPhalanx)
            .Concat(SandPhalanx)
            .Concat(SandPhalanx)
            .Concat(SandPhalanx)
            .ToList(),
        Timing = 120
    };
    public static Wave Wave8 = new Wave {
        SpawnEvents = SandPhalanx
            .Concat(SandPhalanx)
            .Concat(SandPhalanx)
            .Concat(SandPhalanx)
            .Concat(MistShinobiGroup)
            .Concat(MistShinobiGroup)
            .Concat(SandPhalanx)
            .Concat(SandPhalanx)
            .Concat(SandPhalanx)
            .Concat(SandPhalanx)
            .Concat(MistShinobiGroup)
            .Concat(MistShinobiGroup)
            .ToList(),
        Timing = 150
    };
    public static Wave Wave9 = new Wave {
        SpawnEvents = StormTrooperSquad
            .Concat(StormTrooperSquad)
            .Concat(StormTrooperSquad)
            .Concat(StormTrooperSquad)
            .Concat(StormTrooperSquad)
            .Concat(StormTrooperSquad)
            .ToList(),
        Timing = 170
    };
    public static Wave Wave10 = new Wave {
        SpawnEvents = SandPhalanx
            .Concat(StormTrooperSquad)
            .Concat(SandPhalanx)
            .Concat(StormTrooperSquad)
            .Concat(SandPhalanx)
            .Concat(StormTrooperSquad)
            .Concat(StormTrooperSquad)
            .Concat(SandPhalanx)
            .Concat(StormTrooperSquad)
            .Concat(SandPhalanx)
            .Concat(StormTrooperSquad)
            .ToList(),
        Timing = 200
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
        Wave9,
        Wave10
    };

    public static int TotalMinions = Waves.Select(wv => wv.SpawnEvents.Count).Sum();
}