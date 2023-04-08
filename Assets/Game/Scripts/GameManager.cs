using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public ObjectPool objectpool;
    public SpawnWave spawnWave;
    public Player player;
    public Shoot shoot;
    public UIManager UImanager;
}
