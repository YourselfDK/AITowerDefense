using System;
using UnityEngine;
using UnityEngine.UI;

public class BookController : MonoBehaviour
{
    public Button right;
    public Button left;
    public Image book;
    public GameObject myCanvas;

    public Sprite[] pages;
    public GameObject[] pageText;

    int currentPage = 0;
    public AudioSource audioSource;
    public AudioClip pageTurnClip;

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
            audioSource.PlayOneShot(pageTurnClip);
            UpdateBook();
        }
    }

    void PreviousPage()
    {
        if (currentPage > 0)
        {
            currentPage--;
            audioSource.PlayOneShot(pageTurnClip);
            UpdateBook();
        } else
        {
            myCanvas.SetActive(false);
            audioSource.PlayOneShot(pageTurnClip);
        }
    }

    void UpdateBook()
    {
        book.sprite = pages[currentPage];
        
              for (int i = 0; i < pageText.Length; i++)
        {
            pageText[i].SetActive(i == currentPage);
        }

        left.interactable = currentPage >= 0;
        right.interactable = currentPage < pages.Length - 1;
    }
}
