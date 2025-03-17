using System.Collections;
using UnityEngine;

public class BulletLifeKill : MonoBehaviour
{

    public Transform orientation;

    float speed = 100.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        orientation = GameObject.FindGameObjectWithTag("Gun").transform;
        StartCoroutine(BKill());
        transform.rotation = orientation.rotation;
    }

    void FixedUpdate()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }

    IEnumerator BKill(){
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}
