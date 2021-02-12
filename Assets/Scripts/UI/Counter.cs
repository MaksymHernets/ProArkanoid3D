using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text text;
    public Text value;

    private int _value = 0;

    public void Increment()
	{
        ++_value;
		value.text = _value.ToString();
	}

	public void Resett()
	{
		_value = 0;
		value.text = _value.ToString();
	}
}
