using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class pointShop : MonoBehaviour
{
    public static int points = 0;
    public TMP_Text currentPoints;

    public ShopItem[] shopItems;

    public static pointShop Instance;

    public boosterAbilties BA;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        shopItems[0].button.onClick.AddListener(BA.Healing);
        shopItems[1].button.onClick.AddListener(BA.KillRandom);
        shopItems[2].button.onClick.AddListener(BA.Slowmotion);
        shopItems[3].button.onClick.AddListener(BA.TellTheTruth);

        foreach (var item in shopItems)
        {
            item.button.interactable = false;
        }

        updatePoints();
    }

    public static void pointController(int changepoints)
    {
        points += changepoints;
        Instance.updatePoints();
        Instance.updateBoosterButtons();
        Debug.Log("Current: " + points);
    }

    public void updatePoints()
    {
        if (currentPoints != null)
        {
            currentPoints.text = "Points: " + points;
        }
    }

    public void updateBoosterButtons()
    {
        foreach (var item in shopItems)
        {
            item.button.interactable = points >= item.cost;
        }
    }

    [System.Serializable]
    public class ShopItem
    {
        public Button button;
        public int cost;
    }
}
