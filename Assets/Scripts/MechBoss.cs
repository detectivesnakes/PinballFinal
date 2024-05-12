using System.Collections;
using UnityEngine;

public class MechBoss : MonoBehaviour
{
    public Transform target;
    public int maxHealth = 3;
    private int currentHealth;
    private Animator animator;
    private MoveComponent moveComponent;
    public static MechBoss bossPrefab;
    public static MechBoss instance;
    public float impactForce = 10f;

    public static bool isDead { get; private set; } = false;

    void Awake()
    {
        instance = this;
        gameObject.SetActive(false);
    }

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        moveComponent = GetComponent<MoveComponent>();
        isDead = false;
    }

    void Update()
    {
        if (target != null)
        {
            float distance = Vector3.Distance(transform.position, target.position);
            if (distance < 2f)
            {
                if (moveComponent != null) moveComponent.SetMoving(false);
                animator.SetBool("isAttacking", true);
            }
            else
            {
                animator.SetBool("isAttacking", false);
                if (moveComponent != null) moveComponent.SetMoving(true);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (animator.GetBool("isAttacking"))
            {
                Rigidbody ballRigidbody = collision.gameObject.GetComponent<Rigidbody>();
                if (ballRigidbody != null)
                {
                    Vector3 forceDirection = (collision.transform.position - transform.position).normalized;
                    ballRigidbody.AddForce(forceDirection * impactForce, ForceMode.Impulse);
                }
            }

            animator.SetBool("isDamaged", true);
            currentHealth--;

            if (currentHealth <= 0)
            {
                StartCoroutine(Die());
            }
            else
            {
                StartCoroutine(takeDamage());
            }
        }
    }

    public static void spawnBoss()
    {
        if (instance != null)
        {
            instance.gameObject.SetActive(true);
            instance.currentHealth = instance.maxHealth;
            isDead = false;
        }
    }

    private IEnumerator takeDamage()
    {
        if (moveComponent != null) moveComponent.SetMoving(false);
        yield return new WaitForSeconds(1f);

        animator.SetBool("isDamaged", false);
        if (moveComponent != null) moveComponent.SetMoving(true);
    }

    private IEnumerator Die()
    {
        animator.SetBool("isDying", true);

        if (moveComponent != null) moveComponent.SetMoving(false);
        yield return new WaitForSeconds(3f);

        gameObject.SetActive(false);
        isDead = true;
        FollowEntity.respawnLine(1f);
    }
}
