using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Inven_Item : UI_Base
{
    enum GameObjects
    {
        ItemIcon,
        ItemNameText
    }

    string _name;

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));
        Get<GameObject>((int)GameObjects.ItemNameText).GetComponent<Text>().text = _name;

        // Clicked Event Mapping
        Get<GameObject>((int)GameObjects.ItemIcon).BindEvent((PointEventData) => { Debug.Log($"Clicked {_name}"); });
    }

    private void PointEventData(PointerEventData obj)
    {
        throw new NotImplementedException();
    }

    public void SetInfo(string name)
    { _name = name; }
}
