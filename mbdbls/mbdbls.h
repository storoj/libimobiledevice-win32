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
	size_t start_offset;
	std::string domain;
	std::string filename;
	std::string fullpath;
	std::string fileID;
	std::string linktarget;
	std::string datahash;
	std::string unknown1;
	unsigned int mode;
	int unknown2;
	int unknown3;
	int userid;
	int groupid;
	int mtime;
	int atime;
	int ctime;
	int filelen;
	int flag;
	int numprops;
	std::map<std::string,std::string> properties;
}FILEINFO;

typedef std::map<int,FILEINFO> FILEINFOS;


FILEINFOS process_mbdb_file(char* filename);

#endif