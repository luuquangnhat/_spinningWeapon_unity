using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRotateAround : MonoBehaviour
{
    public GameObject sphere;
    // Start is called before the first frame update
    void Start()
    {
        //transform.RotateAround(sphere.transform.position, Vector3.down, 50 * Time.deltaTime);

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"sphere {sphere.transform.position}");
        transform.RotateAround(sphere.transform.position, Vector3.down, 50 * Time.deltaTime);
    }
}
