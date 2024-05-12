using UnityEngine;
using System.Collections;
using static UnityEngine.EventSystems.EventTrigger;
using System.Collections.Generic;

public class SpaceFollower : MonoBehaviour
{
    public Transform centerObject;
    public float radius = 1.5f;
    public bool moveClockwise = true;
    public float speed = 2f;
    public Transform leader;
    public float followDistance = 0.5f;
    public float respawnTime = 3f;
    public static int entityCount = 0;

    public static List<SpaceFollower> AllEntities = new List<SpaceFollower>();



    private float angle;

    void Start()
    {
        AllEntities.Add(this);
        startAngle();
        entityCount++;
    }

    void Update()
    {
        if (leader != null && leader.gameObject.activeSelf)
        {
            followLeader();
        }
        else
        {
            moveIndepently();
        }

    }
    void OnDestroy()
    {
        AllEntities.Remove(this);
    }

    void startAngle()
    {
        if (centerObject != null)
        {
            Vector3 toCenter = transform.position - centerObject.position;
            angle = Mathf.Atan2(toCenter.z, toCenter.x);
        }
    }

    void followLeader()
    {
        Vector3 toLeader = leader.position - centerObject.position;
        float leaderAngle = Mathf.Atan2(toLeader.z, toLeader.x);

        angle = leaderAngle + (moveClockwise ? -1 : 1) * followDistance / radius;

        updatePoisiton();
    }

    void moveIndepently()
    {
        angle += Time.deltaTime * (moveClockwise ? speed : -speed);
        updatePoisiton();
    }

    void updatePoisiton()
    {
        Vector3 position;
        position.x = centerObject.position.x + radius * Mathf.Cos(angle);
        position.z = centerObject.position.z + radius * Mathf.Sin(angle);
        position.y = centerObject.position.y;
        transform.position = position;

        Vector3 forward = new Vector3(-Mathf.Sin(angle), 0, Mathf.Cos(angle));
        if (!moveClockwise) forward = -forward;
        transform.rotation = Quaternion.LookRotation(forward, Vector3.up);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            gameObject.SetActive(false);
            entityCount--;

            if (entityCount == 0)
            {
                MechBoss.spawnBoss();
            }
        }
    }

    public static void respawnLine(float delay)
    {

        MonoBehaviour root = FindObjectOfType<MonoBehaviour>();

        if (root != null)
        {
            root.StartCoroutine(delayRespawn(delay));
        }
    }

    private static IEnumerator delayRespawn(float delay)
    {
        yield return new WaitForSeconds(delay);
        respawnEntities();
    }

    public static void respawnEntities()
    {
        foreach (var entity in AllEntities)
        {
            entity.gameObject.SetActive(true);
            entity.respawnEntity();
        }
    }

    private void respawnEntity()
    {
        startAngle();
        entityCount++;
    }
}
