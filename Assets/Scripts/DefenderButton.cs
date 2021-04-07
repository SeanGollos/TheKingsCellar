using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;
    [SerializeField] Sprite cursor;

    private void Start()
    {
        LabelButtonWithCost();
    }

    private void LabelButtonWithCost()
    {
        Text costText = GetComponentInChildren<Text>();
        if(!costText)
        {
            Debug.LogError(name + " has no cost text, add some!");
        }
        else
        {
            costText.text = defenderPrefab.GetCoinCost().ToString();
        }
    }

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DefenderButton>();
        var anim = GetComponentInChildren<Animator>();
        foreach(DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(106, 106, 106, 255);
        }

        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<CursorController>().ChangeCursor(cursor);

        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
    }
}
