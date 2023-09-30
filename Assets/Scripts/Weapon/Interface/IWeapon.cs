using UnityEngine;

public interface IWeapon
{
    public void SetEnemyTarget(GameObject enemyTarget);

    public void SetWeaponSlot(GameObject weaponSlot);

    public void HandleIdle();
    public void HandleMoveToEnemy(float time);
    public void HandleAttacking();
    public void HandleStopAttacking();
}
