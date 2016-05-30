#ifndef __MBDBLS_H
#define  __MBDBLS_H

#include "stdlib.h"
#include "stdio.h"
#include "string.h"
#include "sha1.h"
#include <list>
#include <map>
#include <string>


typedef struct fileinfo_data{
	long start_offset;
	std::string domain;
	std::string filename;
	std::string fullpath;
	std::string fileID;
	std::string linktarget;
	std::string datahash;
	std::string unknown1;
	unsigned int mode;
	unsigned int unknown2;
	unsigned int unknown3;
	unsigned int userid;
	unsigned int groupid;
	unsigned int mtime;
	unsigned int atime;
	unsigned int ctime;
	unsigned int filelen;
	unsigned int flag;
	unsigned int numprops;
	std::map<std::string,std::string> properties;
}FILEINFO;

typedef std::map<int,FILEINFO> FILEINFOS;


FILEINFOS process_mbdb_file(char* filename);

#endif