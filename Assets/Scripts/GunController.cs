using UnityEngine;
using System.Collections;
using EZEffects;

public class GunController : MonoBehaviour
{

    public GameObject controllerRight;

    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device device;


    private SteamVR_TrackedController controller;

    public EffectTracer TracerEffect;
    public Transform muzzleTransform;



    // Use this for initialization
    void Start()
    {

        controller = controllerRight.GetComponent<SteamVR_TrackedController>();
        controller.TriggerClicked += TriggerPressed;

        trackedObj = controllerRight.GetComponent<SteamVR_TrackedObject>();

    }

    private void TriggerPressed(object sender, ClickedEventArgs e)
    {
        ShootWeapon();
    }

    public void ShootWeapon()
    {
        RaycastHit hit = new RaycastHit();
        Ray ray = new Ray(muzzleTransform.position, muzzleTransform.forward);

        device = SteamVR_Controller.Input((int)trackedObj.index);
        device.TriggerHapticPulse(750);
        TracerEffect.ShowTracerEffect(muzzleTransform.position, muzzleTransform.forward, 250f);

        if (Physics.Raycast(ray, out hit, 5000f))
        {
            //TracerEffect.ShowTracerEffect(muzzleTransform.position, muzzleTransform.forward, hit.distance);
            if (hit.collider.attachedRigidbody)
            {
                Debug.Log("Target hit" + hit.collider.gameObject.name);
            }
        }
    }

}
