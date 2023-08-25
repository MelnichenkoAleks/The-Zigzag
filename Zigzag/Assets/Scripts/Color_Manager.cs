using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Color_Manager : MonoBehaviour
{
    [SerializeField] private Material _groundMaterial;
    [SerializeField] private Color[] _colors;
    private int _colorIndex = 0;
    [SerializeField] private float _lerpTime;
    [SerializeField] private float _time;
    private float _currentTime;

    private void Start() 
    {
        _groundMaterial.color = Color.white;
    }

    void Update()
    {
        _groundMaterial.color = Color.Lerp(_groundMaterial.color, _colors[_colorIndex], _lerpTime * Time.deltaTime);

        if(_currentTime <= 0) 
        {
            _colorIndex++;
            _currentTime = _time;
        }
        else 
        {
            _currentTime -= Time.deltaTime;
        }

        if(_colorIndex >= _colors.Length) 
        {
            _colorIndex = 0;
        }
    }
}
