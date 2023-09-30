using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ManagerCharacterStatus : MonoBehaviour
{
    private Guid id;
    private int health = 100;
    private List<GameObject> weaponShortRangeEquips;
    private List<GameObject> weaponLongRangeEquips;
    public CharacterType Type;

    [Header("Prefab")]
    [SerializeField]
    private GameObject weaponSlotPrefab;
    [SerializeField]
    private List<GameObject> weaponObjPrefab;
    [SerializeField]
    private GameObject weaponRangeShortRangePrefab;
    [SerializeField]
    private GameObject weaponRangeLongRangePrefab;

    [Header("List Property")]
    private List<ManagerWeaponSlot1> handleSlots;
    private List<string> weaponsName;

    public List<GameObject> WeaponShortRangeEquips
    {
        get
        {
            return weaponShortRangeEquips;
        }
    }
    public List<GameObject> WeaponLongRangeEquips
    {
        get
        {
            return weaponLongRangeEquips;
        }
    }

    public Guid ID
    {
        get { return id; }
    }

    public int Health
    {
        get { return health; }
    }

    public enum CharacterType
    {
        None,
        Main,
        NPC,
        Enemy
    }
    private void OnEnable()
    {
        Type = CharacterType.None;
    }

    void Start()
    {
        id = Guid.NewGuid();
    }

    private void Awake()
    {
        weaponShortRangeEquips = new List<GameObject>();
        weaponLongRangeEquips = new List<GameObject>();
        handleSlots = new List<ManagerWeaponSlot1>();
        weaponsName = new List<string>();

        CharacterStatusData fakeData = new CharacterStatusData();
        fakeData.id = Guid.NewGuid().ToString();
        fakeData.weapons = new WeaponStatusData[2] {
            new WeaponStatusData {
                id = Guid.NewGuid().ToString(),
                wpName = "AxeBasic",
                wpRangeType = EWeaponRangeType.ShortRange,
                wpDamage = 10,
                wpMoveSpeed = 1,
                wpRange = 1,
                wpAttackSpeed = 1,
            },
            new WeaponStatusData {
                id = Guid.NewGuid().ToString(),
                wpName = "Bow",
                wpRangeType = EWeaponRangeType.LongRange,
                wpDamage = 10,
                wpMoveSpeed = 20,
                wpRange = 1,
                wpAttackSpeed = 1,
            },
            //new WeaponStatusData {
            //    id = Guid.NewGuid().ToString(),
            //    wpName = "Spear",
            //    wpRangeType = EWeaponRangeType.ShortRange,
            //    wpDamage = 10,
            //    wpMoveSpeed = 20,
            //    wpRange = 1,
            //    wpAttackSpeed = 1,
            //}
        }.ToList();
        onReceiveData(fakeData);
    }

    private void onReceiveData(CharacterStatusData characterStatus)
    {
        for (int i = 0; i < characterStatus.weapons.Count; i++)
        {
            createWeaponSlot(characterStatus.weapons.Count, i);
            createWeaponObj(characterStatus.weapons[i].wpName, characterStatus.weapons[i]);
        }
        GameObject weaponRangeShortRange = Instantiate(weaponRangeShortRangePrefab, this.transform);
        GameObject weaponRangeLongRange = Instantiate(weaponRangeLongRangePrefab, this.transform);
        weaponRangeShortRange.GetComponent<SphereCollider>().radius = weaponRangeShortRange.GetComponent<ManagerAttackShortRangeCharacter>().radius;
        weaponRangeShortRange.GetComponent<SphereCollider>().isTrigger = true;
        weaponRangeLongRange.GetComponent<SphereCollider>().radius = weaponRangeLongRange.GetComponent<ManagerAttackLongRangeCharacter>().radius;
        weaponRangeLongRange.GetComponent<SphereCollider>().isTrigger = true;
    }


    private void createWeaponSlot(int noOfSlot, int indexSlot)
    {
        handleSlots.Clear();
        GameObject weaponSlot = Instantiate(weaponSlotPrefab, this.transform);
        weaponSlot.GetComponent<ManagerWeaponSlot1>().setPosition(noOfSlot, indexSlot);
        handleSlots.Add(weaponSlot.GetComponent<ManagerWeaponSlot1>());
    }

    private void createWeaponObj(string prefabName, WeaponStatusData weaponStatusData)
    {
        for (int i = 0; i < weaponObjPrefab.Count; i++)
        {
            if (weaponObjPrefab[i].gameObject.name == prefabName)
            {
                GameObject weaponObj = Instantiate(weaponObjPrefab[i], this.transform); //ManagerWeaponSlot1 slot = handleSlots.Where(m=>m.isEquipped == false).FirstOrDefault(); //linq
                for (int j = 0; j < handleSlots.Count; j++)
                {
                    if (!handleSlots[j].isEquipped)
                    {
                        ManagerWeaponSlot1 slot = handleSlots[j];
                        if (slot.gameObject)
                        {
                            weaponObj.GetComponent<ManagerWeaponData>().setWeaponData(weaponStatusData);
                            weaponObj.GetComponent<ManagerWeaponData>().Weapon.SetWeaponSlot(slot.gameObject);
                            slot.isEquipped = true;
                            slot.isMove = true;
                            break;
                        }
                    }
                }
                switch (weaponObj.GetComponent<ManagerWeaponData>().WeaponData.wpRangeType)
                {
                    case EWeaponRangeType.ShortRange:
                        weaponShortRangeEquips.Add(weaponObj);
                        break;
                    case EWeaponRangeType.LongRange:
                        weaponLongRangeEquips.Add(weaponObj);
                        break;
                    default:
                        break;
                }

            }
        }
    }

    void Update()
    {

    }
}
