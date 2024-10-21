using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    private int _damage;
    // Start is called before the first frame update
    void Start()
    {
        _damage = Random.Range(1, 6);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!collision.gameObject.CompareTag("Player") || !collision.gameObject.CompareTag("Bullet"))
        {
            if(collision.gameObject.CompareTag("Enemy"))
            {
                DeliverDame(collision.gameObject);
            }
            Destroy(gameObject);
        }
    }

    private void DeliverDame(GameObject hitTarget)
    {
        TankHealth targetHealth = hitTarget.GetComponent<TankHealth>();
        if (targetHealth != null )
        {
            targetHealth.TakeDame(_damage);
        }
    }
}
