using UnityEngine;

public class Switch_prototype : MonoBehaviour
{ 

  bool triggerSwitch = false;

  MeshRenderer renderr;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    renderr = GetComponent<MeshRenderer>();

  }

  // Update is called once per frame
  void Update()
  {
    if (triggerSwitch){
      renderr.material.color = Color.green;
    }

  }

  void OnTriggerEnter(Collider other){
    if (other.tag == "Bullet")
      triggerSwitch = true;
  }

  public bool SwitchActivated(){
    return triggerSwitch;
  }
}
