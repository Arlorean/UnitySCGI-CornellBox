using UnityEngine;

[ExecuteInEditMode]
public class CameraAspectFit : MonoBehaviour {
    public float targetAspect = 1.0f; // 500x500 = 1:1

    void Update() {
        var cam = Camera.main;

        var windowAspect = (float)Screen.width / Screen.height;
        var scaleHeight = windowAspect / targetAspect;

        var rect = cam.rect;

        if (scaleHeight < 1.0f) {
            // Screen is taller (narrow display)
            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;
        }
        else {
            // Screen is wider
            var scaleWidth = 1.0f / scaleHeight;

            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;
        }

        cam.rect = rect;
    }
}