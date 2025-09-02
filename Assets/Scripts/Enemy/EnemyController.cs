using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{

    public Image healthBar;
    [SerializeField]
    private float health = 20.0f;
    [SerializeField]
    private float maxHealth = 100.0f;
    public GameObject parent;

    [SerializeField]
    public int tags = 0;

    // Update is called once per frame
    void Update()
    {
      if (health <= 0.0f){
        if (tags != 0){
          TagSystem.RemoveEnemy(this);
        }
        Destroy(parent);
      }
      healthBar.fillAmount = health/maxHealth;
    }

    public void TakeDamage()
    {
      health--;
    }

    public void TakeDamage(float d)
    {
      health -= d;
    }

    public void IncrementTag(){ if (tags < 3) tags++;}

    public void ResetTag(){tags = 0;}
}
