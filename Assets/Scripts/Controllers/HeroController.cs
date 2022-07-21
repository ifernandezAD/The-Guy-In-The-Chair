using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class HeroController : MonoBehaviour
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


    void Start()
    {
        myRigid = transform.GetComponent<Rigidbody>();
        combat = GetComponent<CharacterCombat>();

        keywordActions.Add("tira", Tira);
        keywordActions.Add("tiratira", Tiratira);
        keywordActions.Add("atras", Atras);
        keywordActions.Add("para", Para);
        keywordActions.Add("dale", Dale);
        keywordActions.Add("derecha", Derecha);
        keywordActions.Add("izquierda", Izquierda);

        keywordRecognizer = new KeywordRecognizer(keywordActions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += OnKeywordsRecognized;
        keywordRecognizer.Start();
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

    private void OnKeywordsRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log("Keyword: " + args.text);
        keywordActions[args.text].Invoke();
    }

    private void Tira()
    {
        print("Tira");
        isWalking = true;
        isRunning = false;
        isBack = false;
    }

    private void Tiratira()
    {
        isRunning = true;
        isBack = false;
    }

    private void Atras()
    {
        isBack = true;
    }

    private void Para()
    {
        isWalking = false;
        isRunning = false;
        isBack = false;
    }

    private void Dale()
    {
        print("Dalee");
        //El heroe aumenta su cadencia y poder de ataque
    }

    private void Derecha()
    {
        print("Turn Right");
        StartCoroutine(RotateMe(Vector3.up * 90, 0.5f));
    }

    private void Izquierda()
    {
        print("Turn Left");
        StartCoroutine(RotateMe(Vector3.up * -90, 0.5f));
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
                print("Hay un tio");
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

}
