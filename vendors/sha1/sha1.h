


#pragma once
typedef unsigned char       UINT8;
typedef unsigned int        UINT32;
typedef unsigned long long  UINT64;

// struct so we can return it (it's 5x32bit)
typedef struct _SHA1_Digest
{
	UINT8 digest[20];
} SHA1_Digest;


#ifdef __cplusplus
extern "C"
{
#endif


SHA1_Digest SHA1_Digest_fromStr (const char* src);
void        SHA1_Digest_toStr   (const SHA1_Digest* digest, char* dst);
SHA1_Digest SHA1_get (const void* msg, UINT64 bytes);


#ifdef __cplusplus
}
#endif







