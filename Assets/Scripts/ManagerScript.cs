using Assets.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static ManagerWeaponObj1;

public class ManagerScript : MonoBehaviour
{

    public GameObject yBotPrefab;
    public GameObject weaponPrefabSlot1;
    public GameObject weaponPrefabObj1;

    public int isMainPosition;
    List<GameObject> ListYBot;

    // Start is called before the first frame update
    void Start()
    {
        ListYBot = new List<GameObject>();
        //GameObject baseStanding = new GameObject("Test object", typeof(TestComponent), typeof(CharacterController));
        for (int i = 0; i < 5; i++)
        {
            GameObject character = Instantiate(yBotPrefab);
            character.transform.position = new Vector3(i * 5, 0, 0);
            character.AddComponent<CharacterMoving1>();
            character.AddComponent<TwoDimensionalAnimationStateController>();

            if (i == isMainPosition)
            {
                character.GetComponent<CharacterMoving1>().IsMain = true;
                character.GetComponent<TwoDimensionalAnimationStateController>().IsMain = true;
            }
            ListYBot.Add(character);
        }

        GameObject weaponSlot1 = Instantiate(weaponPrefabSlot1, ListYBot[isMainPosition].transform);
        weaponSlot1.GetComponent<ManagerWeaponSlot1>().updatePosition(ListYBot[isMainPosition]);

        GameObject weaponObj1 = Instantiate(weaponPrefabObj1, ListYBot[isMainPosition].transform);
        weaponObj1.GetComponent<ManagerWeaponObj1>().setSlotTarget(weaponSlot1);
        weaponObj1.GetComponent<ManagerWeaponObj1>().currentAction = ActionWeapon.IsIdle;

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
