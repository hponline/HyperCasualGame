using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager ShopManagerInstance;
    [Header("SkyBox Settings")]
    public int marketCoins;
    public TMP_Text coinUI;
    public ShopItemSO[] shopItemsSO;
    public GameObject[] shopPanelsGameObject;
    public GameObject[] applyBtn;
    public ShopTemplate[] shopPanels;
    public GameObject[] buyItems;
    public Material[] skyBox;

    bool[] isPurchased;

    [Header("Characters Settings")]
    public CharacterItemSO[] characterItemSO;
    public GameObject[] characterPanelGameObject;
    public GameObject[] characterApplyBtn;
    public CharacterTemplate[] characterTemplatePanels;
    public GameObject[] CharacterbuyItems;
    public Sprite[] characterSprite;
    bool[] CharacterisPurchased;


    private void Start()
    {
        marketCoins += PlayerPrefs.GetInt("PlayerCoins", 0);
        coinUI.text = "Coin: " + marketCoins.ToString();


        ShowItems();
        LoadPanels();
        CheckBuyItems();
        CheckBuyCharactersItems();
        CharacterLoadPanels();
    }

    public void ShowItems()
    {
        // Ürün sayýsý kadar gösterir geri kalanlarý gizler.

        // SkyBox
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            shopPanelsGameObject[i].SetActive(true);
        }

        // Karakter
        for (int i = 0; i < characterItemSO.Length; i++)
        {
            characterPanelGameObject[i].SetActive(true);
        }

        // ----------- Characters bölümü -----------
        CharacterisPurchased = new bool[characterItemSO.Length];

        for (int i = 0; i < CharacterisPurchased.Length; i++)
        {
            CharacterisPurchased[i] = PlayerPrefs.GetInt("BuyCharacterItem" + i, 0) == 1;
        }
        // CharacterBuyButton
        for (int i = 0; i < CharacterbuyItems.Length; i++)
        {
            int index = i;
            CharacterbuyItems[i].GetComponent<Button>().onClick.AddListener(() => PurchaseItemCharacters(index));
        }
        // CharacterApplyButton
        for (int i = 0; i < characterApplyBtn.Length; i++)
        {
            int index = i;
            //applyBtn[i].GetComponent<Button>().onClick.AddListener(() => ApplyItem(index));
        }

        // ----------- SkyBox bölümü -----------
        isPurchased = new bool[shopItemsSO.Length];

        for (int i = 0; i < isPurchased.Length; i++)
        {
            isPurchased[i] = PlayerPrefs.GetInt("BuyItem" + i, 0) == 1;
        }
        // SkyboxBuyButton
        for (int i = 0; i < buyItems.Length; i++)
        {
            int index = i;
            buyItems[i].GetComponent<Button>().onClick.AddListener(() => PurchaseItem(index));
        }
        // SkyboxApplyButton
        for (int i = 0; i < applyBtn.Length; i++)
        {
            int index = i;
            applyBtn[i].GetComponent<Button>().onClick.AddListener(() => ApplyItem(index));
        }
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();        
    }

    public void ApplyItem(int index)
    {
        if (isPurchased[index])
        {            
            RenderSettings.skybox = skyBox[index];
            DynamicGI.UpdateEnvironment();

            PlayerPrefs.SetInt("SelectedSkybox", index);
            PlayerPrefs.Save();
        }
    }

    public void CheckBuyItems()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            if (isPurchased[i])
            {
                buyItems[i].SetActive(false);
                applyBtn[i].SetActive(true);
            }
            else if (marketCoins >= shopItemsSO[i].baseCost)
            {
                buyItems[i].SetActive(true);
                applyBtn[i].SetActive(false);
            }
        }
    }

    public void CheckBuyCharactersItems()
    {
        // Character
        for (int i = 0; i < characterItemSO.Length; i++)
        {
            if (CharacterisPurchased[i])
            {
                CharacterbuyItems[i].SetActive(false);
                characterApplyBtn[i].SetActive(true);
            }
            else if (marketCoins >= characterItemSO[i].baseCost)
            {
                CharacterbuyItems[i].SetActive(true);
                characterApplyBtn[i].SetActive(false);
            }
        }
    }

    public void PurchaseItem(int purchaseIndex)
    {
        if (!isPurchased[purchaseIndex] && marketCoins >= shopItemsSO[purchaseIndex].baseCost)
        {
            marketCoins -= shopItemsSO[purchaseIndex].baseCost;
            isPurchased[purchaseIndex] = true;

            // Satýn alma durumu
            PlayerPrefs.SetInt("PlayerCoins", marketCoins);
            PlayerPrefs.SetInt("BuyItem" + purchaseIndex, 1);

            // UI
            coinUI.text = "Coins: " + marketCoins.ToString();
            CheckBuyItems();
        }        
    }

    public void PurchaseItemCharacters(int purchaseIndex)
    {
        if (!CharacterisPurchased[purchaseIndex] && marketCoins >= characterItemSO[purchaseIndex].baseCost)
        {
            marketCoins -= characterItemSO[purchaseIndex].baseCost;
            CharacterisPurchased[purchaseIndex] = true;

            // Satýn alma durumu
            PlayerPrefs.SetInt("PlayerCoins", marketCoins);
            PlayerPrefs.SetInt("BuyCharacterItem" + purchaseIndex, 1);

            // UI
            coinUI.text = "Coins: " + marketCoins.ToString();
            CheckBuyCharactersItems();
        }
    }

    public void LoadPanels()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            shopPanels[i].titleText.text = shopItemsSO[i].itemTitle;
            shopPanels[i].skyBoxImage.sprite = shopItemsSO[i].SkyBoxImage;
            shopPanels[i].costText.text = "Coins: " + shopItemsSO[i].baseCost.ToString();
        }
    }
    public void CharacterLoadPanels()
    {
        for (int i = 0; i < characterItemSO.Length; i++)
        {
            characterTemplatePanels[i].titleText.text = characterItemSO[i].itemTitle;
            characterTemplatePanels[i].CharacterImage.sprite = characterItemSO[i].characterImage;
            characterTemplatePanels[i].costText.text = "Coins: " + characterItemSO[i].baseCost.ToString();
        }
    }
}
