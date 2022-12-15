using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : Stat
{
    [SerializeField]
    int _exp;
    [SerializeField]
    int _gold;

    public int Exp { get { return _exp; } set { _exp = value; } }
    public int Gold { get { return _gold; } set { _gold = value; } }

    private void Start()
    {
        Level = 1;
        Hp = 100;
        MaxHp = 100;
        Attack = 10;
        Defense = 5;
        MoveSpeed = 5.0f;
        Exp = 0;
        Gold = 0;
    }
}
