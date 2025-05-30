using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TagSystem : MonoBehaviour
{

    public static Queue<EnemyController> taggedObjects = new Queue<EnemyController>();
    public Text queueText;
    private string output = "";

    // Update is called once per frame
    void FixedUpdate()
    {
      DebugStuff();
    }

    void DebugStuff()
    {
      output = "";
      if(taggedObjects.Count == 0)
        output = "None";
      else {
        foreach(EnemyController e in taggedObjects){
          output += "<color=";
          switch(e.tags){
            case 1:
              output += "cyan";
              break;
            case 2:
              output += "orange";
              break;
            case 3:
              output += "magenta";
              break;
            default:
              break;
          }
          output += ">";
          output += e.parent.name + " ";
          output += "</color>";
        }
      }
      queueText.text = output;
    }

    public static void TagEnemy(EnemyController enemy){
      enemy.TakeDamage();
  
      // Situations:
      // 1: The queue doesn't have the enemy and adds it

      if (!taggedObjects.Contains(enemy)){

        if(taggedObjects.Count == 3){
          taggedObjects.Peek().ResetTag();
          taggedObjects.Dequeue();
        }

        taggedObjects.Enqueue(enemy);
      } else 

      // 2: The queue has the enemy and reprioritizes it
      {
        ReAdjustTags(enemy);
      }

      enemy.IncrementTag();

      /*if (enemy.tags != 0){*/
      /*  enemy.IncrementTag();*/
      /*} else {*/
      /*  if (taggedObjects.Count < 3){*/
      /*    taggedObjects.Enqueue(enemy);*/
      /*  }*/
      /*  if (taggedObjects.Count > 3){*/
      /*    Debug.LogError("3 enemy tags should not be exceeded");*/
      /*  }*/
      /**/
      /*  if (taggedObjects.Count == 3){*/
      /*    taggedObjects.Peek().ResetTag();*/
      /*    taggedObjects.Dequeue();*/
      /*    taggedObjects.Enqueue(enemy);*/
      /*  }*/
      /*  enemy.IncrementTag();*/
      /*}*/
    }

    public static void ReAdjustTags(EnemyController e){
      taggedObjects = new Queue<EnemyController>(taggedObjects.Where(x => x != e));
      taggedObjects.Enqueue(e);
    }
    public static void RemoveEnemy(EnemyController e){
      taggedObjects = new Queue<EnemyController>(taggedObjects.Where(x => x != e));
    }
}
