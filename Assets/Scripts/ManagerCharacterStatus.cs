using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ManagerCharacterStatus : MonoBehaviour
{
    private Guid id;
    private int hp;
    private List<GameObject> weaponEquids;
    [SerializeField]
    private GameObject weaponSlotPrefab;
    [SerializeField]
    private List<GameObject> weaponObjPrefab;

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
    // Start is called before the first frame update
    void Start()
    {
        id = Guid.NewGuid();
        Type = CharacterType.None;
        weaponEquids = new List<GameObject>();
    }

    void createWeaponSlot(int noOfSlot)
    {
        for (int i = 0; i < noOfSlot; i++)
        {
            GameObject weaponSlot = Instantiate(weaponSlotPrefab, this.transform);
            weaponSlot.GetComponent<ManagerWeaponSlot1>().updatePosition();
        }
    }

    void createWeaponObj(string prefabName)
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
