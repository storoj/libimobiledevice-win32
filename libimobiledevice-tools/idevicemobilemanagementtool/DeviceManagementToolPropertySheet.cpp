// DeviceManagementToolPropertySheet.cpp : implementation file
//

#include "stdafx.h"
#include "idevicemobilemanagementtool.h"
#include "DeviceManagementToolPropertySheet.h"


// CDeviceManagementToolPropertySheet

IMPLEMENT_DYNAMIC(CDeviceManagementToolPropertySheet, CMFCPropertySheet)

CDeviceManagementToolPropertySheet::CDeviceManagementToolPropertySheet() : CMFCPropertySheet(_T("iDevice Management Tool"))
{
	SetLook(CMFCPropertySheet::PropSheetLook_Tabs);

	AddPages();
}

CDeviceManagementToolPropertySheet::~CDeviceManagementToolPropertySheet()
{
}


BEGIN_MESSAGE_MAP(CDeviceManagementToolPropertySheet, CMFCPropertySheet)
END_MESSAGE_MAP()



// CDeviceManagementToolPropertySheet message handlers




void CDeviceManagementToolPropertySheet::AddPages(void)
{
	this->AddPage(&m_deviceInfoPropertyPage);
}

BOOL CDeviceManagementToolPropertySheet::OnInitDialog()
{
	BOOL result = CMFCPropertySheet::OnInitDialog();

	GetDlgItem(IDOK)->ShowWindow( SW_HIDE );
	GetDlgItem(IDCANCEL)->ShowWindow( SW_HIDE );
	GetDlgItem(ID_APPLY_NOW)->ShowWindow( SW_HIDE );
	GetDlgItem(IDHELP)->ShowWindow(SW_HIDE);

	return result;
}
