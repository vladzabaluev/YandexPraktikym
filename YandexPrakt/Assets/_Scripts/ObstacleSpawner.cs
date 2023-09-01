using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private Obstacle _obstacle;

    [SerializeField] private Transform _spawnZone;

    [SerializeField] private float _spawnCooldown;
    private float _currentTimer;

    private int _spawnCount;

    [SerializeField] private float _minSpawnOffsetX;
    [SerializeField] private float _maxSpawnOffsetX;

    // Start is called before the first frame update
    private void Start()
    {
        ScoreManager.Instance.OnScoreChanged += ChangeSpawnCount;

        _currentTimer = _spawnCooldown;
        _spawnCount = 1;
    }

    // Update is called once per frame
    private void Update()
    {
        if (_currentTimer <= 0)
        {
            _currentTimer = _spawnCooldown;
            SpawnObstacles();
        }
        else
        {
            _currentTimer -= Time.deltaTime;
        }
    }

    private void ChangeSpawnCount(int score)
    {
        if (score % 2 == 1)
        {
            _spawnCount++;
        }
    }

    private void SpawnObstacles()
    {
        for (int i = 0; i < _spawnCount; i++)
        {
            float x = _spawnZone.position.x + Random.Range(_minSpawnOffsetX, _maxSpawnOffsetX) * i;
            float y = _spawnZone.position.y + Random.Range(-_spawnZone.localScale.y / 2, _spawnZone.localScale.y / 2);
            Vector3 spawnPosition = new Vector3(x, y, _spawnZone.position.z);
            Instantiate(_obstacle, spawnPosition, Quaternion.identity);
        }
    }

    private void OnDisable()
    {
        ScoreManager.Instance.OnScoreChanged -= ChangeSpawnCount;
    }
}