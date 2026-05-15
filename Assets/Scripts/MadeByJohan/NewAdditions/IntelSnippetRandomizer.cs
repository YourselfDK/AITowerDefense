using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI.Table;

public class IntelSnippetRandomizer : MonoBehaviour
{
    public RandomSnippetDataStorage SnippetStorage;
    public TMP_Text myTextField;
    public bool trueInformation = true;
    [SerializeField] int maxAmountOfSnippets = 2;
    [SerializeField] int minAmountOfSnippets = 1;
    private HashSet<int> pickedIndices;

    private void Start()
    {
        if (SnippetStorage == null)
        {
            Debug.LogError("IntelData ScriptableObject reference is not set on " + gameObject.name);
            return; // Early exit to avoid null reference issues
        }
        pickedIndices = new HashSet<int>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        //This needs to pick a random number between 1-3 (max = level reached or something)
        //Then it needs to pick a number of random rules = random number.
        //Then it needs to pick 1 random snippet from each rule chosen.
        //This code should be attached to a prefab that can reference a TMPro textbox attached to itself.
        //Possibly place the strings in a scriptable object.

        bool EvilInfo = UnityEngine.Random.Range(0, 2) == 1;
        if (EvilInfo)
        {
        trueInformation = false;
        }
        else
        {
        trueInformation = true;
        }
        int amountOfSnippets = UnityEngine.Random.Range(minAmountOfSnippets, maxAmountOfSnippets+1);
        print("Amount of snippets = " + amountOfSnippets);
        if(trueInformation == true)
        {
            PickRandomFromTrueList(amountOfSnippets); //Also gives error
        }
        if(trueInformation == false)
        {
            PickRandomFromFalseList(amountOfSnippets); //Also gives error
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickRandomFromTrueList(int trueSnippets)
    {
        for (int x = 0; x < trueSnippets; x++)
        {
            List<int> availableIndices = new List<int>();

            // Get the strings that have not been picked yet.
            for (int i = 0; i < SnippetStorage.mainTextTrue.Count; i++)
            {
                if (!pickedIndices.Contains(i))  //This line gives a missing reference error
                {
                    availableIndices.Add(i);
                }
            }

            if (availableIndices.Count == 0)
            {
                Debug.LogWarning("No more texts available to pick for the enemy");
                break;
            }

            // Pick a random index from available indices
            int randomPickIndex = UnityEngine.Random.Range(0, availableIndices.Count);
            int actualIndex = availableIndices[randomPickIndex];

            // Mark this index as picked for this specific enemy
            pickedIndices.Add(actualIndex);

            // Add the chosen text to the text field
            myTextField.text += SnippetStorage.mainTextTrue[actualIndex] + "\n"; // Add a newline for readability
        }
    }

    public void PickRandomFromFalseList(int snippets)
    {
        int falseSnippets = UnityEngine.Random.Range(1, snippets + 1);
        print("False snippets = " + falseSnippets);


        for (int x = 0; x < snippets; x++)
        {
            List<int> availableIndices = new List<int>();

            // Get the strings that have not been picked yet.
            for (int i = 0; i < SnippetStorage.mainTextFalse.Count; i++)
            {
                if (!pickedIndices.Contains(i))  //This line gives a missing reference error
                {
                    availableIndices.Add(i);
                }
            }

            if (availableIndices.Count == 0)
            {
                Debug.LogWarning("No more texts available to pick for the enemy");
                break;
            }

            // Pick a random index from available indices
            int randomPickIndex = UnityEngine.Random.Range(0, availableIndices.Count);
            int actualIndex = availableIndices[randomPickIndex];

            // Mark this index as picked for this specific enemy
            pickedIndices.Add(actualIndex);

            // Add the chosen text to the text field
            myTextField.text += SnippetStorage.mainTextFalse[actualIndex] + "\n"; // Add a newline for readability

            // I believe this will always add the False snippets first?
            PickRandomFromTrueList(snippets - falseSnippets);
        }
    }

}
