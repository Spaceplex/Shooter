using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{

    public Image healthBar;
    private float health = 20.0f;  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage()
    {
      health--;
      healthBar.fillAmount = health/20.0f;
    }
}
