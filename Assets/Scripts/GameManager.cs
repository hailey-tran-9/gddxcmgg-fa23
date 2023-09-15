using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Enemies gameObject
    public GameObject enemies;
    // UI for winning
    public GameObject win;

    // Update is called once per frame
    void Update()
    {
        if (enemies.transform.childCount == 0) {
            win.SetActive(true);
        }
    }
}
