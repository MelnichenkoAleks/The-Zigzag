using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    [SerializeField] private Game_Manager _gameManager;
    [SerializeField] private Transform _ball;
    private Vector3 _offset;
    [SerializeField] private float _lerpTime;

    void Start()
    {
        _offset = transform.position - _ball.transform.position;
    }

    void LateUpdate()
    {
        if(_gameManager.GetDead() == false) 
        {
            Vector3 _newPos = Vector3.Lerp(transform.position, _offset + _ball.position, _lerpTime * Time.deltaTime);
            transform.position = _newPos;    
        }
    }
}
