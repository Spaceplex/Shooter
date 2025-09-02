using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    private Rigidbody bulletRB;

    private const float speed = 50.0f;
    public Vector3 forceEnd;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      bulletRB = GetComponent<Rigidbody>();
      bulletRB.linearVelocity = transform.forward * speed;
      Destroy(this.gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
