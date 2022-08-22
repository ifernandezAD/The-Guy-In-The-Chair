using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public int stars = 0;

    private void OnEnable()
    {
        HeroCharacterStats.pederastianStar += AddStar;
        BossCharacterStats.timeStar += AddStar;
        HeroController.initialSpeech += AddStar;

        void AddStar()
        {
            ++stars;
            print(stars);
        }

    }
}

