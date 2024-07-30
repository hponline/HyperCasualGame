using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    private Animator animator;

    [Header("Hýz Deðiþkenleri")]
    public float z_speed = 10f;
    public float laneChangeSpeed = 5f;
    public float laneDistance = 3.0f; // Sað ve sol þeritler arasýndaki mesafe
    public float runCooldown = 5;

    private int desiredLane = 1; // 0: sol, 1: orta, 2: sað

    
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        // Karakterin sürekli ileri hareket etmesini saðlama
        
        // Karakter idle animasyonu
        if (runCooldown < Time.time)
        {
            direction.z = z_speed;
            animator.SetBool("isRunning", true);
        }

        // Yol deðiþtirme
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
        }

        // Hedef yolu belirleme
        Vector3 targetPosition = transform.position;
        if (desiredLane == 0)
        {
            targetPosition = new Vector3(-laneDistance, transform.position.y, transform.position.z);
        }
        else if (desiredLane == 1)
        {
            targetPosition = new Vector3(0, transform.position.y, transform.position.z);
        }
        else if (desiredLane == 2)
        {
            targetPosition = new Vector3(laneDistance, transform.position.y, transform.position.z);
        }

        // Karakteri hedef pozisyona doðru hareket ettirme
        Vector3 moveDirection = Vector3.Lerp(transform.position, targetPosition, laneChangeSpeed * Time.deltaTime);      
        moveDirection.z = transform.position.z;
        controller.Move(moveDirection - transform.position);

    }

    private void FixedUpdate()
    {
        // Hareket ettirme
        controller.Move(direction * Time.fixedDeltaTime);
    }
}
