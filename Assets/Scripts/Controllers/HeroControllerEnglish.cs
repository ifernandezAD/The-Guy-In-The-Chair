using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class HeroControllerEnglish : MonoBehaviour
{
    //Movement variables
    [SerializeField]
    float speed;
    private Rigidbody myRigid;
    private Vector3 inputVector;
    public bool isWalking = false;
    public bool isRunning;
    public bool isBack;


    //Voice Recognition Variables
    private Dictionary<string, Action> keywordActions = new Dictionary<string, Action>();
    private KeywordRecognizer keywordRecognizer;

    //EnemyDetection and Attack Variables
    public int lookRadius;
    CharacterCombat combat;
    public bool bossFight = false;

    public static event Action weakPoint;

    //Initial Speech
    public static event Action initialSpeech;
    public bool isProfessional = false;

    //Are you polite?
    public static event Action heroInsulted;
    public bool isOffensive = false;

    void Start()
    {
        myRigid = transform.GetComponent<Rigidbody>();
        combat = GetComponent<CharacterCombat>();

        keywordActions.Add("go", Go);
        keywordActions.Add("run", Run);
        keywordActions.Add("back", Back);
        keywordActions.Add("stop", Stop);
        keywordActions.Add("head", Head);
        keywordActions.Add("right", Right);
        keywordActions.Add("littleright", SlightlyRight);
        keywordActions.Add("left", Left);
        keywordActions.Add("littleleft", SlightlyLeft);
        keywordActions.Add("hello", Hello);
        keywordActions.Add("thankyou", ThankYou);
        keywordActions.Add("asshole", Asshole);
        keywordActions.Add("fuckyou", FuckYou);
        keywordActions.Add("motherfucker", Motherfucker);

        keywordRecognizer = new KeywordRecognizer(keywordActions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += OnKeywordsRecognized;
        keywordRecognizer.Start();
    }

    private void OnEnable()
    {
        BossBattleTrigger.bossBattleBegins += BossBattleActive;
    }

    void Update()
    {
        CheckForEnemies();

        if (isWalking)
        {
            inputVector = this.transform.rotation * Vector3.forward * speed;

            if (isRunning)
            {
                inputVector = this.transform.rotation * Vector3.forward * speed * 2;
            }
            if (isBack)
            {
                inputVector = this.transform.rotation * -Vector3.forward * speed;
            }
        }
        else if (isRunning)
        {
            inputVector = this.transform.rotation * Vector3.forward * speed * 2;
            if (isBack)
            {
                inputVector = this.transform.rotation * -Vector3.forward * speed;
            }
        }
        else if (isBack)
        {
            inputVector = this.transform.rotation * -Vector3.forward * speed;
            if (isWalking)
            {
                inputVector = this.transform.rotation * Vector3.forward * speed;
            }
            if (isRunning)
            {
                inputVector = this.transform.rotation * Vector3.forward * speed * 2;
            }
        }
        else
        {
            inputVector = this.transform.rotation * Vector3.forward * 0;
        }
    }

    private void FixedUpdate()
    {
        myRigid.velocity = inputVector;
    }

    void CheckForEnemies()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, lookRadius);
        foreach (Collider c in colliders)
        {
            if (c.tag == "Enemy")
            {
                isWalking = false;
                isRunning = false;
                isBack = false;
                transform.LookAt(c.transform.position);
                CharacterStats targetStats = c.GetComponent<CharacterStats>();
                if (targetStats != null)
                {
                    combat.Attack(targetStats);
                }
            }
        }
    }

    IEnumerator RotateMe(Vector3 byAngles, float inTime)
    {
        var fromAngle = transform.rotation;
        var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
        for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        {
            transform.rotation = Quaternion.Lerp(fromAngle, toAngle, t);
            yield return null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    private void OnKeywordsRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log("Keyword: " + args.text);
        keywordActions[args.text].Invoke();
    }

    private void Go()
    {
        print("Tira");
        isWalking = true;
        isRunning = false;
        isBack = false;
    }

    private void Run()
    {
        isRunning = true;
        isBack = false;
    }

    private void Back()
    {
        isBack = true;
    }

    private void Stop()
    {
        isWalking = false;
        isRunning = false;
        isBack = false;
    }

    private void Right()
    {
        print("Turn Right");
        StartCoroutine(RotateMe(Vector3.up * 90, 0.5f));
    }

    private void SlightlyRight()
    {
        print("Turn Right a little");
        StartCoroutine(RotateMe(Vector3.up * 30, 0.5f));
    }

    private void Left()
    {
        print("Turn Left");
        StartCoroutine(RotateMe(Vector3.up * -90, 0.5f));
    }

    private void SlightlyLeft()
    {
        print("Turn Left a little");
        StartCoroutine(RotateMe(Vector3.up * -30, 0.5f));
    }

    private void Head()
    {
        if (bossFight)
        {
            //Comando para atacar el punto d�bil del Boss
            print("Le has jodido donde mas duele");
            weakPoint?.Invoke();
        }
    }

    private void Hello()
    {
        if (isProfessional == false)
        {
            initialSpeech?.Invoke();
            isProfessional = true;
        }
    }

    private void ThankYou()
    {
        if (isProfessional == false)
        {
            initialSpeech?.Invoke();
            isProfessional = true;
        }
    }

    private void Asshole()
    {
        Debug.Log("Tu padre");
        if (isOffensive == false)
        {
            heroInsulted.Invoke();
            isOffensive = true;
        }
    }

    private void FuckYou()
    {
        Debug.Log("Tu padre");
        if (isOffensive == false)
        {
            heroInsulted.Invoke();
            isOffensive = true;
        }
    }

    private void Motherfucker()
    {
        Debug.Log("Tu padre");
        if (isOffensive == false)
        {
            heroInsulted.Invoke();
            isOffensive = true;
        }
    }

    private void BossBattleActive()
    {
        bossFight = true;
    }
}