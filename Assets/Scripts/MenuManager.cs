using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    // ссылка на текстовую строку
    public GameObject text;
    public GameObject earth;
    public GameObject btn;

    void Start()
    {
        btn = GameObject.Find("Quad");
        text = GameObject.Find("Quad1");
        btn.SetActive(false);
        text.SetActive(false);
    }

    // метод, который отображает/скрывает текстовую строку
    public void ToggleInput()
    {
        text.SetActive(!text.activeSelf);
        GameObject.FindGameObjectsWithTag("GeographyObject");
    }
}
