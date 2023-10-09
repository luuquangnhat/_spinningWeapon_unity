using Assets.Scripts.Utils;
using UnityEngine;

public class LevelMapManagerScript : MonoBehaviour
{
    private Grid grid;
    private void Start()
    {
        grid = new Grid(4, 2, 4f, new Vector3(-20, 0));
        new Grid(2, 5, 5f, new Vector3(0, -20));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            grid.SetValue(UtilsClass.GetMouseWorldPosition(), 56);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(grid.GetValue(UtilsClass.GetMouseWorldPosition()));
        }
    }
}