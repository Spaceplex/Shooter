using UnityEngine;

public class PlayerGun : MonoBehaviour
{

    public ThirdPersonCam camScript;
    
    public Transform gunBarrelTransform;
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    public GameObject bullet;

    bool combat;

    void Update()
    {
        combat = camScript.currentStyle == ThirdPersonCam.CameraStyle.Combat;
        if (combat){
            if (Input.GetMouseButtonDown(0))
            {
                gunShoot();
            }
        }
    }

    private void gunShoot(){
        //Vector2 screenCenterPoint = new Vector2(Screen.width/2f, Screen.height/2f);
        //Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        //if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask)){
        //bulletDirection.transform.position = raycastHit.point;
        Instantiate(bullet, gunBarrelTransform.position, Camera.main.transform.rotation);
        //} else {
        //    return;
        //}

    }
}
