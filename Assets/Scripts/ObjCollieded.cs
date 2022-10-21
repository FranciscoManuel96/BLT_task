using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ObjCollieded : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nmbobjcollText;
    [SerializeField] private Score score;
    [SerializeField] private DataManager dataManager;
    public int numberObjColl;
    

    void Start()
    {
        //Reset at start to make sure it's 0
        ResetNmbObj();
    }

    void Update()
    {
        nmbobjcollText.text = numberObjColl.ToString();
    }

    //Resets number of objs collided
    public void ResetNmbObj()
    {
        numberObjColl = 0;
    }

    //Increases number of obj collided
    public void IncreaseObjColl()
    {
        numberObjColl += 1;
    }
}
