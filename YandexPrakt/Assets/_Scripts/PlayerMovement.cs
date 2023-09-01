using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private float _startLerpSpeed;
    [SerializeField] private float _maxLerpSpeed;

    private float _lerpSpeed;

    [SerializeField] private Rigidbody2D _rigidbody;
    private Vector2 _inputDirection;

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            _inputDirection = Vector2.up;
            _lerpSpeed = Mathf.Lerp(_lerpSpeed, _maxLerpSpeed, Time.deltaTime);
        }
        else
        {
            _inputDirection = Vector2.down;
            _lerpSpeed = _startLerpSpeed;
        }

        Vector2 targetSpeed = Vector2.Lerp(_rigidbody.velocity, _inputDirection * _speed, _lerpSpeed * Time.deltaTime);
        _rigidbody.velocity = targetSpeed;
    }
}