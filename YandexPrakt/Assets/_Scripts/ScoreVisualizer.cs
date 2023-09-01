using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreVisualizer : MonoBehaviour
{
    [SerializeField] private TMP_Text m_TextMeshPro;

    // Start is called before the first frame update
    private void Start()
    {
        ScoreManager.Instance.OnScoreChanged += UpdateScoreUI;
    }

    private void UpdateScoreUI(int score)
    {
        m_TextMeshPro.text = score + "";
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnDisable()
    {
        ScoreManager.Instance.OnScoreChanged -= UpdateScoreUI;
    }
}