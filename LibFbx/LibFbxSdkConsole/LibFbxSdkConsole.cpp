// LibFbxSdkConsole.cpp: 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include <fbxsdk.h>
#include <string>
#include "Common.h"
#include"gameobject.h"

int main()
{
	std::string fileName = "C:\\Users\\pengu\\Desktop\\aaa.FBX";

	GameObject gameobject;
	gameobject.Load(fileName);
	//GameObject::gPath = "C:\\Users\\pengu\\Desktop";
	gameobject.Save("C:\\Users\\pengu\\Desktop\\bbb.FBX");

	system("pause");

}

 