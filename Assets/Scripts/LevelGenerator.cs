using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> wallModules;
    [SerializeField]
    private List<GameObject> modules;
    [SerializeField]
    public float fillPercentage = 0.5f;
    [SerializeField]
    private int smoothingIterations = 2;
    [SerializeField]
    private int moduleSize = 10;
    [SerializeField]
    private int mapSize = 10;

    public List<GameObject> WallModules => wallModules;
    public List<GameObject> Modules => modules;
    public float FillPercentage => fillPercentage;
    public int SmoothingIterations => smoothingIterations;
    public int ModuleSize => moduleSize;
    public int MapSize => mapSize;
}
