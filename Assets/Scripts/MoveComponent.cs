using UnityEngine;

public class MoveComponent : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private GameObject centerObject;
    [SerializeField] private bool moveClockwise = true;
    [SerializeField] private float radiusOffset = 1f;

    private Animator animator;
    private float angle = 0f;
    private Vector3 centerObjectPosition;
    public bool isMoving = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isMoving", isMoving);
    }

    void Update()
    {
        if (isMoving)
        {
            centerObjectPosition = centerObject.transform.position;
            angle += Time.deltaTime * (moveClockwise ? speed : -speed);

            float x = Mathf.Cos(angle) * radiusOffset;
            float z = Mathf.Sin(angle) * radiusOffset;

            Vector3 newPosition = new Vector3(centerObjectPosition.x + x, centerObjectPosition.y, centerObjectPosition.z + z);
            transform.position = newPosition;
            Vector3 radialVector = newPosition - centerObjectPosition;
            Vector3 forward = moveClockwise ? Vector3.Cross(radialVector, Vector3.up) : Vector3.Cross(Vector3.up, radialVector);
            transform.rotation = Quaternion.LookRotation(forward, Vector3.up);
        }
    }

    public void SetMoving(bool moving)
    {
        isMoving = moving;
        animator.SetBool("isMoving", moving);
    }
}
