#include <assert.h>
#include <ctype.h>
#include "sha1.h"

#define ALIGN(x,a) (((x)+(a)-1ULL)&~((a)-1ULL))

static UINT32 rotl32(UINT32 x, int b)
{
    return (x << b) | (x >> (32-b));
}

// switch endianness
static UINT32 get32 (const void* p)
{
    const UINT8 *x = (const UINT8*)p;
    return (x[0] << 24) | (x[1] << 16) | (x[2] << 8) | x[3];
}

static UINT32 f (int t, UINT32 b, UINT32 c, UINT32 d)
{
    assert(0 <= t && t < 80);

    if (t < 20)
        return (b & c) | ((~b) & d);
    if (t < 40)
        return b ^ c ^ d;
    if (t < 60)
        return (b & c) | (b & d) | (c & d);
    //if (t < 80)
        return b ^ c ^ d;
}


static void processBlock (const UINT32* block, UINT32* h)
{
    static const UINT32 k[4] =
    {
        0x5A827999,
        0x6ED9EBA1,
        0x8F1BBCDC,
        0xCA62C1D6
    };

    UINT32 w[80];
    UINT32 a = h[0];
    UINT32 b = h[1];
    UINT32 c = h[2];
    UINT32 d = h[3];
    UINT32 e = h[4];
    int t;

    for (t = 0; t < 16; t++)
        w[t] = get32(block++);
/*
    for (; t < 80; t++)
        w[t] = rotl32(w[t-3] ^ w[t-8] ^ w[t-14] ^ w[t-16], 1);
        */

    for (t = 0; t < 80; t++)
    {
        int s = t & 0xf;
        UINT32 temp;
        if (t >= 16)
            w[s] = rotl32(w[(s + 13) & 0xf] ^ w[(s + 8) & 0xf] ^ w[(s + 2) & 0xf] ^ w[s], 1);

         temp = rotl32(a, 5) + f(t, b,c,d) + e + w[s] + k[t/20];

         e = d; d = c; c = rotl32(b, 30); b = a; a = temp;
        /*
        UINT32 temp = rotl32(a, 5) + f(t, b,c,d) + e + w[t] + k[t/20];
        e = d;
        d = c;
        c = rotl32(b, 30);
        b = a;
        a = temp;
        */
    }

    h[0] += a;
    h[1] += b;
    h[2] += c;
    h[3] += d;
    h[4] += e;
}

static int padMsg (const void* msg, UINT64 bytes, UINT8* lastBlock)
{
    int msgBytesInLast   = (int)(bytes & 63);
    int extraBlocks      = (msgBytesInLast + 9) > 64 ? 2 : 1;
    int numZeroBytes     = extraBlocks * 64 - 9 - msgBytesInLast;

    // fill remaining msg bytes
    const UINT8* msgLast = (UINT8*)msg + (bytes & ~63);
    while (msgBytesInLast--)
        *lastBlock++ = *msgLast++;

    // separator
    *lastBlock++ = 0x80;

    while (numZeroBytes--)
        *lastBlock++ = 0;

    // original length in bits (!), switch endianness
    bytes *= 8;
    *lastBlock++ = (UINT8)(bytes >> 56 & 0xff);
    *lastBlock++ = (UINT8)(bytes >> 48 & 0xff);
    *lastBlock++ = (UINT8)(bytes >> 40 & 0xff);
    *lastBlock++ = (UINT8)(bytes >> 32 & 0xff);
    *lastBlock++ = (UINT8)(bytes >> 24 & 0xff);
    *lastBlock++ = (UINT8)(bytes >> 16 & 0xff);
    *lastBlock++ = (UINT8)(bytes >> 8  & 0xff);
    *lastBlock++ = (UINT8)(bytes >> 0  & 0xff);

    return extraBlocks;
}

SHA1_Digest SHA1_get (const void* msg, UINT64 bytes)
{
    SHA1_Digest digest;
    UINT32 h[5] =
    {
        0x67452301,
        0xefcdab89,
        0x98badcfe,
        0x10325476,
        0xc3d2e1f0
    };

    UINT64 totalBlocks = ALIGN(bytes + 9, 64) / 64; // including padding
    const UINT32* block = (const UINT32*)msg;
    UINT64 b;

    // we could assume that msg is always required to
    // hold padding, but let's not
    UINT8 lastBlocks[128];  // either one or two blocks
    int numLast = padMsg(msg, bytes, lastBlocks);

    for (b = 0; b < totalBlocks-numLast; b++)
    {
        processBlock(block, h);
        block += 16;
    }

    // process last block
    for (b = 0; b < numLast; b++)
        processBlock((const UINT32*)(lastBlocks + b*64), h);

    *((UINT32*)&digest.digest[0])  = get32(&h[0]);
    *((UINT32*)&digest.digest[4])  = get32(&h[1]);
    *((UINT32*)&digest.digest[8])  = get32(&h[2]);
    *((UINT32*)&digest.digest[12]) = get32(&h[3]);
    *((UINT32*)&digest.digest[16]) = get32(&h[4]);
    return digest;
}


SHA1_Digest SHA1_Digest_fromStr (const char* src)
{
    // \todo why does msvc require this initializer to not issue C4701 ?
    SHA1_Digest d = { "" }; 
    int i;
    
    assert(src); // also, src must be at least 40 bytes
    for (i = 0; i < 20; i++)
    {
        // \todo just use atoi or something
        int c0 = tolower(*src++);
        int c1 = tolower(*src++);

        c0 = '0' <= c0 && c0 <= '9' ? c0 - '0' : ('a' <= c0 && c0 <= 'f' ? 0xa + c0 - 'a' : -1);
        c1 = '0' <= c1 && c1 <= '9' ? c1 - '0' : ('a' <= c1 && c1 <= 'f' ? 0xa + c1 - 'a' : -1);
        d.digest[i] = (UINT8)((c0 << 4) | c1);
    }

    return d;
}

void SHA1_Digest_toStr (const SHA1_Digest* digest, char* dst)
{
    int i;
    assert(digest && dst); // dst must be at least 41 bytes (terminator)
    for (i = 0; i < 20; i++)
    {
        int c0 = digest->digest[i] >> 4;
        int c1 = digest->digest[i] & 0xf;

        assert(0 <= c0 && c0 <= 0xf);
        assert(0 <= c1 && c1 <= 0xf);
        c0 = c0 <= 9 ? '0' + c0 : 'a' + c0 - 0xa;
        c1 = c1 <= 9 ? '0' + c1 : 'a' + c1 - 0xa;

        *dst++ = (char)c0;
        *dst++ = (char)c1;
    }
    *dst = '\0';
}
