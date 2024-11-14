using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Transform _shootPos;
    [SerializeField] private LineRenderer _laser;
    [SerializeField] private int _damage;
    [SerializeField] private LayerMask _layerHit;
    [SerializeField] private float _fireRate;
    [SerializeField] private float _laserDuration;
    [SerializeField] private GameObject _effect;
    [SerializeField] private AudioSource _fireSound;
    private float _nextFire;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            AutoShoot();
        }
    }

    private void AutoShoot()
    {
        if(Time.time > _nextFire)
        {
            _nextFire = Time.time + _fireRate;
            StartCoroutine(ShootLaser());
            _fireSound.Play();
        }
    }
    
    IEnumerator ShootLaser()
    {
        _damage = Random.Range(1, 6);
        _laser.enabled = true;
        _laser.SetPosition(0,_shootPos.position);

        RaycastHit hitinfo;
        if (Physics.Raycast(_shootPos.position,_shootPos.forward, out hitinfo, _layerHit))
        {
            _laser.SetPosition(1, hitinfo.point);
            //ShowHitEffect(hitinfo);
            DeliverDame(hitinfo);
        }
        yield return new WaitForSeconds(_laserDuration);
        _laser.enabled =false;
    }

    private void DeliverDame(RaycastHit hitTarget)
    {
        TankHealth targetHealth = hitTarget.collider.GetComponent<TankHealth>();
        if (targetHealth != null)
        {
            targetHealth.TakeDame(_damage);
        }
    }

    private void ShowHitEffect(RaycastHit hitinfo)
    {
        Quaternion effectrotae = Quaternion.LookRotation(hitinfo.normal);
        Instantiate(_effect, hitinfo.point, effectrotae);
    }
}
