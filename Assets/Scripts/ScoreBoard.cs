using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{

    public GameObject scoretext;
    public static float score = 0;
    // Start is called before the first frame update
     public void setscore(float scoretoadd)
    {
        score += scoretoadd;
     //   scoretext.GetComponent<ListeScore>().text = score.ToString("F0");  
    }

    private void Start()
     {
            setscore(0);
     }


    // Update is called once per frame
    void Update()
    {
        
    }

}




