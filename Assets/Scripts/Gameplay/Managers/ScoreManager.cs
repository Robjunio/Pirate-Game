using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    public static ScoreManager instance;
    private int score;

    private void Start()
    {
        instance = this;
    }

    public void ScorePoint()
    {
        score++;
        scoreText.text = score.ToString() + " pts"; 
    }

    public float GetCurrentScore()
    {
        return score;
    }
}
