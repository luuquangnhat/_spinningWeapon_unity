using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateCharacterSceneManagerScript : MonoBehaviour
{

    public GameObject yBotPrefab;

    public int isMainPosition;
    List<GameObject> ListYBot;

    // Start is called before the first frame update
    void Start()
    {
        ListYBot = new List<GameObject>();
        for (int i = 0; i < 5; i++)
        {
            GameObject character = Instantiate(yBotPrefab);
            character.transform.position = new Vector3(i * 5, 0, 0);
            character.AddComponent<ManagerCharacterMovingPosition>();
            character.AddComponent<ManagerCharacterMovingAnimation>();

            if (i == isMainPosition)
            {
                character.GetComponent<ManagerCharacterMovingPosition>().IsMain = true;
                character.GetComponent<ManagerCharacterMovingAnimation>().IsMain = true;
                character.GetComponent<ManagerCharacterStatus>().Type = ManagerCharacterStatus.CharacterType.Main;
            }
            else
            {
                character.GetComponent<ManagerCharacterMovingPosition>().IsMain = false;
                character.GetComponent<ManagerCharacterMovingAnimation>().IsMain = false;
                character.GetComponent<ManagerCharacterStatus>().Type = ManagerCharacterStatus.CharacterType.Enemy;
            }

            ListYBot.Add(character);
        }
        //StartCoroutine(coroutineHandleChangeMain());
    }


    void Update()
    {
    }

    IEnumerator coroutineHandleChangeMain()
    {
        yield return new WaitForSeconds(5);
        releaseIsMain();
        isMainPosition = 2;
        ListYBot[isMainPosition].GetComponent<ManagerCharacterMovingPosition>().IsMain = true;
        ListYBot[isMainPosition].GetComponent<ManagerCharacterMovingAnimation>().IsMain = true;
    }

    void releaseIsMain()
    {
        for (int i = 0; i < ListYBot.Count; i++)
        {

            ListYBot[i].GetComponent<ManagerCharacterMovingPosition>().IsMain = false;
            ListYBot[i].GetComponent<ManagerCharacterMovingAnimation>().IsMain = false;
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
                ListYBot[isMainPosition].GetComponent<ManagerCharacterMovingPosition>().IsMain = true;
                ListYBot[isMainPosition].GetComponent<ManagerCharacterMovingAnimation>().IsMain = true;
            }
        }
    }
}
