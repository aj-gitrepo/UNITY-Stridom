using UnityEngine;
using TMPro; //TextMeashPro

public class ScoreBoard : MonoBehaviour
{
    int score;
    TMP_Text scoreText;

    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "Start";
    }

    public void IncreaseScore(int amountToIncrease)
    {
        score += amountToIncrease;
        Debug.Log($"Your Score now is {score}");
        scoreText.text = score.ToString();
    }
}

// create an empty gameobj "Score Board" and this script to it, position to 0,0,0
// after creating TextMeshPro Text delete the above game obj and add this script to TextMeashPro Text, that is renamed as ScoreBoard
