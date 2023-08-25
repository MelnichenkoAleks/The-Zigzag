using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Controller : MonoBehaviour
{
    [SerializeField] private Ground_Manager _groundManager;
    [SerializeField] private Game_Manager _gameManager;
    private Vector3 _direction = Vector3.left;
    [SerializeField] private float _moveSpeed;

    public bool gameState;
    public static Ball_Controller BallManagerCls;

    private void Start()
    {
        BallManagerCls = this;
    }

    void Update()
    {
        if (gameState)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (_direction.x == -1)
                {
                    _direction = Vector3.forward;
                }
                else
                {
                    _direction = Vector3.left;
                }
            }

            if (transform.position.y <= -1f)
            {
                _gameManager.SetDead(true);
            }
        }
    }

    private void FixedUpdate() 
    {   
        if (gameState)
        {
            Vector3 _move = _direction * _moveSpeed * Time.deltaTime;
            transform.position += _move;
        }
    }

    private void OnCollisionExit(Collision other) 
    {
        if(other.gameObject.CompareTag("Ground")) 
        {
            StartCoroutine(DestroyGround(other.gameObject));
            _groundManager.CreateNewGround();
        }
    }

    IEnumerator DestroyGround(GameObject _gameObject) 
    {
        yield return new WaitForSeconds(0.6f);
        _gameObject.AddComponent<Rigidbody>();
        yield return new WaitForSeconds(3f);
        Destroy(_gameObject);
    }
}
