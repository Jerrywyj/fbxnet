using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace FbxNet
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct Vector2Data
    {
        public float mX;
        public float mY;
    };

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct Vector3Data
    {
        public float mX;
        public float mY;
        public float mZ;
    };

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct Vector4Data
    {
        public float mX;
        public float mY;
        public float mZ;
        public float mW;
    };

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct ColorData
    {
        public float mRed;
        public float mGreen;
        public float mBlue;
        public float mAlpha;
    };

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct TextureData
    {
        public int mNameLength;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
        public byte[] mName;
        public int mTextureType;
        public bool mSwapUV;
        public Vector2Data mTranslation;
        public Vector2Data mScale;
        public Vector3Data mRotation;
        public int mRelativePathLength;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
        public byte[] mRelativePath;
    };

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct PolygonData
    {
        public int mMaterialID;
        public int mUVSetCount;
        public int mCount;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
        public ColorData[] pColors;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
        public Vector3Data[] pVertices;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
        public Vector3Data[] pNormals;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
        public Vector3Data[] pTangents;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
        public Vector2Data[] pUVS;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
        public Vector2Data[] pUVS2;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
        public Vector2Data[] pUVS3;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
        public Vector2Data[] pUVS4;
    };

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct TransformData
    {
        public Vector3Data mPosition;
        public Vector3Data mRotation;
        public Vector3Data mScale;
    };

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct MaterialData
    {
        public int mNameLength;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
        public byte[] mName;
        public int mShaderType;// 0 Phong， 1 Lambert
        public ColorData mAmbient;
        public float mAmbientFactor;
        public IntPtr pAmbientTexture;
        public ColorData mDiffuse;
        public float mDiffuseFactor;
        public IntPtr pDiffuseTexture;
        public ColorData mSpecular;
        public float mSpecularFactor;
        public IntPtr pSpecularTexture;
        public ColorData mEmissive;
        public IntPtr pEmissiveTexture;
        public float mEmissiveFactor;
        public ColorData mTransparentColor;
        public float mTransparencyFactor;
        public ColorData mReflection;
        public float mReflectionFactor;
        public IntPtr pReflectionTexture;
        public float mShininess;
        public ColorData mNormalMap;
        public IntPtr pNormalTexture;
        public ColorData mBump;
        public float mBumpFactor;
        public IntPtr pBumpTexture;
    };
    public static class FbxInterface
    {

        public static string GetGameObjectName(IntPtr pgameobject)
        {
            byte[] data = new byte[2048];
            int count = FbxInterface.GetGameObjectName(pgameobject, data);
            string name = System.Text.Encoding.GetEncoding("GBK").GetString(data, 0, count);
            return name;
        }

        public static IntPtr LoadGameObject(string path)
        {
            byte[] buffer = System.Text.Encoding.GetEncoding("GBK").GetBytes(path);
            return LoadGameObject(buffer);
        }


        [DllImport("fbxsdkbridge.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr LoadGameObject(byte[] ptah);

        [DllImport("fbxsdkbridge.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SaveGameObejct(IntPtr pgameobject, byte[] name);

        [DllImport("fbxsdkbridge.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CreateGameObject();

        [DllImport("fbxsdkbridge.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetGameObjectName(IntPtr pgameobject, byte[] name);

        [DllImport("fbxsdkbridge.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetGameObjectName(IntPtr pgameobject, byte[] ptah, int length);

        [DllImport("fbxsdkbridge.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetChildrenCount(IntPtr pgameobject);

        [DllImport("fbxsdkbridge.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetChildrenCount(IntPtr pgameobject, int count);

        [DllImport("fbxsdkbridge.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetChild(IntPtr pgameobject, int childIndex);

        [DllImport("fbxsdkbridge.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetChild(IntPtr pgameobject, int childIndex, IntPtr child);

        [DllImport("fbxsdkbridge.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetTransform(IntPtr pgameobject, ref TransformData transformdata);

        [DllImport("fbxsdkbridge.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetTransform(IntPtr pgameobject, TransformData transformdata);

        [DllImport("fbxsdkbridge.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetMesh(IntPtr pgameobject);

        [DllImport("fbxsdkbridge.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetPolygonCount(IntPtr pmesh);

        [DllImport("fbxsdkbridge.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetPolygonCount(IntPtr pmesh, int count);

        [DllImport("fbxsdkbridge.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetUVSetCount(IntPtr pmesh);

        [DllImport("fbxsdkbridge.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetUVSetCount(IntPtr pmesh, int count);

        [DllImport("fbxsdkbridge.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetPolygon(IntPtr pmesh, int polygonIndex, ref PolygonData polygondata);

        [DllImport("fbxsdkbridge.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetPolygon(IntPtr pmesh, int polygonIndex, PolygonData polygondata);

        [DllImport("fbxsdkbridge.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetRender(IntPtr pgameobject);

        [DllImport("fbxsdkbridge.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetMaterialCount(IntPtr prender);

        [DllImport("fbxsdkbridge.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetMaterialCount(IntPtr prender, int materialcount);

        [DllImport("fbxsdkbridge.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetMaterial(IntPtr prender, int mertialIndex, ref MaterialData materialdata);

        [DllImport("fbxsdkbridge.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetMaterial(IntPtr prender, int mertialIndex, MaterialData materialdata);

        [DllImport("fbxsdkbridge.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetTexture(IntPtr ptexture, ref TextureData texturedata);

        [DllImport("fbxsdkbridge.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetTexture(IntPtr ptexture, TextureData texturedata);

        [DllImport("fbxsdkbridge.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CreateTexture();

        [DllImport("fbxsdkbridge.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Destroy(IntPtr pgameobject);
    }
}
