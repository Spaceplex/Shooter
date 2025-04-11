using UnityEngine;

public class PlayerGun : MonoBehaviour
{

    public ThirdPersonCam camScript;
    public Transform gunBarrelTransform;

    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    public GameObject bullet;
    private Vector3 mouseWorldPosition = Vector3.zero;

    public Transform bulletDirectionBackup;

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
        Vector2 screenCenterPoint = new Vector2(Screen.width/2f, Screen.height/2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        Vector3 bulletDirection = Vector3.zero;

        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask)){
          bulletDirection = raycastHit.point - transform.position;
          Debug.Log(bulletDirection);
        } else {
          bulletDirection = bulletDirectionBackup.position - transform.position;
        }

        Vector3 aimDir = (mouseWorldPosition - gunBarrelTransform.position).normalized;
        GameObject go = Instantiate(
            bullet, 
            gunBarrelTransform.position, 
            Quaternion.LookRotation(bulletDirection, Vector3.up)
        );
        go.GetComponent<BulletLifeKill>().forceEnd = bulletDirection;
    }
}
