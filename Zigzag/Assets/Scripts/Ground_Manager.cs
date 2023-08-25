using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_Manager : MonoBehaviour
{
    [SerializeField] private GameObject _lastGround;
    [SerializeField] private Vector3[] _directions;

    void Start()
    {
        for(int i = 0; i < 30; i++) 
        {
            CreateNewGround();
        }
    }

    public void CreateNewGround() 
    {
        int _index = Random.Range(0, 2);
        Vector3 _direction = _directions[_index];
        _lastGround = Instantiate(_lastGround, _lastGround.transform.position + _direction, _lastGround.transform.rotation);
        _lastGround.transform.SetParent(GameObject.Find("Grounds").transform);
    }
}
