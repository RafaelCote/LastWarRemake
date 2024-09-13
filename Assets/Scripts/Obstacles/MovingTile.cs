using System;
using UnityEngine;

public class MovingTile : MonoBehaviour
{
    public event Action<MovingTile> MovementLimitReached;
    
    private Vector3 _startingPosition = Vector3.zero;
    private float _limitDistance = 0.0f;
    private float _speed = 0.0f;
    private short _index = 0;
    private bool _moving = false;

    public short Index => _index;

    private void Start()
    {
        _startingPosition = transform.position;
    }

    private void Update()
    {
        if (_moving)
        {
            transform.position += Vector3.back * (_speed * Time.deltaTime);

            if (Mathf.Abs(transform.position.z) >= _limitDistance) 
                MovementLimitReached?.Invoke(this);
        }
    }

    private void OnDestroy()
    {
        MovementLimitReached = null;
    }

    public void Init(float limitDistance, float speed, short index)
    {
        _limitDistance = limitDistance;
        _speed = speed;
        _index = index;
    }

    public void ResetPosition()
    {
        transform.position = _startingPosition;
    }

    public void BeginMoving()
    {
        _moving = true;
    }

    public void StopMoving()
    {
        _moving = false;
    }
}