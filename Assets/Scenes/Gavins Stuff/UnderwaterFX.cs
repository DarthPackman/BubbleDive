using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class UnderwaterFX : MonoBehaviour
{
    [SerializeField] Transform Camera;
    [SerializeField] int depthLevel = 0;

    [SerializeField] Volume volume;

    [SerializeField] VolumeProfile underwaterProfile;
    [SerializeField] VolumeProfile defaultProfile;

    private void Update() {
        if (Camera.position.y < depthLevel) {
            EnableEffects(true);
        } else {
            EnableEffects(false);
        }
    }

    private void EnableEffects(bool active) {
        if (active) {
            volume.profile = underwaterProfile;
            RenderSettings.fog = true;
        } else {
            volume.profile = defaultProfile;
            RenderSettings.fog = false;
        }
    }
}
