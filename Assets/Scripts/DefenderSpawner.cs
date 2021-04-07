using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    GameObject defenderParent;
    const string DEFENDER_PARENT_NAME = "Defenders";

    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject lossLabel;
    [SerializeField] AudioClip[] placeSounds;
    [SerializeField] [Range(0, 1)] float placeSoundVolume = 0.5f;
    [SerializeField] AudioClip errorSound;
    [SerializeField] [Range(0, 1)] float errorSoundVolume = 0.5f;

    private void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown()
    {
        if (!defender) { return; }
        AttemptToPlaceDefenderAt(GetSquareClicked());
    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        var CoinDisplay = FindObjectOfType<CoinsDisplay>();
        int defenderCost = defender.GetCoinCost();

        //As long as the level isn't over, attempt to place defender
        if (!winLabel.activeSelf && !lossLabel.activeSelf)
        {
        if (CoinDisplay.HaveEnoughCoins(defenderCost))
        {
            SpawnDefender(gridPos);
            CoinDisplay.SpendCoins(defenderCost);
        }
        else
        {
            AudioSource.PlayClipAtPoint(errorSound, Camera.main.transform.position, errorSoundVolume);
            FindObjectOfType<TextShake>().Begin();
        }
    }
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        //Convert clickPos into world units
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 roundedPos)
    {
        Defender newDefender = Instantiate(defender, roundedPos, Quaternion.identity) as Defender;
        AudioClip placeClip = placeSounds[Random.Range(0, placeSounds.Length)];
        AudioSource.PlayClipAtPoint(placeClip, Camera.main.transform.position, placeSoundVolume);
        newDefender.transform.parent = defenderParent.transform;
    }
}
