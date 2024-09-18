using System;
using System.Collections;
using MrHatProduction.Tools.Components;
using MrHatProduction.Tools.Math;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletController : MonoBehaviour
{
    private Action<BulletController> _destroyCallback = null;
    private Rigidbody _rigidbody = null;
    private int _damage = 0;
    
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

    public void Launch(AnimationCurve animationCurve, QuadraticCurve quadraticCurve)
    {
        StartCoroutine(TranslateWithCurves(animationCurve, quadraticCurve));
    }

    public void Reset()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<HealthComponent>(out var healthComponent))
        {
            healthComponent.TakeDamage(_damage);
        }
        
        _destroyCallback?.Invoke(this);
        Destroy(gameObject);
    }

    private IEnumerator TranslateWithCurves(AnimationCurve animationCurve, QuadraticCurve quadraticCurve)
    {
        float time = 0.0f;
        while (time < 1.0f)
        {
            transform.position = quadraticCurve.Evaluate(animationCurve.Evaluate(time));
            time += Time.deltaTime;
            yield return null;
        }
    }
}
