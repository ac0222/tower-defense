using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private Dictionary<string, int> AvailableTurrets = new Dictionary<string, int>();
    public void AddTurret(string turretName, int n)
    {
        if (AvailableTurrets.ContainsKey(turretName))
        {
            AvailableTurrets[turretName] += n;
        }
        else
        {
            AvailableTurrets[turretName] = n;
        }
    }

    public int NumberOfTurrets(string turretName)
    {
        if (AvailableTurrets.ContainsKey(turretName))
        {
            return AvailableTurrets[turretName];
        }
        else
        {
            return 0;
        } 
    }
}