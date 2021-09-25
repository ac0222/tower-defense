using System.Collections.Generic;
using System.Linq;

public static class WaveMetadata 
{
     public static List<SpawnEvent> Wave1 = new List<SpawnEvent> {
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 0.2f},
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 0.2f},
        new SpawnEvent { MinionPrefabName = "SandShinobi", TimeUntilNextSpawn = 0.2f},
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 0.2f},
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 2f},
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 0.2f},
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 0.2f},
        new SpawnEvent { MinionPrefabName = "SandShinobi", TimeUntilNextSpawn = 0.2f},
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 0.2f},
        new SpawnEvent { MinionPrefabName = "Minion", TimeUntilNextSpawn = 2f},
    };
    public static List<SpawnEvent> Wave2 = Wave1.Concat(Wave1).ToList();
    public static List<SpawnEvent> Wave3 = Wave2.Concat(Wave1).ToList();
    public static List<SpawnEvent> Wave4 = Wave3.Concat(Wave1).ToList();
    public static List<SpawnEvent> Wave5 = Wave4.Concat(Wave1).ToList();
    public static List<SpawnEvent> Wave6 = Wave5.Concat(Wave1).ToList();
    public static List<SpawnEvent> Wave7 = Wave6.Concat(Wave1).ToList();
    public static List<SpawnEvent> Wave8 = Wave7.Concat(Wave1).ToList();
    public static List<SpawnEvent> Wave9 = Wave8.Concat(Wave1).ToList();
    public static List<SpawnEvent> Wave10 = Wave9.Concat(Wave1).ToList();
    public static List<List<SpawnEvent>> Waves = new List<List<SpawnEvent>> {
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

    public static int TotalMinions = Waves.Select(wv => wv.Count).Sum();
}