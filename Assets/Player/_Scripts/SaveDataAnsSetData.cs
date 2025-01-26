using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDataAnsSetData : MonoBehaviour
{
    private void Start()
    {
        SetDefaults();
    }
    public void SetDefaults()
    {
        PlayerPrefs.SetFloat("ProjectileSpeed", 22f);
        PlayerPrefs.SetFloat("ProjectileattacksDelay", 0.2f);
        PlayerPrefs.SetInt("ProjectileDamage", 1);

        PlayerPrefs.SetInt("MaxHealth", 8);
        PlayerPrefs.SetInt("CurHealth", 7);

        PlayerPrefs.SetInt("NrOfJumps", 1);
        PlayerPrefs.SetFloat("Speed", 14);

        PlayerPrefs.SetInt("CurrentScore", 1);

        PlayerPrefs.SetInt("HealingMultiplyer", 1);

        PlayerPrefs.SetInt("ScoreMultiplyer", 1);
    }

}
