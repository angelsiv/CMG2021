using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    private float length, startPos;
    public GameObject camera;
    public float scrollEffect;

    // Start is called before the first frame update
    private void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<MeshRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    private void Update()
    {
        float temp = (camera.transform.position.x * (1 - scrollEffect));
        float distance = (camera.transform.position.x * scrollEffect);

        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);
        if (temp > startPos + length) 
        {
            startPos += length;
        }
        else if (temp < startPos - length)
        {
            startPos -= length;
        }
    }
}
