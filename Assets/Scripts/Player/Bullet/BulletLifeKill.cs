using System.Collections;
using UnityEngine;

public class BulletLifeKill : MonoBehaviour
{

    private Rigidbody bulletRB;

    private float speed = 100.0f;
    public Vector3 forceEnd;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        bulletRB = GetComponent<Rigidbody>();
        bulletRB.linearVelocity = transform.forward * speed;
        StartCoroutine(BKill());
    }

    void FixedUpdate()
    {
        /*transform.Translate(transform.forward * speed * Time.deltaTime);*/
        bulletRB.AddForce(forceEnd, ForceMode.Force);
    }

    IEnumerator BKill(){
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}
