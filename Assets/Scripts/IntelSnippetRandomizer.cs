using System;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI.Table;
using TMPro;

public class IntelSnippetRandomizer : MonoBehaviour
{

    public TMP_Text myTextField;
    [SerializeField] bool trueInformation = true;
    [SerializeField] int maxAmountOfSnippets = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        //This needs to pick a random number between 1-3 (max = level reached or something)
        //Then it needs to pick a number of random rules = random number.
        //Then it needs to pick 1 random snippet from each rule chosen.
        //This code should be attached to a prefab that can reference a TMPro textbox attached to itself.
        //Possibly place the strings in a scriptable object.
        int amountOfSnippets = UnityEngine.Random.Range(1, maxAmountOfSnippets+1);
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
        string[] mainTextTrue = new string[]
        {
            "Harry ",
            "Ron ",
            "Hermione "
        };
        for (int x = 0; x < trueSnippets; x++)
        {
            string randomTrueIntel = mainTextTrue[UnityEngine.Random.Range(0, mainTextTrue.Length)];
            myTextField.text = myTextField.text + randomTrueIntel;
        }
    }

    public void PickRandomFromFalseList(int snippets)
    {
        string[] mainTextFalse = new string[]
        {
            "HarryFalse ",
            "RonFalse ",
            "HermioneFalse "
        };
        int falseSnippets = UnityEngine.Random.Range(1, snippets+1);
        for (int x = 0; x < falseSnippets; x++)
        {
            string randomFalseIntel = mainTextFalse[UnityEngine.Random.Range(0, mainTextFalse.Length)];
            myTextField.text = myTextField.text + randomFalseIntel;
        }
        PickRandomFromTrueList(snippets-falseSnippets);
    }


}
