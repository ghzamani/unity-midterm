﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{
    public UnityEvent OnHeartDecrease;

	void Awake()
    {
		OnHeartDecrease = new UnityEvent();
	}
}
