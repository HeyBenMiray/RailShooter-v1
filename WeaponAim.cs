using UnityEngine;

public class WeaponAim : MonoBehaviour
{
    public Camera mainCamera;
    public RectTransform crosshair;

    public Transform leftWeapon;
    public Transform rightWeapon;

    public float aimDistance = 100f;

    void Update()
    {
        Vector3 screenPosition = crosshair.position;

        Ray ray = mainCamera.ScreenPointToRay(screenPosition);

        Vector3 targetPoint = ray.GetPoint(aimDistance);

       
        Vector3 leftDirection = targetPoint - leftWeapon.position;

        if (leftDirection != Vector3.zero)
        {
            leftWeapon.rotation = Quaternion.LookRotation(leftDirection);
        }

       
        Vector3 rightDirection = targetPoint - rightWeapon.position;

        if (rightDirection != Vector3.zero)
        {
            rightWeapon.rotation = Quaternion.LookRotation(rightDirection);
        }
    }
}