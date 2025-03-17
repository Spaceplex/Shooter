using System.Collections;
using UnityEngine;

public class BulletLifeKill : MonoBehaviour
{


    float speed = 100.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(BKill());
        transform.rotation = Camera.main.transform.rotation;
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
