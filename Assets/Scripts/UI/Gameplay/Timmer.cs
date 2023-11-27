using Gameplay.Managers;
using TMPro;
using UnityEngine;

public class Timmer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timmerText;
    private float _timeLeft;
    private bool _timmerRunning = true;

    private void Start()
    {
        _timeLeft = GameController.instance.GetGameTime();
    }

    void Update()
    {
        if (!_timmerRunning) return;
        
        _timeLeft -= Time.deltaTime;
        
        if (_timeLeft > 0)
        {
            UpdateTimmer();
        }
        else
        {
            GameController.instance.OnEndGame();
            _timmerRunning = false;
        }
        
    }

    void UpdateTimmer()
    {
        float minutes = Mathf.FloorToInt(_timeLeft / 60);
        float seconds = Mathf.FloorToInt(_timeLeft % 60);

        _timmerText.text = $"{minutes:00} : {seconds:00}";
    }
}
