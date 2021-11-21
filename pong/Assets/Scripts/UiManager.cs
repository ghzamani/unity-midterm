using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text heartsText;
    public Text looseText;
    public EventSystemCustom eventSystem;

    void Start()
    {
        eventSystem.OnHeartDecrease.AddListener(UpdateHeartsText);
	}

    public void UpdateHeartsText()
    {
		var text = heartsText.text.Split(':');
		int oldValue = int.Parse(text[1]);

		int newValue = oldValue - 1;
		if (newValue == 0)
		{
			Debug.Log("old is zero");
			EndGame();
		}
		heartsText.text = "Hearts:" + newValue.ToString();
	}

	void EndGame()
	{
		Debug.Log("called end");

		var ball = GameObject.Find("Ball");
		ball.SetActive(false);
		looseText.text = "YOU LOOSED";
	}

}
