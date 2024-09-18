using System;
using System.Collections;
using MrHatProduction.Tools.Components;
using Units.Data;
using UnityEngine;

[RequireComponent(typeof(MovementComponent))]
[RequireComponent(typeof(CollisionComponent))]
[RequireComponent(typeof(HealthComponent))]
[RequireComponent(typeof(HitBoxComponent))]
public class UnitController : MonoBehaviour
{
    public event Action<UnitController> Died;
    
    public static Transform PlayerTransform { get; set; } //TODO: Check if there's a better way to cache player's position.
    
    [Header("Visual")]
    [SerializeField] private MeshRenderer _meshRenderer = null;
    [SerializeField] private MeshFilter _meshFilter = null;
    [SerializeField] private Transform _abilitySpawnPoint = null;
    [SerializeField] private Animator _animator = null;
    
    [Header("Debug")]
    [SerializeField] private Unit _unit = null;
    
    private MovementComponent _movementComponent = null;
    private CollisionComponent _collisionComponent = null;
    private HitBoxComponent _hitBoxComponent = null;
    private HealthComponent _healthComponent = null;

    private void Awake()
    {
        _movementComponent = GetComponent<MovementComponent>();
        _collisionComponent = GetComponent<CollisionComponent>();
        _healthComponent = GetComponent<HealthComponent>();
        _hitBoxComponent = GetComponent<HitBoxComponent>();
    }

    private void Start()
    {
        _healthComponent.Died += HealthComponent_Died;
    }

    private void Update()
    {
        if (_unit is UnitWithBehaviour behaviouralUnit) //TODO: Refactor en créant des classes gérant les différents comportement
            behaviouralUnit.Behaviour.Act();
    }

    private void OnDestroy()
    {
        _healthComponent.Died -= HealthComponent_Died;
    }

    public void Init(Unit unit)
    {
        //TODO: Maybe initialize components with data instead of caching it completely
        _unit = unit;

        if (_unit is UnitWithBehaviour behaviouralUnit) //TODO: Refactor en creant des classes gérant les différents comportement
            behaviouralUnit.Behaviour.Init(this);
        
        _healthComponent.Init(_unit.MaxHealth);
        _meshFilter.mesh = _unit.Mesh;
        _meshRenderer.material = _unit.Material;
    }

    public void UseAbility()
    {
        _unit.AttackAbility.Use(this);
    }

    public void Move(Vector3 velocity)
    {
        _movementComponent.Move(velocity, _unit.MovementSpeed);
        transform.forward = velocity.normalized;
    }

    public IEnumerator ActivateHitBoxForSeconds(float seconds)
    {
        _hitBoxComponent.gameObject.SetActive(true);
        yield return new WaitForSeconds(seconds);
        _hitBoxComponent.gameObject.SetActive(false);
    }

    public void Animate(string paramName)
    {
        _animator.SetTrigger(paramName);
    }

    public bool TryGetQuadraticCurveComponent(out QuadraticCurveComponent curveComponent)
    {
        return TryGetComponent(out curveComponent);
    }

    public float GetAbilityCooldown() => _unit.AttackAbility.Cooldown;

    public Transform GetAbilitySpawnPoint() => _abilitySpawnPoint;

    private void HealthComponent_Died()
    {
        Died?.Invoke(this);
        Destroy(gameObject);
    }
}