using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;

    [Header("Movement")]
    Vector3 moveDirection;
    public float moveSpeed = 10.0f;
    public float groundDrag;

    public Transform orientation;

    [Header("Inputs")]
    float horizontalInput;
    float verticalInput;

    Vector3 mouseWorldPosition = Vector3.zero;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    [SerializeField] bool isGrounded;

    [Header("Combat")]
    [SerializeField] bool inCombat = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        // ground check
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();

        // handle drag
        if(isGrounded){
            rb.linearDamping = groundDrag;
        } else {
            rb.linearDamping = 0f;
        }

        if (inCombat){
            AlignPlayer();
        }
    }

    private void FixedUpdate(){
        PlayerMove();
    }

    private void MyInput(){
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetMouseButtonDown(1)){
            inCombat = true;
        }

        if (Input.GetMouseButtonUp(1)){
            inCombat = false;
        }
    }

    private void PlayerMove(){
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    private void AlignPlayer(){
        Vector3 worldAimTarget = mouseWorldPosition;
        worldAimTarget.y = transform.position.y;
        Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

        transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
    }
}
