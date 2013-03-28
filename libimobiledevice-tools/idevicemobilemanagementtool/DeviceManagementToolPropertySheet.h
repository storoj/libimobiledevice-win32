#pragma once

#include "DeviceInfoPropertyPage.h"

// CDeviceManagementToolPropertySheet

class CDeviceManagementToolPropertySheet : public CMFCPropertySheet
{
	DECLARE_DYNAMIC(CDeviceManagementToolPropertySheet)

public:
	CDeviceManagementToolPropertySheet();
	virtual ~CDeviceManagementToolPropertySheet();

protected:
	DECLARE_MESSAGE_MAP()

private:
	CDeviceInfoPropertyPage m_deviceInfoPropertyPage;

	void AddPages(void);
public:
	virtual BOOL OnInitDialog();
};


