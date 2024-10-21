using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Image _healthbar;
    [SerializeField] private TankHealth _onHealthChange;
    private GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        _onHealthChange.OnHealthChange.AddListener(ShowHealthBar);
        _player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        LookForwardToPlayer();
    }

    private void ShowHealthBar(int healthRemain,int maxhealth)
    {
        _healthbar.fillAmount = (float)healthRemain/maxhealth;
    }

    private void LookForwardToPlayer()
    {
        transform.forward = -_player.transform.forward;
    }
}
