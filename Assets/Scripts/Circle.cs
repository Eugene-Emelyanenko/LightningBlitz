using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Circle : MonoBehaviour
{
    [SerializeField] private Sprite locked;
    [SerializeField] private Sprite unlocked;
    [SerializeField] private GameObject numberText;
    [SerializeField] private SpriteRenderer circleIcon;
    [SerializeField] private Sprite coinIcon;

    public bool isCoin = false;
    
    private int number;

    private void Awake()
    {
        number = Random.Range(1, 99);
        numberText.GetComponent<TextMeshPro>().text = number.ToString();
        numberText.SetActive(false);
    }

    void Start()
    {
        circleIcon.transform.rotation = Quaternion.Euler(0, 0,  Random.Range(0f, 360f));
        SetIcon(true);
    }

    private void OnMouseDown()
    {
        SetIcon(false);
        
        if(isCoin)
            return;
        numberText.SetActive(true);
    }

    private void SetIcon(bool isLocked)
    {
        if (isCoin)
            circleIcon.sprite = isLocked ? locked : coinIcon;
        else
            circleIcon.sprite = isLocked ? locked : unlocked;
    }

    public int GetNumber() => number;

    public void SetCoin()
    {
        isCoin = true;
        number = 0;
    }
}
