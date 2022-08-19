using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public int stars = 0;

    private void OnEnable()
    {
        HeroCharacterStats.pederastianStar += AddStar;
    }


    void Update()
    {
        
    }

    void AddStar()
    {
        ++stars;
        print(stars);
    }
}
