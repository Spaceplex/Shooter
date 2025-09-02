using UnityEngine;
using UnityEngine.UI;

public class PlayerCC : MonoBehaviour
{

    [Header("References")]
    private CharacterController cc;
    public ThirdPersonCam thirdPersonCam;

    [Header("Inputs")]
    private float horizontalInput, verticalInput;
    public KeyCode dashKey = KeyCode.LeftShift;

    [Header("Movement")]
    private Vector3 moveDirection;
    private const float moveSpeed = 10f;
    [SerializeField] private float dashMult = 1f;

    [Header("Debug UI")]
    public Text stateText;


    [Header("References")]
    public Transform orientation;
    public enum PlayerState
    {
        Walking,
        Running,
        Dashing,
        Idle,
        Airborne
    };
    public PlayerState playerState;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cc = GetComponent<CharacterController>();
        playerState = PlayerState.Idle;
    }


    // Update is called once per frame
    void Update()
    {
        PlayerInput();
        DashUI();
    }

    void FixedUpdate()
    {
        PlayerMovement();
        if (Input.GetKeyDown(dashKey))
        {
            StartDash();
        }
        if (playerState == PlayerState.Dashing)
        {
            PlayerDash();
        }
    }

    void PlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    void PlayerMovement()
    {
        moveDirection = (orientation.forward * verticalInput) + (orientation.right * horizontalInput);

        if (playerState == PlayerState.Idle && moveDirection != Vector3.zero)
        {
            playerState = PlayerState.Running;
        }

        if (cc.isGrounded && moveDirection == Vector3.zero)
        {
            playerState = PlayerState.Idle;
        }

        cc.Move(moveDirection.normalized * moveSpeed * dashMult * Time.deltaTime);

        if (!cc.isGrounded)
        {
            cc.Move(Vector3.down);
        }
    }

    [Header("Dash vars")]
    float t = 0.0f;

    // Goal is to make a nier-automata-esc dash system
    // Snappy and fluid
    // Use a duration timer XX 
    // Just get the direction, set velocity to 0, set a point ahead and lerp over .6 seconds
    void PlayerDash()
    {
        t -= Time.deltaTime;
        if (t <= 0f)
        {
            t = 0f;
            playerState = PlayerState.Running;
            dashMult = 1f;
        }
    }

    private void StartDash()
    {
        playerState = PlayerState.Dashing;
        t = 0.75f;
        dashMult = 2.6f;
    }

    private string txt = "";
    private void DashUI()
    {
        switch (playerState)
        {
            case PlayerState.Idle:
                txt = "Idle";
                break;
            case PlayerState.Dashing:
                txt = "Dashing";
                break;
            case PlayerState.Running:
                txt = "Running";
                break;
            case PlayerState.Walking:
                txt = "Walking";
                break;
            case PlayerState.Airborne:
                txt = "Airborne";
                break;
            default:
                txt = "Somethings wrong";
                break;
        }

        stateText.text = "PlayerState: " + txt;
    }
}
