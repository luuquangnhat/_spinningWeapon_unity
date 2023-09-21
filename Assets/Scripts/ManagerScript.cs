using Assets.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class ManagerScript : MonoBehaviour
{

    public GameObject yBot;
    public GameObject spinningCube;
    public int isMainPosition;
    List<GameObject> ListYBot;

    // Start is called before the first frame update
    void Start()
    {
        ListYBot = new List<GameObject>();
        //GameObject baseStanding = new GameObject("Test object", typeof(TestComponent), typeof(CharacterController));
        for (int i = 0; i < 1; i++)
        {
            GameObject character = Instantiate(yBot);
            character.transform.position = new Vector3(i * 5, 0, 0);
            character.AddComponent<CharacterMoving1>();
            character.AddComponent<TwoDimensionalAnimationStateController>();

            if (i == isMainPosition)
            {
                character.GetComponent< CharacterMoving1>().IsMain = true;
                character.GetComponent<TwoDimensionalAnimationStateController>().IsMain = true;
            }
            ListYBot.Add(character);
        }
        GameObject weapon = Instantiate(spinningCube, ListYBot[isMainPosition].transform);
        weapon.GetComponent<ManageWeapon>().mainTarget = ListYBot[isMainPosition];
        //StartCoroutine(coroutineHandleChangeMain());
    }


    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator coroutineHandleChangeMain()
    {
        yield return new WaitForSeconds(5);
        releaseIsMain();
        isMainPosition = 2;
        ListYBot[isMainPosition].GetComponent<CharacterMoving1>().IsMain = true;
        ListYBot[isMainPosition].GetComponent<TwoDimensionalAnimationStateController>().IsMain = true;
    }

    void releaseIsMain()
    {
        for (int i = 0; i < ListYBot.Count; i++)
        {

            ListYBot[i].GetComponent<CharacterMoving1>().IsMain = false;
            ListYBot[i].GetComponent<TwoDimensionalAnimationStateController>().IsMain = false;
        }
    }

    void handleSetMain()
    {
        for (int i = 0; i < ListYBot.Count; i++)
        {
            if (i == isMainPosition)
            {
                Debug.Log($"isMainPosition {isMainPosition}");
                Debug.Log($"i {i}");
                ListYBot[isMainPosition].GetComponent<CharacterMoving1>().IsMain = true;
                ListYBot[isMainPosition].GetComponent<TwoDimensionalAnimationStateController>().IsMain = true;
            }
        }
    }
}
