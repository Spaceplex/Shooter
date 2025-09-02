using UnityEngine;

public class ShockSystem : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
      if (Input.GetKey(KeyCode.E))
      {
        foreach(EnemyController e in TagSystem.taggedObjects){
          e.TakeDamage(0.5f * e.tags);
        }
      }
    }
}
