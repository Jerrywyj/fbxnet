#pragma once

#include <fbxsdk.h>
#include<string>



FbxString StdStr2FbxStr(std::string str);
std::string FbxStr2StdStr(FbxString fbxStr);

//int Std2UTF8(std::string str, char*  buffer, size_t& bufferlength);
//std::string UTF82Std(const char* buffer, size_t length);