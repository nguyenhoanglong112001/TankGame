using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverUI;
    [SerializeField] private TankHealth _onDie;
    [SerializeField] private AudioSource _gameoverSound;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowUI()
    {
        _gameOverUI.SetActive(true);
        Time.timeScale = 0;
    }

    private void OnEnable()
    {
        _gameoverSound.Play();
    }
}
