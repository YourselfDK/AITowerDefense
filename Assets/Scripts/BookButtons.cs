using System;
using UnityEngine;
using UnityEngine.UI;

public class BookController : MonoBehaviour
{
    public Button right;
    public Button left;
    public Image book;

    public Sprite[] pages;
    public GameObject[] pageText;

    int currentPage = 0;

    void Start()
    {
        // Set up button listeners
        right.onClick.AddListener(NextPage);
        left.onClick.AddListener(PreviousPage);

        UpdateBook();
    }

    void NextPage()
    {
        if (currentPage < pages.Length - 1)
        {
            currentPage++;
            UpdateBook();
        }
    }

    void PreviousPage()
    {
        if (currentPage > 0)
        {
            currentPage--;
            UpdateBook();
        }
    }

    void UpdateBook()
    {
        book.sprite = pages[currentPage];
        

        left.interactable = currentPage > 0;
        right.interactable = currentPage < pages.Length - 1;
    }
}
