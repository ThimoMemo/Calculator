using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Calculation : MonoBehaviour
{
    [SerializeField]
    TMP_Text text;

    [SerializeField]
    List<string> orders = new List<string>();
    [SerializeField]
    List<int> values = new List<int>();

    public void AddNumber(int numberToAdd)
    {
        Debug.Log("Adding Number: " + numberToAdd.ToString());

        if (numberToAdd == 0 && text.text.StartsWith("0"))
        {
            Debug.Log("Ends With 0, returning");
            return;
        }

        if (text.text == "0")
        {
            text.text = "";
        }

        text.text = text.text + numberToAdd.ToString();
    }

    public void Clear()
    {
        text.text = "0";
        orders.Clear();
        values.Clear();
    }

    public void AddDot()
    {
        if (text.text.Contains("."))
        {
            return;
        }
        text.text = text.text + ".";
    }
    public void Add()
    {
        orders.Add("+");
        values.Add(Convert.ToInt32(text.text));
        text.text = "0";
        Equels();
        orders.Clear();
        values.Clear();
    }

    public void Equels()
    {
        if (text.text != "0" && text.text.StartsWith(".") == false)
        {
            values.Add(Convert.ToInt32(text.text));
        }

        for (int i = 0; i < orders.Count; i++)
        {
            if(orders[i] == "+")
            {
                Debug.Log(i + 1);
                text.text = Convert.ToString(values[i] + values[i + 1]);
            }
            else if(orders[i] == "-")
            {
                text.text = Convert.ToString(values[i] = values[i++]);
            }
        }
    }
}
