using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    private enum enemyState {
      AIMING,
      SHOOTING
    };
    private enemyState state;
    private Transform playerTransform;
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
    if (state == enemyState.AIMING) TakeAim();
    else if (state == enemyState.SHOOTING) FireGun();
    if (active) StartCoroutine("sw");
  }

  void TakeAim()
  {
    aiming = true;
    //Debug.Log("Taking aim");
    stateText.text  = "State: Taking Aim";
    transform.LookAt(playerTransform);
  }

  void FireGun()
  {
    //Debug.Log("Pretend firing");
    stateText.text  = "State: Firing";
  }

  IEnumerator sw()
  {
    active = false;
    if (state == enemyState.AIMING) state = enemyState.SHOOTING;
    else if (state == enemyState.SHOOTING) state = enemyState.AIMING;
    yield return new WaitForSeconds(3f);
    active = true;
  }
}
