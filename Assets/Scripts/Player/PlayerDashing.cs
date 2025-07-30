using UnityEngine;

public class PlayerDashing : MonoBehaviour
{
  
  [Header("References")]
  public Transform orientation;
  public Rigidbody rb;
  public PlayerController pc;

  [Header("Dashing")]
  public float dashDuration;
  public float dashForce;
  public float dashUpwardForce;
  public bool dashed;
  public float maxDashSpeed = 1.5f;

  [Header("Cooldown")]
  public float dashCd;
  public float dashCdTimer;
  public float timer = 0.0f;
  public float timerEnd = 75f;

  [Header("Input")]
  // public Keycode dashKey = Keycode.E;
  public KeyCode dashkey = KeyCode.LeftShift;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      rb = GetComponent<Rigidbody>();
      pc = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(dashkey)){
        Dash();
      }
      if (dashed){
        while(timer < timerEnd){
          timer += (Time.deltaTime / 100.0f);

          dashForce = maxDashSpeed * (timer/timerEnd);

          Vector3 forceToApply = orientation.forward * dashForce;

          rb.AddForce(forceToApply, ForceMode.Force);
        }
        dashed = false;
        pc.movementState = PlayerController.MovementState.running;
        timer = 0f;
      }
    }

    void Dash(){
      dashed = true;
      pc.movementState = PlayerController.MovementState.dashing;

      Invoke(nameof(ResetDash), dashCdTimer);

    }

    void ResetDash(){

    }
}
