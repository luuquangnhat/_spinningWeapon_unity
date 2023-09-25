using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ManagerCharacterStatus : MonoBehaviour
{
    private Guid id;
    private int health;
    private List<GameObject> weaponEquips;
    [Header("Prefab")]
    [SerializeField]
    private GameObject weaponSlotPrefab;
    [SerializeField]
    private List<GameObject> weaponObjPrefab;

    [Header("List Property")]
    private List<ManagerWeaponSlot1> handleSlots;
    private List<string> weaponsName;

    public Guid ID
    {
        get { return id; }
    }

    public CharacterType Type;
    public enum CharacterType
    {
        None,
        Main,
        NPC,
        Enemy
    }

    void Start()
    {
        id = Guid.NewGuid();
        Type = CharacterType.None;
    }

    private void Awake()
    {
        weaponEquips = new List<GameObject>();
        handleSlots = new List<ManagerWeaponSlot1>();
        weaponsName = new List<string>();

        CharacterStatusData fakeData = new CharacterStatusData();
        fakeData.id = Guid.NewGuid().ToString();
        fakeData.weaponsName = new string[3] {"AxeBasic", "Bow", "Spear"}.ToList();
        onReceiveData(fakeData);
    }

    private void onReceiveData(CharacterStatusData characterStatus)
    {
        for (int i = 0; i < characterStatus.weaponsName.Count; i++)
        {
            createWeaponSlot(characterStatus.weaponsName.Count, i);
            createWeaponObj(characterStatus.weaponsName[i]);
        }
    }


    private void createWeaponSlot(int noOfSlot, int indexSlot)
    {
        handleSlots.Clear();
        GameObject weaponSlot = Instantiate(weaponSlotPrefab, this.transform);
        weaponSlot.GetComponent<ManagerWeaponSlot1>().setPosition(noOfSlot, indexSlot);
        handleSlots.Add(weaponSlot.GetComponent<ManagerWeaponSlot1>());

    }

    private void createWeaponObj(string prefabName)
    {
        for (int i = 0; i < weaponObjPrefab.Count; i++)
        {
            if (weaponObjPrefab[i].gameObject.name == prefabName)
            {
                GameObject weaponObj = Instantiate(weaponObjPrefab[i], this.transform);
                //ManagerWeaponSlot1 slot = handleSlots.Where(m=>m.isEquipped == false).FirstOrDefault();
                for (int j = 0; j < handleSlots.Count; j++)
                {
                    if (!handleSlots[j].isEquipped)
                    {
                        ManagerWeaponSlot1 slot = handleSlots[j];
                        if (slot.gameObject)
                        {
                            weaponObj.GetComponent<ManagerWeaponObj1>().setSlotTarget(slot.gameObject);
                            slot.isEquipped = true;
                            slot.isMove = true;
                            break;
                        }
                    }
                }
            }
        }
    }

    void Update()
    {

    }
}
