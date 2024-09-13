using UnityEngine;
using UnityEngine.Pool;

public class ShootingComponent : MonoBehaviour
{
    [SerializeField] private BulletController _bulletPrefab = null;
    [SerializeField] private Transform _bulletSpawnPoint = null;

    [SerializeField] private float _bulletSpeed = 0.0f;
    [SerializeField] private bool _usePool = true;

    private ObjectPool<BulletController> _pool = null;
    private int _bulletCpt = 0;

    private void Start()
    {
        _pool = new ObjectPool<BulletController>(CreateBullet, GetBullet, ReleaseBullet, DestroyBullet, true, 5, 5);
        _bulletCpt = 0;
    }

    public void Shoot()
    {
        var instance = _usePool ? _pool.Get() : Instantiate(_bulletPrefab);
        instance.transform.SetPositionAndRotation(_bulletSpawnPoint.position, Quaternion.identity);
        //instance.Init(OnBulletDestroyed);
        instance.Launch(transform.forward, _bulletSpeed);
    }

    private void OnBulletDestroyed(BulletController bullet)
    {
        if (_usePool)
        {
            _pool.Release(bullet);
            Debug.Log($"Releasing {bullet.name}");
        }
        else
        {
            Destroy(bullet.gameObject);
            Debug.Log($"Destroying {bullet.name}");
        }
    }
    
    private BulletController CreateBullet()
    {
        _bulletCpt++;
        var instance = Instantiate(_bulletPrefab);
        instance.name = $"Bullet {_bulletCpt}";
        return instance;
    }

    private void GetBullet(BulletController bullet) => bullet.gameObject.SetActive(true);

    private void ReleaseBullet(BulletController bullet)
    {
        bullet.Reset();
        bullet.gameObject.SetActive(false);
    }

    private void DestroyBullet(BulletController bullet) => Destroy(bullet.gameObject);
}
