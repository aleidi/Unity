﻿using UnityEngine;

public abstract class CharacterFactoryBase
{
    public abstract Character CreatePlayer(EPlayer eChar,
                                              EWeapon eWeapon,
                                              Vector3 spawnPosition);

    public abstract Character CreateMonster(EMonster eMonster,
                                            EWeapon eWeapon,
                                            Vector3 spawnPosition);
}
