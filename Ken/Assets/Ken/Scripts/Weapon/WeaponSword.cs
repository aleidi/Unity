using UnityEngine;

public class WeaponSword : WeaponBase
{
    public WeaponSword() { }

    public override void WeaponAttack(Character target)
    {
         
        Debug.Log("Weapon Attack!");
    }
}
