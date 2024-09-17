using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sizeChange : MonoBehaviour
{
   
    float pointsize;

    [SerializeField]
    float number01, number02;

    Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();

        // Use the Specular shader on the material
        rend.material.shader = Shader.Find("Point Cloud/Disk");
    }

    void Update()
    {
        // Animate the Shininess value
        //shininess = Mathf.PingPong(Time.time, 1.0f);
        pointsize = Random.Range(number01,number02);
        rend.material.SetFloat("_PointSize", pointsize);
    }
}
