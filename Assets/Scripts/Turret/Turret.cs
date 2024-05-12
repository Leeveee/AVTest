using Core;
using Extensions;
using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Turret
{
    public class Turret : MonoBehaviour
    {
      
        [SerializeField]
        private Transform _firePoint;

        private Vector2 centerScreenPosition;
        private float nextFireTime;
        private GameManager _gameManager;
        private TurretConfig _turretConfig;
        private DiContainer _diContainer;

        [Inject]
        private void Construct (GameManager gameManager, GameConfig gameConfig, DiContainer diContainer)
        {
            _gameManager = gameManager;
            _turretConfig =  gameConfig.TurretConfig;
            _diContainer = diContainer;
        }
        private void Update()
        {
            if (Input.touchCount > 0 && _gameManager.IsStartGame)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    Vector3 currentLocalCamPos = Camera.main.ScreenToLocalCamPos(Input.mousePosition, -5);
                    RotateTurret(currentLocalCamPos);

                    if (Time.time >= nextFireTime)
                    {
                        Shoot();
                        nextFireTime = Time.time + 1f / _turretConfig.FireRate;
                    }
                }
            }
        }

        private void RotateTurret (Vector3 currentTouchPosition)
        {
            float targetRotationY = Mathf.Lerp(-_turretConfig.MaxRotation, _turretConfig.MaxRotation, (currentTouchPosition.x + 1) / 2);
            float currentRotationY = Mathf.LerpAngle(transform.localRotation.eulerAngles.y, targetRotationY, _turretConfig.RotationSpeed * Time.deltaTime);

            transform.localRotation = Quaternion.Euler(-85f, currentRotationY, 0f);
        }

        private void Shoot()
        {
            var projectile = _diContainer.InstantiatePrefab(_turretConfig.Projectile).GetComponent<Projectile>();
            projectile.transform.position = _firePoint.position;
            projectile.transform.rotation = _firePoint.rotation;
            projectile.Rigidbody.AddForce(_firePoint.forward * _turretConfig.FirePower, ForceMode.Impulse);
            Destroy(projectile.gameObject, 1f);
        }
    }
}