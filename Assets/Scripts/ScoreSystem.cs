using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public int stars = 1;

    // Star instance variables
    public float offset;
    public float positionX;
    public Transform initialPosition;
    public Vector3 starPosition;
    public GameObject starPrefab;

    public GameObject scorePopup;

    private void OnEnable()
    {
        HeroCharacterStats.pederastianStar += AddStar;
        BossCharacterStats.timeStar += AddStar;
        HeroController.initialSpeech += AddStar;
        HeroController.heroInsulted += SubtractStar;
        BossCharacterStats.showScore += ShowScore;
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
        Debug.Log("Score is showing");
        scorePopup.SetActive(true);
        for (int i = 0; i < stars; i++)
        {
            starPosition = new Vector3 (initialPosition.transform.position.x+offset*i, initialPosition.transform.position.y, initialPosition.transform.position.z);
            GameObject obj = Instantiate(starPrefab, starPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("ScoreCanvas").transform);           
        }
    }
}

