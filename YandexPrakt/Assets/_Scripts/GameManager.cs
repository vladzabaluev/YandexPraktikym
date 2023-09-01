using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private bool isGameStarted;

    [SerializeField] private GameObject _StartText;

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
        Time.timeScale = 0;
        isGameStarted = false;
        _StartText.SetActive(true);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (!isGameStarted)
            {
                isGameStarted = true;
                Time.timeScale = 1;
                _StartText.SetActive(false);
            }
        }
    }
}