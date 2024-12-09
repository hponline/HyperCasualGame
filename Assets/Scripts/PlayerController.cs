using Cinemachine;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class PlayerController : MonoBehaviour
{

    CharacterController controller;
    Vector3 direction;
    Animator anim;
    int desiredLane = 1; // 0: sol, 1: orta, 2: sað
    public GameObject finishScreen;
    public GameObject deadScreen;

    [Header("Hýz Deðiþkenleri")]
    public float z_speed = 10f;
    [SerializeReference]
    float laneChangeSpeed = 3f;
    float laneDistance = 12.0f; // Sað ve sol þeritler arasýndaki mesafe
    public float runCooldown = 5;


    [Header("Zemin Kontrol")]
    [SerializeField]
    Transform groundCheck;
    [SerializeField]
    float groundDistance = 0.3f;
    [SerializeField]
    LayerMask groundMask;
    [SerializeField, Range(0,4)]
    float jump = 3;
    public float gravity = -9.7f;
    bool isGrounded = false;
    float verticalVelocity;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Karakterin sürekli ileri hareket etmesini saðlama
        anim.SetBool("isRunning", false);

        // Karakter idle animasyonu
        if (runCooldown < Time.time)
        {
            direction.z = z_speed;
            anim.SetBool("isRunning", true);
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

        // karakter zýplama
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -2f; // Yere saðlam basmasýný saðlamak için negatif deðer
        }

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            verticalVelocity = Mathf.Sqrt(jump * -2f * gravity);
            JumpAnimation();
        }
        verticalVelocity += gravity * Time.deltaTime;
        direction.y = verticalVelocity;
    }

    private void FixedUpdate()
    {
        // Hareket ettirme
        controller.Move(direction * Time.fixedDeltaTime);
    }

    public void JumpAnimation()
    {
        anim.SetInteger("JumpIndex", Random.Range(0, 4));
        anim.SetTrigger("Jump");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstackle"))
        {
            anim.SetBool("isRunning", false);
            z_speed = 0f;
            anim.SetTrigger("isDead");
            anim.SetInteger("DeadIndex", Random.Range(0, 4));
            Invoke("DeadScreen", 2f);
        }
    }

    public void DeadScreen()
    {
        deadScreen.SetActive(true);
        Time.timeScale = 0f;
    }
}
// oyun baþladýgýnda geri sayým eklenecek
