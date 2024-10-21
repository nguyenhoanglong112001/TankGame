using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.Events;

public class TankHealth : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private ScoreManager score;
    [SerializeField] public UnityEvent OnDie;
    [SerializeField] public UnityEvent<int,int> OnHealthChange;
    private int _healthremain;
    private bool _idDead => _healthremain <= 0;

    public int Healthremain 
    { 
        get => _healthremain; 
        set
        {
            _healthremain = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.FindWithTag("Score").GetComponent<ScoreManager>();
        Healthremain = _health;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TakeDame(int damage)
    {
        if(Healthremain > 0)
        {
            Healthremain -= damage;
            OnHealthChange.Invoke(_healthremain, _health);
        }
        if(_idDead)
        {
            OnDie.Invoke();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void UpdateKillWhenDie()
    {
        score.UpdateKill(1);
    }
}
