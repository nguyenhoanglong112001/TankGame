using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayButton : MonoBehaviour
{
    [SerializeField] private AudioSource _replaySound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReplayGame()
    {
        _replaySound.Play();
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }
}
