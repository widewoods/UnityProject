using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Texture : MonoBehaviour
{
    Texture2D tex;
    // Start is called before the first frame update
    void Start()
    {
        int width = 400;
        int height = 400;
        tex = new Texture2D(width, height);

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Sprite sprite = Sprite.Create(tex, new Rect(0f, 0f, width, height), new Vector2(0.5f, 0.5f), 40);

        tex.filterMode = FilterMode.Point;

        sr.sprite = sprite;

        UpdateTexture();
    }

    void UpdateTexture()
    {
        for(int x = 0; x < tex.width; x++)
        {
            tex.SetPixel(x, 200, Color.black);
            tex.SetPixel(200, x, Color.black);
            tex.SetPixel(x,  (int)(50 * Mathf.Sin(2 * (x-200) * Mathf.Deg2Rad) + 200), Color.black);
        }

        tex.Apply();
    }

    float Function(float x)
    {
        return -x * x * x;
    }
}
