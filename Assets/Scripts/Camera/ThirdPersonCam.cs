using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class ThirdPersonCam : MonoBehaviour
{

    [Header("References")]
    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    public Rigidbody rb;

    public Text debugText;

    public float rotationSpeed;

    public Transform combatLookAt;

    public CameraStyle currentStyle = CameraStyle.Free;
    public enum CameraStyle {
        Free,
        Combat,
        //Topdown
    }

    public CinemachineCamera aimCam;

    void Start(){
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // rotate orientation
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;
        
        // rotate player object
        if(currentStyle == CameraStyle.Free){
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

            if (inputDir != Vector3.zero)
                playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
        } else if (currentStyle == CameraStyle.Combat){
            Vector3 dirToCombatLookAt = combatLookAt.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
            orientation.forward = dirToCombatLookAt.normalized;

            playerObj.forward = dirToCombatLookAt.normalized;
        }

        if (Input.GetMouseButtonDown(1)){
            if (currentStyle == CameraStyle.Free){
                currentStyle = CameraStyle.Combat;
            } else if (currentStyle == CameraStyle.Combat){
                currentStyle = CameraStyle.Free;
            }
        } 
        debugText.text = "Mode: " + currentStyle;
    }
}
