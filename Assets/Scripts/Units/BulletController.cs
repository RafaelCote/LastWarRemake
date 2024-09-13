using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletController : MonoBehaviour
{
    private Action<BulletController> _destroyCallback = null;
    private Rigidbody _rigidbody = null;
    private int _damage = 0;

    public int Damage => _damage;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Init(int damage, Action<BulletController> destroyCallback = null)
    {
        _damage = damage;
        _destroyCallback = destroyCallback;
    }

    public void Launch(Vector3 direction, float speed)
    {
        _rigidbody.velocity = direction.normalized * speed;
    }

    public void Reset()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision other)
    {
        _destroyCallback?.Invoke(this);
        Destroy(gameObject);
    }
}
