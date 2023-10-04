using System.Collections.Generic;
using UnityEngine;

public class DynamicScrollView : MonoBehaviour
{
    [SerializeField]
    private Transform scrollViewContent;

    [SerializeField]
    private GameObject prefabMenuItem;
 

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject button = Instantiate(prefabMenuItem, scrollViewContent);
        }
    }

}
