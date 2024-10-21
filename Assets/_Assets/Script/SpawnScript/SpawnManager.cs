using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<BoxCollider> _areaSpawn;
    [SerializeField] private float _timeDelay;
    [SerializeField] private GameObject _tankEnemy;
    private Vector3 spawnPos;
    private GameObject _enemy;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
       StartCoroutine(SpawnEnemyDelay());
    }

    private void SpawnEnemy()
    {
        int araeIndex = Random.Range(0,_areaSpawn.Count);
        float spawnPosX = Random.Range(_areaSpawn[araeIndex].bounds.center.x - _areaSpawn[araeIndex].bounds.size.x / 2, _areaSpawn[araeIndex].bounds.center.x + _areaSpawn[araeIndex].bounds.size.x / 2);
        float spawnPosZ = Random.Range(_areaSpawn[araeIndex].bounds.center.z - _areaSpawn[araeIndex].bounds.size.z / 2, _areaSpawn[araeIndex].bounds.center.z + _areaSpawn[araeIndex].bounds.size.z / 2);
        Vector3 spawnPos = new Vector3(spawnPosX, -5.0f, spawnPosZ);
        _enemy = Instantiate(_tankEnemy, spawnPos, Quaternion.identity);
        if (_timeDelay > 1.0f)
        {
            _timeDelay -= 0.1f;
            StopAllCoroutines();  
        }
    }

    IEnumerator SpawnEnemyDelay()
    {
        yield return new WaitForSeconds(_timeDelay);
        SpawnEnemy();
    }
}
