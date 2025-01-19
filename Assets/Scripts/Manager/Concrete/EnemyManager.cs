using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Manager<EnemyManager>
{
    [Header("Enemy Settings")]
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private GameObject[] spawnPoints;

    public void SpawnGfishAt(int _spawnPtIdx)
    {
        GameObject _newEnemy = Instantiate(enemyPrefabs[MapEnemyTypeToIdx(EnemyType.GFish)]);
        _newEnemy.transform.position = spawnPoints[_spawnPtIdx].transform.position;

        AudioManager.instance.PlaySFX(0, _newEnemy.transform);
    }

    public void SpawnTunaAtTo(int _spawnPtIdx, int _dstPtIdx)
    {
        GameObject _newEnemy = Instantiate(enemyPrefabs[MapEnemyTypeToIdx(EnemyType.Tuna)]);
        _newEnemy.transform.position = spawnPoints[_spawnPtIdx].transform.position;
        _newEnemy.GetComponent<Tuna>().SetDestination(spawnPoints[_dstPtIdx].transform.position);

        AudioManager.instance.PlaySFX(8, _newEnemy.transform);
    }

    public void SpawnAnchorAt(int _spawnPtIdx)
    {
        GameObject _newEnemy = Instantiate(enemyPrefabs[MapEnemyTypeToIdx(EnemyType.Anchor)]);
        _newEnemy.transform.position = spawnPoints[_spawnPtIdx].transform.position + new Vector3(0, 4.3f, 0);

        AudioManager.instance.PlaySFX(3, _newEnemy.transform);
    }

    private int MapEnemyTypeToIdx(EnemyType _type)
    {
        if (_type == EnemyType.GFish) return 0;
        else if (_type == EnemyType.Tuna) return 1;
        else if (_type == EnemyType.Anchor) return 2;
        else return -1;
    }
}

public enum EnemyType
{
    GFish,
    Tuna,
    Anchor
}