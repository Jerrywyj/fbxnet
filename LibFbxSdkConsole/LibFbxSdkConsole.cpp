// LibFbxSdkConsole.cpp: 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include <fbxsdk.h>
#include <string>
#include"common.h"
#include"gameobject.h"
//#include<iconv.h>

int main()
{

	std::string fileName = "C:\\Users\\pengu\\Desktop\\CZ-5\\CZ-5.FBX";

	GameObject gameobject;
	gameobject.Load(fileName);
	gameobject.Save("C:\\Users\\pengu\\Desktop\\bbb.FBX");

	system("pause");

}

 