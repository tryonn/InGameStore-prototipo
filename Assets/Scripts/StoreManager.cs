﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StoreManager : MonoBehaviour {

    public static StoreManager instance;

    public GameObject cardPanelPrefab;
    public GameObject scrollArea;
    public Text coinCountText;
    public GameObject notEnoughCoinsPanel;
    public GameObject equippedPanel;

    [HideInInspector]
    public bool justBoughtCannon;

    private int temporaryCoinCount;

    public float decrementTimeConstant = 1f;
    public float timeBetweenDecrement;



    private const string WOOD_CANNON = "Wood Cannon";
    private const string BRONZE_CANNON = "Bronze Cannon";
    private const string SILVER_CANNON = "Silver Cannon";
    private const string ALUMINUN_CANNON = "Aluminun Cannon";
    private const string FLAME_CANNON = "Flame Cannon";
    private const string RAIBOW_CANNON = "Raibow Cannon";
    private const string CAMOFLAUGE_CANNON = "Camoflauge Cannon";
    private const string CARBONFIBER_CANNON = "Carbonfiber Cannon";
    private const string GOLD_CANNON = "Gold Cannon";
    private const string DIAMOND_CANNON = "Diamond Cannon";


    public void GotoMainMenu()
    {
        SceneFade.instance.FadeIn("Main Menu");
    }

    private void Awake()
    {
        MakeInstance();
        MakeCardPanel();
        AddScrollAbilities();

        justBoughtCannon = false;
        temporaryCoinCount = GameManager.CoinCount;
    }

    private void Update()
    {
        if (!justBoughtCannon)
        {
            temporaryCoinCount = GameManager.CoinCount;
        }
        
        coinCountText.text = temporaryCoinCount.ToString();

        if (temporaryCoinCount > GameManager.CoinCount)
        {
            if (!IsInvoking("DecrementCoins"))
            {
                InvokeRepeating("DecrementCoins", 0f, timeBetweenDecrement);
            }
        }
    }

    void DecrementCoins()
    {
        temporaryCoinCount--;

        if (temporaryCoinCount <= GameManager.CoinCount)
        {
            CancelInvoke();
            justBoughtCannon = false;
        }
    }

    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }


    void AddScrollAbilities()
    {
        scrollArea.AddComponent<ScrollRect>();
        scrollArea.GetComponent<ScrollRect>().vertical = false;
        scrollArea.GetComponent<ScrollRect>().movementType = ScrollRect.MovementType.Elastic;

        RectTransform scrollTransform = GameObject.Find("Card Holder").GetComponent<RectTransform>();
        float scrollLength = 510 * GameManager.instance.GetComponent<CannonArray>().cannonPrefabs.Length;
        scrollTransform.sizeDelta = new Vector2(scrollLength, 0);
        scrollArea.GetComponent<ScrollRect>().content = scrollTransform;
        scrollTransform.localPosition = new Vector3(594f, 20f, 0);
    }

    private void MakeCardPanel()
    {
        for (int i = 0; i < GameManager.instance.GetComponent<CannonArray>().cannonPrefabs.Length; i++)
        {
            GameObject card = Instantiate(cardPanelPrefab);

            card.gameObject.name = GameManager.instance.GetComponent<CannonArray>().cannonPrefabs[i].gameObject.name + " Panel";

            card.transform.SetParent(GameObject.Find("Card Holder").transform);

            card.transform.localScale = new Vector3(.85f, .85f, .85f);

            card.GetComponent<CardPanel>().cannonName.text = GameManager.instance.GetComponent<CannonArray>().cannonPrefabs[i].gameObject.name;

            card.GetComponent<CardPanel>().cannonImage.sprite = GameManager.instance.GetComponent<CannonArray>().cannonImages[i];

            card.GetComponent<CardPanel>().cannonImage.SetNativeSize();

            card.GetComponent<CardPanel>().cannonImage.rectTransform.localScale = new Vector3(.4f, .4f, .4f);

            card.GetComponent<CardPanel>().cannonPrice.text = GameManager.instance.GetComponent<CannonArray>().cannonPrefabs[i].GetComponent<Cannon>().cost.ToString();

            switch("" + GameManager.instance.GetComponent<CannonArray>().cannonPrefabs[i].gameObject.name)
            {
                case WOOD_CANNON:
                    card.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Use";
                    break;

                case BRONZE_CANNON:
                    if (GameManager.BRONZECANNONCHECK == 0)
                        card.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Buy";
                    else 
                        card.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Use";
                    break;

                case SILVER_CANNON:
                    if (GameManager.SILVERCANNONCHECK == 0)
                        card.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Buy";
                    else
                        card.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Use";
                    break;

                case ALUMINUN_CANNON:
                    if (GameManager.ALUMINUNCANNONCHECK == 0)
                        card.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Buy";
                    else
                        card.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Use";
                    break;

                case FLAME_CANNON:
                    if (GameManager.FLAMECANNONCHECK == 0)
                        card.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Buy";
                    else
                        card.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Use";
                    break;

                case RAIBOW_CANNON:
                    if (GameManager.RAIBOWCANNONCHECK == 0)
                        card.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Buy";
                    else
                        card.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Use";
                    break;

                case CAMOFLAUGE_CANNON:
                    if (GameManager.CAMOFLAUGECANNONCHECK == 0)
                        card.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Buy";
                    else
                        card.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Use";
                    break;

                case CARBONFIBER_CANNON:
                    if (GameManager.CARBONFIBERCANNONCHECK == 0)
                        card.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Buy";
                    else
                        card.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Use";
                    break;

                case GOLD_CANNON:
                    if (GameManager.GOLDCANNONCHECK == 0)
                        card.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Buy";
                    else
                        card.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Use";
                    break;

                case DIAMOND_CANNON:
                    if (GameManager.DIAMONDCANNONCHECK == 0)
                        card.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Buy";
                    else
                        card.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Use";
                    break;
            }
        }
    }

    public void CloseNotEnoughCoinsPanel()
    {
        StoreManager.instance.notEnoughCoinsPanel.gameObject.SetActive(false);
    }

    public void EquippedNewCannon(string cannonName, Sprite cannonImage)
    {

        Debug.Log(cannonName);
        Debug.Log(cannonImage);

        equippedPanel.GetComponentInChildren<Text>().text = cannonName;
        GameObject g = GameObject.Find("cannon image");



        Debug.Log(g.transform.parent.name);


        if (g.transform.parent.name == "EquippedPanel")
        {
            GameObject.Find("cannon image").GetComponent<Image>().sprite = cannonImage;
        }

        StartCoroutine(EquippedNewCannonPanelAnimationWait());
    }

    // chama a animação do painel que equipa o cannon
    IEnumerator EquippedNewCannonPanelAnimationWait()
    {
        equippedPanel.GetComponent<Animator>().Play("EquippedPanelIn");
        yield return new WaitForSeconds(1.5f);
        equippedPanel.GetComponent<Animator>().Play("EquippedPanelOut");
    }
}
