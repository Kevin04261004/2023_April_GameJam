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
    public PathFind pathFind;
    public EffectSoundManager effectSoundManager;
    public BGM_Manager bgmManager;
}
