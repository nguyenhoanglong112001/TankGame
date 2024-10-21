using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateByMouse : MonoBehaviour
{
    [SerializeField] private GameObject _cannon;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private LayerMask _groundMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateCanon();
    }

    private void RotateCanon()
    {
        //var _mousePos = Input.mousePosition;
        //_mousePos.z = Camera.main.transform.position.y - _cannon.transform.position.y;
        //Vector3 _pos = Camera.main.ScreenToWorldPoint(_mousePos);
        //var lookPos = _pos - _cannon.transform.position;
        //lookPos.y = 0;
        //var rotation = Quaternion.LookRotation(lookPos);
        //_cannon.transform.rotation = Quaternion.Slerp(_cannon.transform.rotation, rotation, rotateSpeed*Time.deltaTime);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, Mathf.Infinity,_groundMask))
        {
            Vector3 hitinfo = hit.point;
            Vector3 cannonPos = _cannon.transform.position;
            Vector3 dir = hitinfo - cannonPos;
            dir.y = 0;
            Quaternion targerRoate = Quaternion.LookRotation(dir);
            _cannon.transform.rotation = Quaternion.Slerp(_cannon.transform.rotation, targerRoate, rotateSpeed * Time.deltaTime);
        }    

    }
}
