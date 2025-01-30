using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    private Rigidbody2D body;
    private SpriteRenderer spriteRenderer;
    public Sprite Score0;
    public Sprite Score1;
    public Sprite Score2;
    public Sprite Score3;
    public Sprite Score4;
    public Sprite Score5;
    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = Score0;
        if (spriteRenderer == null )
        {
            Debug.Log("no sprite found");
        }
    }

    public void ChangeScoreLeft()
    {
        if (spriteRenderer.sprite == Score0)
        {
            spriteRenderer.sprite = Score1;
        }
        else if (spriteRenderer.sprite == Score1)
        {
            spriteRenderer.sprite = Score2;
        }
        else if (spriteRenderer.sprite == Score2)
        {
            spriteRenderer.sprite = Score3;
        }
        else if (spriteRenderer.sprite == Score3)
        {
            spriteRenderer.sprite = Score4;
        }
        else
        {
            SceneManager.LoadScene("Red Win");
        }
    }

    public void ChangeScoreRight()
    {
        if (spriteRenderer.sprite == Score0)
        {
            spriteRenderer.sprite = Score1;
        }
        else if (spriteRenderer.sprite == Score1)
        {
            spriteRenderer.sprite = Score2;
        }
        else if (spriteRenderer.sprite == Score2)
        {
            spriteRenderer.sprite = Score3;
        }
        else if (spriteRenderer.sprite == Score3)
        {
            spriteRenderer.sprite = Score4;
        }
        else
        {
            SceneManager.LoadScene("Blue Win");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
