#include "texture.h"
#include"common.h"
#include"gameobject.h"

Texture::Texture()
{
	mName = "";
	mTextureType = 0;
	mSwapUV = false;
	mRelativePath = "";
}

Texture::~Texture()
{

}

void Texture::CopyFromFbxTexture(const FbxTexture * const ptexture)
{
	mName = FbxStr2StdStr(ptexture->GetNameOnly());
	mTextureType = 0;
	mSwapUV = ptexture->GetSwapUV();
	mTranslation.mX = (float)ptexture->GetTranslationU();
	mTranslation.mY = (float)ptexture->GetTranslationV();
	mScale.mX = (float)ptexture->GetScaleU();
	mScale.mY = (float)ptexture->GetScaleV();
	mRotation.mX = (float)ptexture->GetRotationU();
	mRotation.mY = (float)ptexture->GetRotationV();
	mRotation.mZ = (float)ptexture->GetRotationW();
	
	if (ptexture->Is<FbxFileTexture>())
	{
		FbxFileTexture* fileTexture = (FbxFileTexture*)ptexture;
		FbxString fileName = fileTexture->GetRelativeFileName();
		mRelativePath = FbxStr2StdStr(fileName);
	}
	else if (ptexture->Is<FbxLayeredTexture>())
	{
		FbxLayeredTexture* fileTexture = (FbxLayeredTexture*)ptexture;
		throw;
	}
	else if (ptexture->Is<FbxProceduralTexture>())
	{
		FbxProceduralTexture* fileTexture = (FbxProceduralTexture*)ptexture;
		throw;
	}
}

void Texture::CopyToFbxTexture(FbxTexture* const ptexture)
{
	ptexture->SetSwapUV(mSwapUV);
	ptexture->SetTranslation(mTranslation.mX, mTranslation.mY);
	ptexture->SetScale(mScale.mX, mScale.mY);
	ptexture->SetRotation(mRotation.mX, mRotation.mY, mRotation.mZ);
	ptexture->SetTextureUse(FbxTexture::eStandard);
	ptexture->SetMappingType(FbxTexture::eUV);
	if (mTextureType == 0)
	{
		if (ptexture->Is<FbxFileTexture>())
		{
			FbxFileTexture* fileTexture = (FbxFileTexture*)ptexture;
			FbxString fileName = StdStr2FbxStr(mRelativePath);
			fileTexture->SetRelativeFileName(fileName);
			//char cfileName[256];
			//sprintf(cfileName, "%.*s\\%.*s", strlen("C:\\Users\\pengu\\Desktop"),"C:\\Users\\pengu\\Desktop", strlen(mRelativePath.c_str()), mRelativePath);
			//std::string strFileName = "C:\\Users\\pengu\\Desktop\\" + mRelativePath;
			//fileTexture->SetFileName(StdStr2FbxStr(strFileName));

			fileTexture->SetMaterialUse(FbxFileTexture::eModelMaterial);
		}
		else
		{
			// wrong
			throw;
		}
	}
	else
	{
		// not surrport
		throw;
	}
}

FbxTexture* Texture::GetFbxTexture(FbxScene* const pscene)
{
	FbxFileTexture* lTexture = FbxFileTexture::Create(pscene, StdStr2FbxStr(mName));
	CopyToFbxTexture(lTexture);
	return lTexture;
}

void Texture::CopyFromTextureData(const TextureData * const pdata)
{
	mName = pdata->mName;
	//char buffer[1024];
	//memset(buffer, 0, sizeof(buffer));
	//strcpy(buffer, pdata->mName);
	//mName = UTF82Std(pdata->mName, pdata->mNameLength);
	//char buffer[1024];
	//memset(buffer, 0, 1024);
	//memcpy(buffer, pdata->mName, pdata->mNameLength);
	//mName = buffer;
	mTextureType = pdata->mTextureType;
	mSwapUV = pdata->mSwapUV;
	mTranslation.CopyFromVector2Data(&pdata->mTranslation);
	mScale.CopyFromVector2Data(&pdata->mScale);
	mRotation.CopyFromVector3Data(&pdata->mRotation);
	//memset(buffer, 0, 1024);
	//memcpy(buffer, pdata->mRelativePath, pdata->mRelativePathLength);
	//mRelativePath = buffer;
	//memset(buffer, 0, sizeof(buffer));
	//strcpy(buffer, pdata->mRelativePath);
	//mRelativePath = buffer;
	//mRelativePath = UTF82Std(pdata->mRelativePath, pdata->mRelativePathLength);
	mRelativePath = pdata->mRelativePath;
}

void Texture::CopyToTextureData(TextureData * const pdata)
{
	pdata->mNameLength = mName.length();
	//memset(pdata->mName, 0, sizeof(pdata->mName));
	strcpy(pdata->mName, mName.c_str());
	//size_t nameCapcity = sizeof(pdata->mName);
	//pdata->mNameLength = Std2UTF8(mName, pdata->mName, nameCapcity);

	pdata->mTextureType = pdata->mTextureType;
	pdata->mSwapUV = pdata->mSwapUV;
	mTranslation.CopyFromVector2Data(&pdata->mTranslation);
	mScale.CopyFromVector2Data(&pdata->mScale);
	mRotation.CopyFromVector3Data(&pdata->mRotation);
	pdata->mRelativePathLength = mRelativePath.length();
	memset(pdata->mRelativePath, 0, sizeof(pdata->mRelativePath));
	strcpy(pdata->mRelativePath, mRelativePath.c_str());
	//size_t pathCapcity = sizeof(pdata->mRelativePath);
	//pdata->mRelativePathLength = Std2UTF8(mRelativePath, pdata->mRelativePath, pathCapcity);
}

TextureData Texture::GetTextureData()
{
	TextureData data;
	CopyToTextureData(&data);
	return data;
}
