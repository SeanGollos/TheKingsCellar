using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    private SpriteRenderer rend;
    [SerializeField] Sprite defaultCursor;
    void Start()
    {
        Cursor.visible = false;
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;
    }

    public void ChangeCursor(Sprite newCursor)
    {
        rend.sprite = newCursor;
    }

    public void DefaultCursor()
    {
        rend.sprite = defaultCursor;
    }
}
