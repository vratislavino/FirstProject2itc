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
     Dod�lat!
        1) po smrti zobrazit nejvy��� dosa�en� sk�re (zobrazit na deathscreen)
        2) po smrti zobrazit death screen s mo�nost� restartovat (button)
        3) padaj�c� objekty budou rotovat kolem osy Y
        4) pokud hr�� dos�hne 1000, zrychl� se pad�n� (za ka�dou 1000)
     */

}
