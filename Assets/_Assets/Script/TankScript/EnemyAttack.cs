using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _shootPos;
    [SerializeField] private float _speed;
    [SerializeField] private LineRenderer _laser;
    [SerializeField] private int _damage;
    [SerializeField] private LayerMask _layerHit;
    private GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator ShootLaser()
    {
        _damage = Random.Range(1, 6);
        _laser.enabled = true;
        _laser.SetPosition(0, _shootPos.position);

        RaycastHit hitinfo;
        if (Physics.Raycast(_shootPos.position, _shootPos.forward, out hitinfo, _layerHit))
        {
            _laser.SetPosition(1, hitinfo.point);
            DeliverDame(hitinfo);
        }
        yield return new WaitForSeconds(0.1f);
        _laser.enabled = false;
    }

    private void DeliverDame(RaycastHit hitTarget)
    {
        TankHealth targetHealth = hitTarget.collider.GetComponent<TankHealth>();
        if (targetHealth != null)
        {
            targetHealth.TakeDame(_damage);
        }
    }

    public void Shoot()
    {
        StartCoroutine(ShootLaser());   
    }
}
