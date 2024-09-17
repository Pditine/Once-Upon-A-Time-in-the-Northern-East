using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveobj : MonoBehaviour
{
    [SerializeField]
    GameObject obj01, obj02, obj03, obj04;

    [SerializeField]
    float xAngle, yAngle, zAngle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        obj01.transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
        obj02.transform.Rotate(xAngle, yAngle, zAngle, Space.World);
        obj03.transform.Rotate(xAngle, yAngle, zAngle, Space.World);
        obj04.transform.Rotate(xAngle, yAngle, zAngle, Space.Self);

    }
}
