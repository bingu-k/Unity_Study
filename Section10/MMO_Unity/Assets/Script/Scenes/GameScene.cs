using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    //private void Start()
    //{
    //    Init();
    //}

    public override void Clear()
    {

    }

    protected override void Init()
    {
        base.Init();
        SceneType = Define.Scene.Game;
        Managers.UI.ShowSceneUI<UI_Inven>();

        for (int i = 0; i < 5; ++i)
            Managers.Resource.Instantiate("UnityChan");
    }
}
