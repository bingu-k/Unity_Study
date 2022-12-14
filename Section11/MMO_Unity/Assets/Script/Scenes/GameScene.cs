using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    //class Test
    //{
    //    public int id = 0;
    //}

    // Coroutine : 함수의 상태를 저장/복원 가능한 장점.
    // -> 오래걸리는 작업을 잠시 중단하는 경우
    // -> 원하는 타이밍에 함수를 잠시 중단/복원하는 경우
    // return -> 원하는 타입으로 가능(class도 가능)
    //class CoroutineTest : IEnumerable
    //{
    //    public IEnumerator GetEnumerator()
    //    {
    //        //yield return 1;
    //        //yield return 2;
    //        //yield return 3;
    //        //yield return 4;
    //        yield return new Test() { id = 1 };
    //        yield return new Test() { id = 2 };
    //        yield return new Test() { id = 3 };
    //        //yield return null; // 그냥 null return
    //        //yield break;    // Enumerate 종료
    //        yield return new Test() { id = 4 };
    //        for (int i = 0; i < 1000000; ++i)
    //        {
    //            if (i % 10000 == 0)
    //                yield return null;
    //        }
    //    }

    //    float deltaTime = 0;
    //    void ExplodeAfter4Sec()
    //    {
    //        deltaTime += Time.deltaTime;
    //        if (deltaTime >= 4)
    //        {
    //            // 로직
    //        }
    //    }
    //}

    Coroutine co;

    protected override void Init()
    {
        base.Init();
        SceneType = Define.Scene.Game;
        Managers.UI.ShowSceneUI<UI_Inven>();

        //CoroutineTest ct = new CoroutineTest();
        //foreach (System.Object t in ct)
        //{
        //    //int value = (int)t;
        //    Test value = (Test)t;
        //    Debug.Log(value.id);
        //}

        co = StartCoroutine("ExplodeAfterSec", 4.0f);
        StartCoroutine("StopExplode", 2.0f);
    }

    // 기본적인 Coroutine 방식
    IEnumerator ExplodeAfterSec(float sec)
    {
        Debug.Log("Explode Enter");
        yield return new WaitForSeconds(sec);

        Debug.Log("BOOOOOOOOOM!!!!!!!!!!");
    }

    IEnumerator StopExplode(float sec)
    {
        Debug.Log("Stop Enter");
        yield return new WaitForSeconds(sec);

        Debug.Log("chiiiii......");
        if (co != null)
        {
            StopCoroutine(co);
            co = null;
        }
    }

    public override void Clear()
    {

    }
}
