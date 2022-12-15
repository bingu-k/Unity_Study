using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inven : UI_Scene
{
    enum GameObjects
    {
        GridPanel
    }

    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();
        Bind<GameObject>(typeof(GameObjects));

        // 기존에 세팅되어있던 내용 Reset
        GameObject gridPanel = Get<GameObject>((int)GameObjects.GridPanel);
        foreach (Transform child in gridPanel.transform)
            Managers.Resource.Destroy(child.gameObject);

        // 실제 인벤토리 정보를 참고해서 해야함!
        for (int i = 0; i < 6; ++i)
        {
            //GameObject item = Managers.Resource.Instantiate("UI/Scene/UI_Inven_Item");
            //item.transform.SetParent(gridPanel.transform);
            // UI Manager가 직접 만들어주는 방식으로 제작
            GameObject item = Managers.UI.MakeSubItem<UI_Inven_Item>(parent: gridPanel.transform).gameObject;

            //UI_Inven_Item invenItem = Util.GetOrAddComponent<UI_Inven_Item>(item);
            // item.GetorAddComponent로 접근가능하게 Extension으로 제작
            UI_Inven_Item invenItem = item.GetOrAddComponent<UI_Inven_Item>();
            invenItem.SetInfo($"Sword {i}");
        }
    }
}
