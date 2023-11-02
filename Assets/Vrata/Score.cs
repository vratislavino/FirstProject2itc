using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score
{
    public event Action<int> ScoreChanged;
    public event Action<int> Died;

    private int score = 0;
    private bool dead = false;

    private int bestScore = 0;

    public int CurrentScore {
        get { return score; }
        private set {
            if (dead) return;
            score = value;

            if(score > bestScore)
                bestScore = score;

            ScoreChanged?.Invoke(score);
        }
    }

    #region Singleton stuff

    private static Score instance = new Score();

    public static Score Instance => instance;

    private Score() { }

    #endregion

    public void AddScore(int amount) {
        CurrentScore += amount;
    }

    public void RemoveScore(int amount) { 
        CurrentScore -= amount;
        if(score < 0) {
            dead = true;
            Died?.Invoke(bestScore);
        }
    }

    public void Restart() {
        dead = false;
        score = 0;
        bestScore = 0;
    }

    /*
     Dodìlat!
        1) po smrti zobrazit nejvyšší dosažené skóre (zobrazit na deathscreen)
        2) po smrti zobrazit death screen s možností restartovat (button)
        3) padající objekty budou rotovat kolem osy Y
        4) pokud hráè dosáhne 1000, zrychlí se padání (za každou 1000)
     */

}
