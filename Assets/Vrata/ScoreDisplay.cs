using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class ScoreDisplay : MonoBehaviour
{
    TMP_Text text;
    [SerializeField]
    GameObject deathScreen;
    [SerializeField]
    TMP_Text deathScreenText;


    void Start()
    {
        text = GetComponent<TMP_Text>();
        Score.Instance.ScoreChanged += OnScoreChanged;
        Score.Instance.Died += OnDied;
    }

    private void OnDied(int bestScore) {

        Score.Instance.ScoreChanged -= OnScoreChanged;
        Score.Instance.Died -= OnDied;
        deathScreen.SetActive(true);
        deathScreenText.text = "Best score: " + bestScore;

    }

    private void OnScoreChanged(int score) {
        text.text = score.ToString();
    }

    public void Restart() {
        Score.Instance.Restart();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
