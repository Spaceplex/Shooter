using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TagSystem : MonoBehaviour
{

    public static Queue<EnemyController> taggedObjects = new Queue<EnemyController>();
    public Text queueText;
    private string output = "";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      output = "";
      if(taggedObjects.Count == 0)
        output = "None";
      else {
        foreach(EnemyController e in taggedObjects){
          output += e.parent.name + " ";
        }
      }
      queueText.text = output;

    }

    public static void TagEnemy(EnemyController enemy){
      enemy.TakeDamage();
      if (enemy.tags != 0){
        enemy.IncrementTag();
      } else {
        if (taggedObjects.Count < 3){
          taggedObjects.Enqueue(enemy);
        }
        if (taggedObjects.Count > 3){
          Debug.LogError("3 enemy tags should not be exceeded");
        }

        if (taggedObjects.Count == 3){
          taggedObjects.Peek().ResetTag();
          taggedObjects.Dequeue();
          taggedObjects.Enqueue(enemy);
        }
        enemy.IncrementTag();
      }
    }
}
