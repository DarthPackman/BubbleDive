using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float speed = 10.0f;
    [SerializeField] GameObject skybox;
    // Update is called once per frame
    void Update()
    {
        skybox.transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
}
