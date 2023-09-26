using UnityEngine;

public interface IWeapon
{
    public void handleIdle();
    public void handleAttacking(GameObject enemyTarget);
    public void handleStopAttacking();
}
