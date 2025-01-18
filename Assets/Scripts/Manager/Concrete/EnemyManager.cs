using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Manager<EnemyManager>
{
    [Header("Enemy Settings")]
    [SerializeField] private GameObject[] enemyPrefabs;
}

public enum EnemyType
{
    GFish,
    Tuna
}