using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOfLifeVisual : MonoBehaviour
{
    public GameOfLife game;
    SpriteRenderer sprite;

    public int x, y;

    private void Awake()
    {
        game = FindObjectOfType<GameOfLife>();
        InvokeRepeating("UpdateVisuals", 0, game.cellUpdateTimer);
    }

    private void Update()
    {
        game.cells[x, y].timeSinceDeath += Time.deltaTime;
        UpdateVisuals();
    }

    void UpdateVisuals()
    {
        sprite  = gameObject.GetComponent<SpriteRenderer>();

        if (game.cells[x, y].state == 1)
        {
            game.cells[x, y].timeSinceDeath = 0;
            sprite.color = Color.white;
        }
        else
        {
            sprite.color = Color.black;
        }
        //Color using gradient
        if(game.cells[x, y].timeSinceDeath != 0)
        {
            sprite.color = game.gradient.Evaluate(game.cells[x, y].timeSinceDeath);
        }
    }
}
