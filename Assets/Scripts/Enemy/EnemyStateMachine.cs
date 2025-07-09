using UnityEngine;
using System.Collections;

public class EnemyStateMachine : MonoBehaviour
{
  public EnemyAI eaiScript;

  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  // IEnumerator sw()
  // {
  //   eaiScript.active = false;
  //   yield return new WaitForSeconds(3f);
  //   eaiScript.active = true;
  //   if (eaiScript.state == EnemyAI.enemyState.AIMING) eaiScript.state = EnemyAI.enemyState.SHOOTING;
  //   else if (eaiScript.state == EnemyAI.enemyState.SHOOTING) eaiScript.state = EnemyAI.enemyState.AIMING;
  // }
}
