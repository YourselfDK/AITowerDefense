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

    public TMP_Text myTextField;
    public bool trueInformation = true;
        [SerializeField] int maxAmountOfSnippets = 5;

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
        int amountOfSnippets = UnityEngine.Random.Range(1, maxAmountOfSnippets+1);
        print("Amount of snippets = " + amountOfSnippets);
        if(trueInformation == true)
        {
            PickRandomFromTrueList(amountOfSnippets);
        }
        if(trueInformation == false)
        {
            PickRandomFromFalseList(amountOfSnippets);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickRandomFromTrueList(int trueSnippets)
    {
        List<string> mainTextTrue = new List<string>
        {
            "Harry ",
            "Ron ",
            "Hermione "
        };
        for (int x = 0; x < trueSnippets; x++)
        {
            if (mainTextTrue.Count == 0)
                break; // Avoid errors if we run out of options
            int randomIndex = UnityEngine.Random.Range(0, mainTextTrue.Count);
            string randomTrueIntel = mainTextTrue[randomIndex];
            myTextField.text += randomTrueIntel;
            // Remove the chosen element so it can't be picked again
            mainTextTrue.RemoveAt(randomIndex);
        }
    }

    public void PickRandomFromFalseList(int snippets)
    {
        // Use a List<string> instead of string[]
        List<string> mainTextFalse = new List<string>
    {
        "HarryFalse ",
        "RonFalse ",
        "HermioneFalse ",
    };
        int falseSnippets = UnityEngine.Random.Range(1, snippets + 1);
        print("False snippets = " + falseSnippets);
        for (int x = 0; x < falseSnippets; x++)
        {
            if (mainTextFalse.Count == 0)
                break; // Avoid errors if we run out of options
            int randomIndex = UnityEngine.Random.Range(0, mainTextFalse.Count);
            string randomFalseIntel = mainTextFalse[randomIndex];
            myTextField.text += randomFalseIntel;
            // Remove the chosen element so it can't be picked again
            mainTextFalse.RemoveAt(randomIndex);
        }
        PickRandomFromTrueList(snippets - falseSnippets);
    }


}
