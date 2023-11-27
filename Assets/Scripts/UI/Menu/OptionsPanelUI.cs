using System;
using Gameplay.Managers;
using TMPro;
using UnityEngine;

public class OptionsPanelUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField gameTimeInput;
    [SerializeField] private TMP_InputField spawnTimeInput;

    public void UpdateGameRules()
    {
        try
        {
            if (!gameTimeInput.text.Equals("") && !spawnTimeInput.text.Equals(""))
            {
                GameController.instance.SetGameRules(float.Parse(spawnTimeInput.text), float.Parse(gameTimeInput.text));
            }

            gameObject.transform.parent.gameObject.SetActive(false);
        }
        catch (Exception e)
        {
            // Ignore;
        }
    }
}
