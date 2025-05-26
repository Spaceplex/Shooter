using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{

    public Image healthBar;
    [SerializeField]
    private float health = 20.0f;
    public GameObject parent;

    [SerializeField]
    public int tags = 0;

    // Update is called once per frame
    void Update()
    {
      if (health <= 0.0f){
        Destroy(parent);
      }
      healthBar.fillAmount = health/20.0f;
    }

    public void TakeDamage()
    {
      health--;
    }

    /*void OnTriggerEnter(Collider other)*/
    /*{*/
    /*  if (other.CompareTag("Bullet")){*/
    /*    TakeDamage();*/
    /*  }*/
    /*  Destroy(other.gameObject);*/
    /*}*/

    public void IncrementTag(){
      if (tags < 3)
        tags++;
    }
    public void ResetTag(){tags = 0;}
}
