using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerMenuCanvasData : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabMenuItem;
    [SerializeField]
    private GameObject prefabMenuScrollView;

    private void OnEnable()
    {
        RectTransform content = prefabMenuScrollView.GetComponent<ScrollRect>().content;
        for (int i = 0; i < 5; i++)
        {
            Instantiate(prefabMenuItem, content);
        }
    }
}
