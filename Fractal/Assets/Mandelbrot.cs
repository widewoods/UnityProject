using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mandelbrot : MonoBehaviour
{
    Texture2D texture;

    Dictionary<int, Color> iterationColor = new Dictionary<int, Color>();

    // Start is called before the first frame update
    void Start()
    {
        texture = new Texture2D(800, 800);
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        Sprite sprite = Sprite.Create(texture, new Rect(0f, 0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), texture.height/10);

        renderer.sprite = sprite;

        for(int i = 0; i < 100; i++)
        {
            iterationColor.Add(i, new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
        }

        UpdateTexture();
    }

    public void UpdateTexture()
    {
        for (int i = 0; i < texture.width; i++)
        {
            for (int j = 0; j < texture.height; j++)
            {
                float a = (i - texture.width / 2) / (float)(texture.width / 4f);
                float b = (j - texture.height / 2) / (float)(texture.height / 4f);

                float ca = a;
                float cb = b;

                int n = 0;
                int iterations = 100;
                while (n < iterations)
                {
                    float aa = a * a - b * b + ca;
                    float bb = 2 * a * b + cb;

                    a = aa;
                    b = bb;

                    if (Mathf.Sqrt(a * a + b * b) > 4)
                    {
                        break;
                    }

                    n++;
                }
                if (n == iterations)
                {
                    texture.SetPixel(i, j, Color.black);
                }
                else
                {
                    texture.SetPixel(i, j, Color.HSVToRGB(n / 100f, 1, 1));
                }

            }
        }

        texture.Apply();
    }
}
