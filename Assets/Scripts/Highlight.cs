using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    [SerializeField] GameObject highlight;
    [SerializeField] float playspaceHighlightTime = 3f;

    private void OnMouseDown()
    {
        //Destroy(highlight);
        GetComponentInChildren<Animator>().SetBool("moveHighlight", true);
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(playspaceHighlightTime);
        Destroy(highlight);
    }
}
