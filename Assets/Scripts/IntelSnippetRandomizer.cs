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
    [SerializeField] int maxAmountOfSnippets = 2;
    [SerializeField] int minAmountOfSnippets = 1;

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
            "This data seems to be owned and controlled by the US millitary.\n",
            "This intel was processed to... 'beat the bad guys'?\n",
            "'TOP SECRET INTEL, eyes off!'\n",
            "They stored this file since 1978.\n",
            "This paper contains a complaint lodged to Sergeant Chatt.\n",
            "*A qoute from a civilian.*\n",
            "AI prompt: How do I code secure communications - God save America!\n",
            "AI prompt: Give me a recipe for chocolate cupcakes - God save America!\n",
            "AI answer: Guns, burgers and FREEDOM!\n",
            "AI answer: Use ALL-AMERICAN CAKEMIX in cupcake cups!\n",
            "AI answer: Make sure NO enemies of the GREAT US of A can crack it!\n",
            "Generated with Eag.LE.\n",
            "AI version: 1.18.\n",
            "It seems they trained this AI on 02/20/2020.\n",
            "AI trained on 02/20/2021.\n",
            "This document violates... every part of GDPR.\n",
            "I've never seen this many violations of GDPR.\n",
            "List of recipes, including Major Tom's favorite cupcake recipe. A letter of his consent is included.\n",
            "[DATA EXPUNGED] *there is a mouse-shaped hole in this intel.*\n",
            "[DATA EXPUNGED]ney plus. Includes a note 'REDACT THIS IMMEDIATELY!'.\n",
            "George Washington was the first Commanding General of the US army.\n",
            "AI platform evaluation: An AI provided recipe, and seven different cooking blogs about the same food.\n",
            "AI answer: David Bowie IS currently alive, wish he was American!\n",
            "Unequivocal consent means it is NOT implied.\n",
            "Informed consent means the subject knows their rights.\n",
            "Specific consent is only for one particular assignment or purpose.\n",
            "Voluntary consent means there is NOT any disadvantages in declining to consent.\n"
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
        "This data is owned by US, the Bavarian government.\n",
        "This intel was processed to feed hungry kids.\n",
        "This document is free use.\n",
        "[DATA EXPUNGED] This data exceeded its period for legal storage.\n",
        "*A link to a website detailing data rights.*\n",
        "*An email adress, made for receiving data mis-use complaints.*\n",
        "AI answer: The colour of America is red, white and blue.\n",
        "AI answer: Hvor meget er California værd?\n",
        "AI answer: America is a land riddled with issues.\n",
        "AI prompt: How to establish secure communication networks?\n",
        "AI prompt: What are the best ways to cook steaks?\n",
        "Generated with Eak.LI.\n",
        "AI version: 1.19.\n",
        "AI version: 1.81.\n",
        "It seems they trained this AI on 20/02/2020.\n",
        "This intel is in perfect compliance with GDPR.\n",
        "GDPR rules have been followed.\n",
        "AI prompt: Based on past habits, what is Sergeant Chatt's favorite food?\n",
        "AI prompt: Major Tom has two children. Also - God Save America!\n",
        "A file, which contains a brand new sci-fi movie.\n",
        "A colour swatch of Barbie Pink.\n",
        "AI platform evaluation: An AI provided recipe.\n",
        "AI answer: David Bowie died in 2016, a true loss to England.\n",
        "A note with clearly AI-generated writing from 'Major Tom', excusing a soldier from training.\n",
        "Consent form from Sergeant Chatt dated to 1989.\n",
        "Unequivocal consent means the subject knows what their data is used for.\n",
        "Informed consent means the subject is educated.\n",
        "Specific consent means a specific person consented.\n",
        "Voluntary consent means subject is not threatened to consent.\n",
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
