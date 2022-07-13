using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.Windows.Speech;




public class HeroController : MonoBehaviour
{
    //Movement variables
    [SerializeField]
    float speed;
    private Rigidbody myRigid;
    private Vector3 inputVector;
    public bool isWalking = false;

    //Voice Recognition Variables
    private Dictionary<string, Action> keywordActions = new Dictionary<string, Action>();
    private KeywordRecognizer keywordRecognizer;


    void Start()
    {
        myRigid = transform.GetComponent<Rigidbody>();

        keywordActions.Add("tira", Tira);
        keywordActions.Add("tiratira", Tiratira);
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
        if (isWalking)
        {
            inputVector = this.transform.rotation* Vector3.forward * speed;
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
    }

    private void Tiratira()
    {
        print("Tira mas rápido");

    }

    private void Para()
    {
        print("Para");
        isWalking = false;
    }

    private void Dale()
    {
        print("Dalee");
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
}
