using UnityEngine;

abstract public class CharacterFactoryBase
{
    abstract public Character CreatePlayer(EPlayer eChar,
                                              EWeapon eWeapon,
                                              Vector3 spawnPosition);

    abstract public Character CreateMonster(EMonster eMonster,
                                            EWeapon eWeapon,
                                            Vector3 spawnPosition);
}
