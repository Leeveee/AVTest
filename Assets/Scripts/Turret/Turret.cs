using UnityEngine;

namespace Turret
{
    public class Turret : MonoBehaviour
    {
        [SerializeField]
        private float rotationSpeed = 1.0f;
        [SerializeField]
        private float maxRotation = 30f;
        [SerializeField]
        private Projectile _projectile;
        [SerializeField]
        private Transform _firePoint;
        [SerializeField] 
        private float fireRate = 0.5f;
        [SerializeField]
        private int _firePower = 40;

        private Vector2 centerScreenPosition;
        private float nextFireTime;

        private void Update()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    Vector3 currentLocalCamPos = ScreenToLocalCamPos( Camera.main,Input.mousePosition, -5);
                    RotateTurret(currentLocalCamPos);
                    
                    if (Time.time >= nextFireTime)
                    {
                        Shoot();
                        nextFireTime = Time.time + 1f / fireRate;
                    }
                }
            }
        }

        private Vector3 ScreenToLocalCamPos( Camera cam, Vector3 screenPos, float camZ)
        {
            Vector3 pos = cam.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, camZ));
            return cam.transform.InverseTransformPoint(pos);
        }
        
        private void RotateTurret(Vector3 currentTouchPosition)
        {
            float targetRotationY = Mathf.Lerp(-maxRotation, maxRotation, (currentTouchPosition.x + 1) / 2);
            float currentRotationY = Mathf.LerpAngle(transform.rotation.eulerAngles.y, targetRotationY, rotationSpeed * Time.deltaTime);

            transform.rotation = Quaternion.Euler(-90f, currentRotationY, 0f);
        }
        
      private  void Shoot()
        {
          var projectile = Instantiate(_projectile, _firePoint.position, _firePoint.rotation);
          projectile.Rigidbody.AddForce(_firePoint.forward * _firePower, ForceMode.Impulse);
          Destroy(projectile.gameObject,1f);
        }
    }
}