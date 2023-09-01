using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private int _score;

    public Action<int> OnScoreChanged;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        _score = 0;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void CoinCollected()
    {
        _score++;
        OnScoreChanged?.Invoke(_score);
    }
}