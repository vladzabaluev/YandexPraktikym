using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : Obstacle
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lerpSpeed;

    [SerializeField] private Rigidbody2D _rigidbody;

    private int _moveDown;
    [SerializeField] private float _moveTime;
    private float _currentTime;

    // Start is called before the first frame update
    private void Start()
    {
        _moveDown = Random.Range(-50, 50) > 0 ? 1 : -1;
    }

    // Update is called once per frame
    private void Update()
    {
        if (_currentTime <= 0)
        {
            _currentTime = _moveTime;
            _moveDown *= (-1);
        }
        else
        {
            _currentTime -= Time.deltaTime;
        }
        Vector2 targetSpeed = Vector2.Lerp(_rigidbody.velocity, new Vector2(0, _moveDown * _speed), _lerpSpeed * Time.deltaTime);
        _rigidbody.velocity = targetSpeed;
    }
}