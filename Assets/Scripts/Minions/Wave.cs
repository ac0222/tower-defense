using System.Collections.Generic;

public class Wave {
    public float Timing {get; set;}
    public List<SpawnEvent> SpawnEvents {get; set;}
    public bool YieldsReward {get; set;} = false;
}