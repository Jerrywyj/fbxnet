#include"common.h"

FbxString StdStr2FbxStr(std::string str)
{
	FbxString retStr = "";
	char * newStr = NULL;
	FbxAnsiToUTF8(str.c_str(), newStr);// Fbx Sdk �ṩ���ַ�����ת��API
	if (NULL != newStr)
	{
		retStr = newStr;
		delete[] newStr; // Ҫ�ǵ��ͷ�
	}
	return retStr;
}

std::string FbxStr2StdStr(FbxString fbxStr)
{
	std::string retStr = "";
	char * newStr = NULL;
	FbxUTF8ToAnsi(fbxStr.Buffer(), newStr);
	if (NULL != newStr)
	{
		retStr = newStr;
		delete[] newStr;
	}
	return retStr;
}
