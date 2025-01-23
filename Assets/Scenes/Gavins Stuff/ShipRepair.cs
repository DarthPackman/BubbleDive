using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipRepair : MonoBehaviour
{
    [SerializeField] private GameObject rightEngine;
    [SerializeField] private GameObject leftEngine;

    public bool rightEngineRepaired = false;
    public bool leftEngineRepaired = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rightEngineRepaired)
        {
            rightEngine.SetActive(true);
        }
        if(leftEngineRepaired)
        {
            leftEngine.SetActive(true);
        }
        if(rightEngineRepaired && leftEngineRepaired)
        {
            Debug.Log("Ship is repaired");
        }
    }
}
