using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.L))
        {
            transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
        }
        if (Input.GetKey(KeyCode.R))
        {
            transform.Rotate(0f, -rotationSpeed * Time.deltaTime, 0f);
        }
    }
}
