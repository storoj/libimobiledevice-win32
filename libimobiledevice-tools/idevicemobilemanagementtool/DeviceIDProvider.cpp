#include "stdafx.h"
#include "DeviceIDProvider.h"

#include <libimobiledevice/libimobiledevice.h>
#include <libimobiledevice/lockdown.h>

std::vector<CString> *CDeviceIDProvider::GetDeviceIDList(void)
{
	char **dev_list = NULL;
	int i;
	
	if (idevice_get_device_list(&dev_list, &i) < 0) {
		return NULL;
	}

	std::vector<CString> *result = new std::vector<CString>();
	for (i = 0; dev_list[i] != NULL; i++) {
		result->push_back(CString(dev_list[i]));
	}

	idevice_device_list_free(dev_list);

	return result;
}
