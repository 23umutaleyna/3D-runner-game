using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f; 
    Rigidbody rb;
    [SerializeField] GameObject[] laneCenters;
    int currentLane = 1;
    float targetX;
    [SerializeField] float laneChangeSpeed = 5f;
    [SerializeField] float jumpForce = 10f;

    AudioSource audioSource;
    [SerializeField] AudioClip[] runSound;
    
    [SerializeField] AudioClip jumpSound, pickupSound;
    [SerializeField] float stopDelay = 0.3f;

    [SerializeField] ParticleSystem jumpEffect, pickUpEffect;
    private float nextStepTime = 0f;


    Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.position = laneCenters[currentLane].transform.position;
        targetX = transform.position.x;

        animator = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        moveSpeed += Time.deltaTime * 1.5f;

        if (Input.GetKeyDown(KeyCode.A) && currentLane > 0)
        {
            currentLane--;
            targetX = laneCenters[currentLane].transform.position.x;
        }
        else if (Input.GetKeyDown(KeyCode.D) && currentLane < 2)
        {
            currentLane++;
            targetX = laneCenters[currentLane].transform.position.x;
        }
        if (Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            if(Time.time>=nextStepTime)
            {
                audioSource.PlayOneShot(runSound[Random.Range(0, runSound.Length)]);
                nextStepTime = Time.time + stopDelay;
            }
            animator.SetBool("jump", false);
            if (Input.GetKeyDown(KeyCode.Space))
            {            
                rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
                Instantiate(jumpEffect,transform.position, Quaternion.identity);
                audioSource.Stop();
                audioSource.PlayOneShot(jumpSound);
                animator.SetBool("jump", true);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Slow"))
        {
            moveSpeed = moveSpeed / 1.3f;
            Instantiate(pickUpEffect, transform.position, Quaternion.identity);

            audioSource.Stop();
            audioSource.PlayOneShot(pickupSound);
            Destroy(collision.gameObject);
        }
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.forward * moveSpeed * Time.fixedDeltaTime);
        float direction = targetX - rb.position.x;
        rb.velocity = new Vector3(direction * laneChangeSpeed, rb.velocity.y, rb.velocity.z);
    }
}

