using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginScene : BaseScene
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // 그냥하면 안되고 Build Setting에서 Scene을 추가해야 가능하다.
            //SceneManager.LoadScene("Game");

            Managers.Scene.LoadScene(Define.Scene.Game);
        }
    }

    public override void Clear()
    {
        Debug.Log("Login Clear");
    }

    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Login;

    }
}
