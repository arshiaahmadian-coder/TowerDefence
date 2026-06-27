using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    public static WaypointManager instance;

    private void Awake()
    {
        instance = this;
    }
}
