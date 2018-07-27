#include"common.h"
//#include<iconv.h>

FbxString StdStr2FbxStr(std::string str)
{
	FbxString retStr = "";
	char * newStr = NULL;
	FbxAnsiToUTF8(str.c_str(), newStr);// Fbx Sdk 提供的字符编码转换API
	if (NULL != newStr)
	{
		retStr = newStr;
		delete[] newStr; // 要记得释放
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

//int Std2UTF8(std::string str, char*  buffer, size_t& bufferlength)
//{
//	size_t length = bufferlength;
//	const char* inbuffer = str.c_str();
//	size_t inlength = str.length();
//
//	iconv_t convert = iconv_open("utf-8", "GBK");
//	iconv(convert, &inbuffer, &inlength, &buffer, &bufferlength);
//
//	return length - bufferlength;
//}
//
//std::string UTF82Std(const char* buffer, size_t length)
//{
//	char inbuf[1024];
//	size_t inlen = 1024;
//	memset(inbuf, 0, sizeof(inbuf));
//	
//	char* pinbuffer = inbuf;
//	iconv_t convert = iconv_open("GBK", "utf-8");
//	iconv(convert, &buffer, &length, &pinbuffer, &inlen);
//
//	std::string str = pinbuffer;
//
//	return str;
//}
