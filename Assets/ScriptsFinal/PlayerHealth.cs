using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class PlayerHealth : MonoBehaviour
{
    // UI for Losing
    public GameObject lose;
    // Text for player health
    public TextMeshProUGUI hpText;

    // Player health
    [SerializeField]
    private int hp;

    // Start is called before the first frame update
    void Start()
    {
        hpText.text = "Hp: " + hp;
    }

    void OnTriggerEnter2D(Collider2D other) {
        hp -= 1;
        if (hp <= 0) {
            // Debug.Log("You died! :(");
            hpText.text = "Hp: 0";
            lose.SetActive(true);
            Time.timeScale = 0;
        } else {
            hpText.text = "Hp: " + hp;
        }
    }
}
