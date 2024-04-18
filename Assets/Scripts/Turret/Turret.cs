using Core;
using Extensions;
using UnityEngine;
using Zenject;

namespace Turret
{
    public class Turret : MonoBehaviour
    {
        [SerializeField]
        private float rotationSpeed = 1.0f;
        [SerializeField]
        private float maxRotation = 30f;
        [SerializeField]
        private float fireRate = 0.5f;
        [SerializeField]
        private int _firePower = 40;
        [SerializeField]
        private Projectile _projectile;
        [SerializeField]
        private Transform _firePoint;

        private Vector2 centerScreenPosition;
        private float nextFireTime;
        private GameManager _gameManager;

        [Inject]
        private void Construct (GameManager gameManager)
        {
            _gameManager = gameManager;
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
                        nextFireTime = Time.time + 1f / fireRate;
                    }
                }
            }
        }

        private void RotateTurret (Vector3 currentTouchPosition)
        {
            float targetRotationY = Mathf.Lerp(-maxRotation, maxRotation, (currentTouchPosition.x + 1) / 2);
            float currentRotationY = Mathf.LerpAngle(transform.localRotation.eulerAngles.y, targetRotationY, rotationSpeed * Time.deltaTime);

            transform.localRotation = Quaternion.Euler(-85f, currentRotationY, 0f);
        }

        private void Shoot()
        {
            var projectile = Instantiate(_projectile, _firePoint.position, _firePoint.rotation);
            projectile.Rigidbody.AddForce(_firePoint.forward * _firePower, ForceMode.Impulse);
            Destroy(projectile.gameObject, 1f);
        }
    }
}