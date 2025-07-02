using UnityEngine;
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

  // states
  private bool active = true;

  void Start()
  {
    state = enemyState.AIMING;
    playerTransform = GameObject.Find("Player").transform;
  }

  void FixedUpdate()
  {
    if (state == enemyState.AIMING) TakeAim();
    else if (state == enemyState.SHOOTING) FireGun();
  }

  void TakeAim()
  {
    transform.LookAt(playerTransform);
    if (active) StartCoroutine("sw");
  }

  void FireGun()
  {
    Debug.Log("Pretend firing");
    if (active) StartCoroutine("sw");
  }

  IEnumerator sw()
  {
    active = false;
    yield return new WaitForSeconds(3f);
    active = true;
    state++;
  }
}
