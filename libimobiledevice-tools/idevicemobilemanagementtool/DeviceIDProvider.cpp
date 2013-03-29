#include "stdafx.h"
#include "DeviceIDProvider.h"

#include <libimobiledevice/libimobiledevice.h>
#include <libimobiledevice/lockdown.h>

const TCHAR *CDeviceIDProvider::AUTOMATIC_DETECTION_OPTION = _T("<Automatic detection>");

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

void CDeviceIDProvider::FillComboboxWithItems(CComboBox *combobox, bool addAutomaticDetectionOption)
{
	assert(combobox);

	if (addAutomaticDetectionOption) {
		combobox->AddString(CDeviceIDProvider::AUTOMATIC_DETECTION_OPTION);
		combobox->SetItemData(0, -1);
	}

	std::vector<CString> *listOfDevices = GetDeviceIDList();

	int index = 0;
	for (auto iterator = listOfDevices->cbegin(); iterator != listOfDevices->cend(); iterator++) {
		CString value = *iterator;

		combobox->AddString(value);
		combobox->SetItemData(index + (int(addAutomaticDetectionOption)), index);

		index++;
	}

	delete listOfDevices;
}
