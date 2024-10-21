using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class EnemyMoving : MonoBehaviour
{
    [SerializeField] private Transform _playerPos;
    [SerializeField] private GameObject _tower;
    [SerializeField] private NavMeshAgent nav;
    [SerializeField] private EnemyAttack _shoot;

    [SerializeField]
    Transform _identifyRotation;
    [SerializeField] private float _speedRotate;
    [SerializeField] private float _reachDistance;
    [SerializeField] private float minX;
    [SerializeField] private float minZ;

    [SerializeField] private float maxX;
    [SerializeField] private float maxZ;

    private bool _isShoot;
    private bool _isMoving;
    private Vector3 _reachPos;
    private Quaternion _orginPos;

    // Start is called before the first frame update
    void Start()
    {
        _playerPos = GameObject.FindWithTag("Player").GetComponent<Transform>();
        _reachPos = new Vector3(Random.Range(minX, maxX), transform.position.y, Random.Range(minZ, maxZ));
        _orginPos = _tower.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        TankMove();
    }

    private void TankMove()
    {
        Vector3 _playerPosCheck = new Vector3(transform.position.x, _reachPos.y, transform.position.z);
        float distance = Vector3.Distance(_playerPosCheck, _reachPos);
        _isMoving = distance >= _reachDistance;
        if (_isMoving)
        {
            nav.isStopped = false;
            if (!_isrotate)
            {
                _isrotate = true;
            }
            nav.SetDestination(_reachPos);
        }
        else
        {
            Debug.Log("Stop");
            nav.isStopped = true;
            StartCoroutine(RotateToPlayer());
        }
    }

    bool _isrotate;

    bool _isRotateToPlayer;

    IEnumerator RotateToPlayer()
    {
        Debug.Log("Rotate");
        if (_isrotate)
        {
            var rotation = Quaternion.LookRotation(_playerPos.position - _tower.transform.position);

            if (Quaternion.Angle(_tower.transform.rotation, rotation) >= 0.1f)
            {
                _tower.transform.rotation = Quaternion.RotateTowards(_tower.transform.rotation, rotation, _speedRotate * Time.deltaTime);
                //  Quaternion.Slerp(_tower.transform.rotation, rotation, _speedRotate * Time.deltaTime);
            }
            else
            {
                _isrotate = false;
                _shoot.Shoot();
            }
        }
        yield return null;
        if (!_isrotate)
        {
            var rotation = Quaternion.LookRotation(_identifyRotation.position - _tower.transform.position);
            var angle = Quaternion.Angle(_tower.transform.rotation, rotation);


            if (angle >= 0.1f)
            {
                _tower.transform.rotation = Quaternion.RotateTowards(_tower.transform.rotation, rotation, _speedRotate * Time.deltaTime);

                //  _tower.transform.rotation = Quaternion.Slerp(_tower.transform.rotation, _orginPos, _speedRotate * Time.deltaTime);
            }
            else
            {
                _reachPos = new Vector3(Random.Range(minX, maxX), transform.position.y, Random.Range(minZ, maxZ));
            }
        }
    }
}
