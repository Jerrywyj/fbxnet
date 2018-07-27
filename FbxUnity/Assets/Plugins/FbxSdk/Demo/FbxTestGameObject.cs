using FbxNet;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.GLEx;

public class FbxTestGameObject : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        //FbxInterface.Load(@"..\测试\测试-5\CZ-5.FBX", @"..\测试\测试-5\Materials\", true);
        //FbxInterface.Load(@"..\测试\ces.FBX");
        FbxInterface.Load(@"..\测试\Q.FBX");
    }



}
