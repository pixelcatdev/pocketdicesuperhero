using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject playerObj;
    public int playerMoves;
    public int playerMovesMax;
    public int playerStrength;
    public int playerDefense;

    public TextMeshProUGUI txt_CityTileName;
    public TextMeshProUGUI txt_Strength;
    public TextMeshProUGUI txt_Defense;
    public TextMeshProUGUI txt_Moves;

    private void Start()
    {
        playerMoves = playerMovesMax;
    }

    private void Update()
    {
        PlayerInput();
        UpdateUI();
    }

    public void PlayerInput()
    {
        LayerMask hitLayer = LayerMask.GetMask("MouseLayer");
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0f, hitLayer);

        //On Detection
        if (hit)
        {
            txt_CityTileName.text = hit.transform.gameObject.GetComponent<CityTileProps>().tileName.ToUpper();

            //On Click
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                float distanceToPlayer = Vector2.Distance(hit.transform.position, playerObj.transform.position);

                //If its close enough and there's enough moves left, move the player
                if (playerMoves > 0 && distanceToPlayer == 1)
                {
                    playerMoves -= 1;
                    playerObj.transform.position = hit.transform.position;
                }
                else
                {
                    //Inform player no moves left
                    Debug.Log("No moves left");
                }
            }
        }
        else
        {
            txt_CityTileName.text = null;
        }
    }

    public void EndTurn()
    {
        Debug.Log("Ending Turn");
        //Damage any tiles
        //Move any bosses
        //Roll fate dice
        ResetPlayerStats();
    }

    void ResetPlayerStats()
    {
        playerMoves = playerMovesMax;
    }

    void UpdateUI()
    {
        if(playerMoves > 0)
        {
            txt_Moves.text = "MOVES " + playerMoves.ToString();
        }
        else
        {
            txt_Moves.text = "NO MOVES REMAINING";
        }

        txt_Strength.text = "STR " + playerStrength.ToString();
        txt_Defense.text = "DEF " + playerDefense.ToString();
    }
  
}
