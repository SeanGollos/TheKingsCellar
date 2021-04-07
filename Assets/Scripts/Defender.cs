using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int coinCost = 100;
    [Range(0f, 5f)] float retreatSpeed = 1.5f;

    public int GetCoinCost()
    { return coinCost; }

    private void Update()
    {
        if (GetComponent<Animator>().GetBool("isRetreating"))
            transform.Translate(Vector2.left * retreatSpeed * Time.deltaTime);
    }

    public void AddCoins(int amount)
    {
        FindObjectOfType<CoinsDisplay>().AddCoins(amount);
    }

    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(1))
        {
            GetComponent<Animator>().SetBool("isRetreating", true);
        }
    }
    public void SetMovementSpeed(float speed)
    {
        retreatSpeed = speed;
    }
}