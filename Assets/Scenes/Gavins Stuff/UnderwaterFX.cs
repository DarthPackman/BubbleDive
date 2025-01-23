using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderwaterFX : MonoBehaviour
{
    [SerializeField] GameObject waterfx;
    private void OnTriggerEnter(Collider other) {
        waterfx.gameObject.SetActive(true);
        RenderSettings.fog = true;
    }

    private void OnTriggerExit(Collider other) {
        waterfx.gameObject.SetActive(false);
        RenderSettings.fog = false;
    }
}
