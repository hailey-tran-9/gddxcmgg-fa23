using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class PlayerHealthAnim : MonoBehaviour
{
    // UI for Losing
    public GameObject lose;
    // Text for player health
    public TextMeshProUGUI hpText;

    // Player's animator
    private Animator animator;
    // Player's sprite renderer
    private SpriteRenderer spr;

    // Player health
    [SerializeField]
    private int hp;

    // Start is called before the first frame update
    void Start()
    {
        hpText.text = "Hp: " + hp;

        animator = gameObject.GetComponent<Animator>();
        spr = gameObject.GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        hp -= 1;
        animator.SetBool("Hurt", true);
        if (hp <= 0) {
            // Debug.Log("You died! :(");
            hpText.text = "Hp: 0";
            lose.SetActive(true);
            Time.timeScale = 0;
        } else {
            hpText.text = "Hp: " + hp;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        animator.SetBool("Hurt", false);
    }
}
