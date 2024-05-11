using System.Collections;
using UnityEngine;

public class EntityBehaviour : MonoBehaviour
{
    public enum ProjectileType
    {
        Fireball,
        Stun,
        Bullet
    }

    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private ProjectileType projectileType;
    [SerializeField] private Transform pinballTransform;
    [SerializeField] private float shootingInterval = 5f;
    [SerializeField] private float triggerDistance = 10f;
    [SerializeField] private MoveComponent moveComponent;


    private Coroutine shootingRoutine;
    private Animator animator;

    private void Update()
    {
        animator = GetComponent<Animator>();
        if (Vector3.Distance(transform.position, pinballTransform.position) <= triggerDistance)
        {
            if (shootingRoutine == null)
            {
                shootingRoutine = StartCoroutine(ShootingRoutine());
            }
        }
        else
        {
            if (shootingRoutine != null)
            {
                StopCoroutine(shootingRoutine);
                shootingRoutine = null;
                moveComponent.SetMoving(true);
            }
        }
    }

    private IEnumerator ShootingRoutine()
    {
        moveComponent.SetMoving(false);
        while (true)
        {
            ShootProjectile();
            yield return new WaitForSeconds(shootingInterval);
        }
    }


    private void ShootProjectile()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isShooting", true);
        Quaternion originalRotation = transform.rotation;
        Vector3 directionToTarget = (pinballTransform.position - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
        transform.rotation = targetRotation;

        Vector3 y = transform.position + Vector3.up * 0.3f;
        GameObject projectileInstance = Instantiate(projectilePrefab, y  , targetRotation);


        StartCoroutine(Reset(originalRotation));

       
        if (projectileType == ProjectileType.Fireball)
        {
            
            FireballBehaviour fireballScript = projectileInstance.GetComponent<FireballBehaviour>();
            if (fireballScript != null)
            {
                fireballScript.setTarget(pinballTransform);
            }
        }
        else if (projectileType == ProjectileType.Stun)
        {
            StunBehaviour stunScript = projectileInstance.GetComponent<StunBehaviour>();
            if (stunScript != null)
            {
                stunScript.setTarget(pinballTransform);
            }
        }
        else if (projectileType == ProjectileType.Bullet)
        {
            BulletBehaviour bulletScript = projectileInstance.GetComponent<BulletBehaviour>();
            if (bulletScript != null)
            {
                bulletScript.initialize(pinballTransform.position);
            }
        }
    }

    private IEnumerator Reset(Quaternion originalRotation)
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("isShooting", false);
        transform.rotation = originalRotation;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Debug.Log("Hit");
            gameObject.SetActive(false);
            Invoke("RespawnEntity", 3f);
        }
    }

    private void RespawnEntity()
    {
        gameObject.SetActive(true);
        if (Vector3.Distance(transform.position, pinballTransform.position) <= triggerDistance)
        {
            shootingRoutine = StartCoroutine(ShootingRoutine());
        }
    }
}