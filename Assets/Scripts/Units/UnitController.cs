using System;
using MrHatProduction.Tools.Components;
using Units.Data;
using UnityEngine;

[RequireComponent(typeof(MovementComponent))]
[RequireComponent(typeof(HealthComponent))]
[RequireComponent(typeof(DamageableComponent))]
public class UnitController : MonoBehaviour
{
    public event Action<UnitController> Died;
    
    public static Transform PlayerTransform { get; set; } //TODO: Check if there's a better way to cache player's position.
    
    [Header("Visual")]
    [SerializeField] private MeshRenderer _meshRenderer = null;
    [SerializeField] private MeshFilter _meshFilter = null;
    [SerializeField] private Transform _projectileSpawnPoint = null;
    [SerializeField] private Transform _meleeColliderSpawnPoint = null;
    [SerializeField] private Animator _animator = null;
    
    [Header("Debug")]
    [SerializeField] private Unit _unit = null;
    
    private MovementComponent _movementComponent = null;
    private DamageableComponent _damageableComponent = null;
    private HealthComponent _healthComponent = null;

    private void Awake()
    {
        _movementComponent = GetComponent<MovementComponent>();
        _healthComponent = GetComponent<HealthComponent>();
        _damageableComponent = GetComponent<DamageableComponent>();
    }

    private void Start()
    {
        _damageableComponent.DamageReceived += DamageableComponent_DamageReceived;
        _healthComponent.Died += HealthComponent_Died;
    }

    private void Update()
    {
        if (_unit is UnitWithBehaviour behaviouralUnit) //TODO: Refactor en créant des classes gérant les différents comportement
            behaviouralUnit.Behaviour.Act();
    }

    private void OnDestroy()
    {
        _damageableComponent.DamageReceived += DamageableComponent_DamageReceived;
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

    public void Animate(string paramName)
    {
        _animator.SetTrigger(paramName);
    }

    public bool TryGetQuadraticCurveComponent(out QuadraticCurveComponent curveComponent) => TryGetComponent(out curveComponent);
    public float GetAbilityCooldown() => _unit.AttackAbility.Cooldown;
    public Transform GetProjectileSpawnPoint() => _projectileSpawnPoint;
    public Transform GetMeleeColliderSpawnPoint() => _meleeColliderSpawnPoint;

    private void DamageableComponent_DamageReceived(int damage)
    {
        _healthComponent.TakeDamage(damage);
    }

    private void HealthComponent_Died()
    {
        Died?.Invoke(this);
        Destroy(gameObject);
    }
}