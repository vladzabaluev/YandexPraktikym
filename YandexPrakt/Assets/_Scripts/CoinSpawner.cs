using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;

    [SerializeField] private Transform _spawnZone;

    [SerializeField] private float _spawnCooldown;
    private float _currentTimer;

    // Start is called before the first frame update
    private void Start()
    {
        _currentTimer = _spawnCooldown;
    }

    // Update is called once per frame
    private void Update()
    {
        if (_currentTimer <= 0)
        {
            _currentTimer = _spawnCooldown;
            CreateCoin();
        }
        else
        {
            _currentTimer -= Time.deltaTime;
        }
    }

    private void CreateCoin()
    {
        Coin coin = Instantiate(_coin, new Vector3(_spawnZone.position.x, Random.Range(_spawnZone.position.y - _spawnZone.localScale.y / 2, _spawnZone.position.y +
            _spawnZone.localScale.y / 2), _spawnZone.position.z), Quaternion.identity);
    }
}