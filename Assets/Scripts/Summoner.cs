using System.Collections;
using UnityEngine;

public class Summoner : MonoBehaviour
{
    public GameObject minionPrefab;
    public Transform target;
    public float summonRate = 2.0f;
    private float nextSummonTime = 0.0f;
    private bool isSummoning = false;
    private Animator animator;
    private MoveComponent moveComponent;

    private void Start()
    {
        animator = GetComponent<Animator>();
        moveComponent = GetComponent<MoveComponent>();
    }

    private void Update()
    {
        if (Time.time >= nextSummonTime && !isSummoning)
        {
            StartCoroutine(SummonMinions());
            nextSummonTime = Time.time + summonRate;
        }
    }

    private IEnumerator SummonMinions()
    {
        isSummoning = true;
        moveComponent.SetMoving(false);
        animator.SetBool("isSummoning", true);

        InstantiateMinion(Vector3.left * 0.5f);
        yield return new WaitForSeconds(0.1f);
        InstantiateMinion(Vector3.right * 0.5f);

        yield return new WaitForSeconds(0.5f);

        animator.SetBool("isSummoning", false);
        isSummoning = false;
        moveComponent.SetMoving(true);
    }

    private void InstantiateMinion(Vector3 positionOffset)
    {
        Vector3 spawnPosition = transform.position + Vector3.up * 0.11f + positionOffset;
        var minion = Instantiate(minionPrefab, spawnPosition, Quaternion.identity);
        var minionBehavior = minion.GetComponent<MinionBehavior>();
        if (minionBehavior != null)
        {
            minionBehavior.target = target;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            gameObject.SetActive(false);
            Invoke("RespawnSummoner", 10f);
        }
    }

    private void RespawnSummoner()
    {
        gameObject.SetActive(true);
    }
}
