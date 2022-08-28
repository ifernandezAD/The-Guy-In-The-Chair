using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public int stars = 1;

    private void OnEnable()
    {
        HeroCharacterStats.pederastianStar += AddStar;
        BossCharacterStats.timeStar += AddStar;
        HeroController.initialSpeech += AddStar;
        HeroController.heroInsulted += SubtractStar;
    }

    void AddStar()
    {
        ++stars;
        print(stars);
    }

    void SubtractStar()
    {
        --stars;
        print(stars);
    }

    void ShowScore()
    {
        
    }
}

