using System.Collections;
using UnityEngine;

public class BulletLifeKill : MonoBehaviour
{

    private Rigidbody bulletRB;

    private const float speed = 100.0f;
    public Vector3 forceEnd;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        bulletRB = GetComponent<Rigidbody>();
        bulletRB.linearVelocity = transform.forward * speed;
        Destroy(this.gameObject, 5f);
    }

    void FixedUpdate()
    {
        bulletRB.AddForce(forceEnd, ForceMode.Force);
    }

    void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.GetComponent<EnemyController>() != null){
        EnemyController e = other.GetComponent<EnemyController>();
        TagSystem.TagEnemy(e);
        Destroy(this.gameObject);
      }
    }

}
