using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Button : UI_Popup
{
	enum Buttons
	{
		PointButton
	}
	enum Texts
	{
		PointText,
		ScoreText
	}

    enum GameObjects
    {
        TestObject
    }

    enum Images
    {
        ItemIcon
    }

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));
        Bind<Image>(typeof(Images));

        GetButton((int)Buttons.PointButton).gameObject.BindEvent(OnButtonClicked);

        GameObject go = GetImage((int)Images.ItemIcon).gameObject;
        BindEvent(go, (PointerEventData data) => { go.transform.position = data.position; }, Define.UIEvent.Drag);
        //Extension을 사용하면 한번에 호출가능하지만, 가독성이...?
        //GetImage((int)Images.ItemIcon).gameObject.BindEvent();
    }

    int _score = 0;

	public void OnButtonClicked(PointerEventData data)
	{ GetText((int)Texts.ScoreText).text = $"Score : {++_score}"; }
}