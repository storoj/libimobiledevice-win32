#include "mbdbls.h"

#pragma comment(lib,"libsha1.lib")

size_t GetNext4Byte(char* buff,FILE* file)
{
	if( !buff ||  !file)
	{
		return -1;
	}
	return fread(buff,1,4,file);
}

unsigned int GetInt(FILE* file,int intsize)
{
	 //"""Retrieve an integer (big-endian) 
	if( !file )
	{
		return -1;
	}

	unsigned int value = 0;
	unsigned char bytedata = 0;
	while (intsize > 0)
	{
		bytedata = 0;
		if(fread(&bytedata,1,1,file) < 0)
		{
			break;
		}
		value = (value<<8) + bytedata;
		intsize = intsize - 1;
	}
	return value;
}

std::string GetString(FILE* file)
{
	//"""Retrieve a string and new offset from the current offset into the data"""
	if( !file)
	{
		return "";
	}

	char data[2] = {0};
	char* stringdata = NULL;
	std::string value;
	unsigned int length = 0;
	size_t pos = ftell(file);
	if(fread(&data,1,2,file) != 2 )
	{
		return "";
	}
	pos = ftell(file);

	if (data[0] ==(char) 0xff && data[1] ==(char) 0xff)
	{
		return "";
	}	
	pos = ftell(file);
	fseek(file,-2,SEEK_CUR);
	pos = ftell(file);
	length = GetInt(file, 2); //# 2-byte length
	stringdata = (char*)malloc(length+1);
	memset(stringdata,0,length+1);
	fread(stringdata,length,1,file);
	value = stringdata;
	free(stringdata);
	return value;
}

FILEINFOS process_mbdb_file(char* filename)
{
	FILEINFOS fileinfors;
	if ( !filename )
	{
		return fileinfors;
	}
	FILE *file;
	char buff[5] = {0};
	size_t pos = 0;
	size_t filesize = 0;


	file = fopen(filename,"rb");
	fseek(file,0,SEEK_END);
	filesize = ftell(file);
	fseek(file,0,SEEK_SET);

	if (GetNext4Byte(buff,file) <= 0)
	{
		return fileinfors;
	}
	

	//check mbdb file
	if (strcmp(buff,"mbdb") == 0)
	{
		fseek(file,2,SEEK_CUR); //skip the 0x05 0x00
		while (ftell(file) < filesize)
		{
			FILEINFO fileinfo;

			
			fileinfo.start_offset = ftell(file);
			fileinfo.domain = GetString(file);
			fileinfo.filename = GetString(file);
			fileinfo.fullpath = fileinfo.domain + "::" + fileinfo.filename;

			std::string sha1temp = fileinfo.domain + "-" +fileinfo.filename;
			char sha1temp2[41] = {0};
			SHA1_Digest computed = SHA1_get(sha1temp.c_str(),sha1temp.length());
			SHA1_Digest_toStr(&computed,sha1temp2);
			fileinfo.fileID = sha1temp2;

			fileinfo.linktarget = GetString(file);
			fileinfo.datahash = GetString(file);
			fileinfo.unknown1 = GetString(file);
			fileinfo.mode = GetInt(file,2);
			fileinfo.unknown2 = GetInt(file,4);
			fileinfo.unknown3 = GetInt(file,4);
			fileinfo.userid = GetInt(file,4);
			fileinfo.groupid = GetInt(file,4);
			fileinfo.mtime = GetInt(file,4);
			fileinfo.atime = GetInt(file,4);
			fileinfo.ctime = GetInt(file,4);
			fileinfo.filelen = GetInt(file,8);
			fileinfo.flag = GetInt(file,1);
			fileinfo.numprops = GetInt(file,1);
			for (int i = 0; i < fileinfo.numprops ; i++)
			{
				std::string propname = GetString(file);
				std::string propval = GetString(file);
				fileinfo.properties.insert(std::map<std::string,std::string>::value_type(propname,propval));
			}
			fileinfors.insert(FILEINFOS::value_type(fileinfo.start_offset,fileinfo));
		}
	}
	
	return fileinfors;	
}

//test
void main(int argc, char** argv)
{
	FILE *outfile = NULL;

	if (argc <2)
	{
		return;
	}
	char * filepath = argv[1];
	outfile = fopen(filepath,"w+");
	if (outfile == NULL)
	{
		return;
	}

	
	FILEINFOS fileinfos = process_mbdb_file("S:\\iphonebak\\Manifest.mbdb");
	for (auto it = fileinfos.begin(); it != fileinfos.end(); it++)
	{
		char num[200]={};
		std::string temp = _itoa(it->second.start_offset,num,10);
		std::string temp2 = temp + "           "+ it->second.fileID + "        " + it->second.fullpath + "\n";
		fwrite(temp2.c_str(),temp2.length(),1,outfile);
	}
	
}