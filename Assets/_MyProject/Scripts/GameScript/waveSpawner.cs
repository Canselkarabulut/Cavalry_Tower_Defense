using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class waveSpawner : MonoBehaviour
{
    [Header("Hiyerar�ide neyin alt�nda spawnlanacak")]
    [SerializeField] GameObject _enemySpawn;
    [Header("Enemy")]
    [SerializeField] Transform enemyPrefab;
    [Header("D��manlar�n gelece�i aral�k")]
    [SerializeField] public float timeBetweenWaves = 5f;
    [Header("Spawnlama Ba�lang�� Noktas�")]
    [SerializeField] Transform spawnPoint;
    [Header("D��man�n ko�aca�� h�z")]
    [SerializeField]NavMeshAgent _runSpeed;
    float waveIndex;
    float _oldSpeed;
    float countdown = 2f;

    private void Start()
    {
        _runSpeed.speed = 40;
    }
    private void FixedUpdate()
    {
        EnemySpawnerControl();
    }
    //------------------------------------------------------------------------------------------------------
    void EnemySpawnerControl()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
    }
    IEnumerator SpawnWave()
    {
        for (int i = 0; i < waveIndex; i++)
        {
            yield return new WaitForSeconds(0.5f);
            SpawnEnemy();
        }
        if (waveIndex < 8)
        {
            waveIndex++;
          
        }
        else
        {
            waveIndex = 1;
            _oldSpeed = _runSpeed.speed;
            _runSpeed.speed = _oldSpeed + 10;
        }
    }
    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation, _enemySpawn.transform);
    }
}
