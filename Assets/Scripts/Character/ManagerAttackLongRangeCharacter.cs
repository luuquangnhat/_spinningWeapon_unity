using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerAttackLongRangeCharacter : MonoBehaviour
{
    private List<GameObject> weapons;
    public int radius = 8;
    public ManagerCharacterStatus.CharacterType longRangeType;

    private void OnEnable()
    {
        weapons = this.transform.parent.gameObject.GetComponent<ManagerCharacterStatus>().WeaponLongRangeEquips;
        this.gameObject.GetComponent<SphereCollider>().radius = radius;
    }

    private void OnTriggerEnter(Collider other)
    {
        ManagerCharacterStatus colliderTarget = other.gameObject.GetComponent<ManagerCharacterStatus>();
        if (colliderTarget && colliderTarget.Type != longRangeType)
        {
            switch (colliderTarget.Type)
            {
                case (ManagerCharacterStatus.CharacterType.Main):
                    Debug.Log($"colliderTarget.Type {colliderTarget.Type}");
                    //handleMainAttack(colliderTarget);
                    break;
                case (ManagerCharacterStatus.CharacterType.NPC):
                    handleNPCAttack(colliderTarget);
                    break;
                case (ManagerCharacterStatus.CharacterType.Enemy):
                    handleEnemyAttack(colliderTarget);
                    break;
                default:
                    throw new System.Exception("Error_InvalidColliderTargetType");
            }
        }
    }

    void handleEnemyAttack(ManagerCharacterStatus colliderTarget)
    {


    }
    void handleMainAttack(ManagerCharacterStatus colliderTarget)
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            if (weapons[i].gameObject.GetComponent<ManagerWeaponLongRangeAction>().EnemyTarget == null &&
                weapons[i].gameObject.GetComponent<ManagerWeaponData>().WeaponData.wpDamage <= colliderTarget.Health)
            {
                weapons[i].gameObject.GetComponent<ManagerWeaponLongRangeAction>().SetEnemyTarget(colliderTarget.gameObject);
                weapons[i].gameObject.GetComponent<ManagerWeaponLongRangeAction>().currentAction = EWeaponActionType.IsAttacking;
            }
        }
    }
    void handleNPCAttack(ManagerCharacterStatus colliderTarget)
    {

    }

    private void OnTriggerStay(Collider other)
    {
    }

    private void OnTriggerExit(Collider other)
    {
    }

}
