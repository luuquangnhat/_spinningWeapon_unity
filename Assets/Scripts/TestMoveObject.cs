using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMoveObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(100, 0, 100), Time.deltaTime * 2f);
    }
}
