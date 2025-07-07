using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
  private enum enemyState 
  {
    AIMING,
    SHOOTING
  };
  enemyState state;
  Transform playerTransform;
  public Text stateText;

  // states
  private bool active = true;
  private bool aiming = false;

  void Start()
  {
    state = enemyState.AIMING;
    playerTransform = GameObject.Find("Player").transform;
  }

  void FixedUpdate()
  {
    if (active){
      if (state == enemyState.AIMING) TakeAim();
      else if (state == enemyState.SHOOTING) FireGun();
    }
  }

  void TakeAim()
  {
    aiming = true;
    //Debug.Log("Taking aim");
    stateText.text  = "State: Taking Aim";
    if(aiming) transform.LookAt(playerTransform);
    StartCoroutine("sw");
  }

  void FireGun()
  {
    //Debug.Log("Pretend firing");
    stateText.text  = "State: Firing";
    StartCoroutine("sw");
  }

  IEnumerator sw()
  {
    active = false;
    yield return new WaitForSeconds(3f);
    active = true;
    if (state == enemyState.AIMING) state = enemyState.SHOOTING;
    else if (state == enemyState.SHOOTING) state = enemyState.AIMING;
  }
}
