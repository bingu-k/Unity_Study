using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    protected override void Init()
    {
        base.Init();
        SceneType = Define.Scene.Game;
        Managers.UI.ShowSceneUI<UI_Inven>();

        Dictionary<int, Stat> dict = Managers.Data.StatDict;
        foreach (var element in dict)
        {
            Debug.Log($"{element.Key} : {element.Value.level}, {element.Value.hp}, {element.Value.attack}");
        }
    }

    public override void Clear()
    {

    }
}
