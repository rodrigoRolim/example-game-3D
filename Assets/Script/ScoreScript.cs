using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public int score;
    public void setScore(int score) {
        this.score = score;
        GameObject.Find("Scores").GetComponent<Text>().text = score.ToString();
    }
    public void increasingScorePill(int score) {
        score++;
        setScore(score);
    }
    public int getScore() {
        return score;
    }
    public void increasingScoreGhost(int score) {
        score += 10;
        setScore(score);
    }
    
}
