using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    private int _totalKill;
    [SerializeField] private UnityEvent<int> OnScoreChange;

    public int TotalKill 
    { 
        get => _totalKill; 
        set
        {
            _totalKill = value;
            OnScoreChange?.Invoke(value);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        OnScoreChange.AddListener(ShowScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateKill(int kill)
    {
        _totalKill+=kill;
        OnScoreChange.Invoke(_totalKill);
    }

    public void ShowScore(int score)
    {
        _scoreText.text = "Score: " +score.ToString();
    }
}
