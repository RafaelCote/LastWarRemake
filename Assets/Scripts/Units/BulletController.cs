using System;
using System.Collections;
using MrHatProduction.Tools.Components;
using MrHatProduction.Tools.Math;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(DamageComponent))]
public class BulletController : MonoBehaviour
{
    [SerializeField] private ParticleSystem _contactPrefab = null;
    
    private Action<BulletController> _destroyCallback = null;
    private DamageComponent _damageComponent = null;
    private Rigidbody _rigidbody = null;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _damageComponent = GetComponent<DamageComponent>();
    }

    public void Init(int damage, Action<BulletController> destroyCallback = null)
    {
        _damageComponent.Init(damage);
        _damageComponent.HitSomething += DamageComponent_HitSomething;
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

    private void DamageComponent_HitSomething(Collision other)
    {
        if (_contactPrefab != null)
            Instantiate(_contactPrefab, other.contacts[0].point, Random.rotation);
        
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
