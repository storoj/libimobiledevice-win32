#pragma once
#include "afx.h"

class CDeviceIDProvider
{
public:
	static const TCHAR *CDeviceIDProvider::AUTOMATIC_DETECTION_OPTION;

	std::vector<CString> *GetDeviceIDList(void);

	void FillComboboxWithItems(CComboBox *combobox, bool addAutomaticDetectionOption = true);
};

