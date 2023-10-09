using UnityEngine;

public class MenuSceneManagerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabCanvasMenu;

    private void OnEnable()
    {
        Instantiate(prefabCanvasMenu);
    }
}
