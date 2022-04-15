using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFreeze : MonoBehaviour
{
    // Update is called once per frame
    void Awake()
    {
        UnityEngine.XR.XRDevice.DisableAutoXRCameraTracking(Camera.main, true);
    }

}
