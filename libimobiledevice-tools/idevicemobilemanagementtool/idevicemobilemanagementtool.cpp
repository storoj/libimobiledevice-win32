
// idevicemobilemanagementtool.cpp : Defines the class behaviors for the application.
//

#include "stdafx.h"
#include "idevicemobilemanagementtool.h"
#include "DeviceManagementToolPropertySheet.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CDeviceManagementToolApp

BEGIN_MESSAGE_MAP(CDeviceManagementToolApp, CWinAppEx)
	ON_COMMAND(ID_HELP, &CWinAppEx::OnHelp)
END_MESSAGE_MAP()


// CDeviceManagementToolApp construction

CDeviceManagementToolApp::CDeviceManagementToolApp()
{
	// TODO: add construction code here,
	// Place all significant initialization in InitInstance
}


// The one and only CDeviceManagementToolApp object

CDeviceManagementToolApp theApp;


// CDeviceManagementToolApp initialization

BOOL CDeviceManagementToolApp::InitInstance()
{
	// InitCommonControlsEx() is required on Windows XP if an application
	// manifest specifies use of ComCtl32.dll version 6 or later to enable
	// visual styles.  Otherwise, any window creation will fail.
	INITCOMMONCONTROLSEX InitCtrls;
	InitCtrls.dwSize = sizeof(InitCtrls);
	// Set this to include all the common control classes you want to use
	// in your application.
	InitCtrls.dwICC = ICC_WIN95_CLASSES;
	InitCommonControlsEx(&InitCtrls);

	CWinAppEx::InitInstance();


	AfxEnableControlContainer();

	// Activate "Windows Native" visual manager for enabling themes in MFC controls
	CMFCVisualManager::SetDefaultManager(RUNTIME_CLASS(CMFCVisualManagerWindows));

	CDeviceManagementToolPropertySheet deviceManagementToolPropertySheet;
	m_pMainWnd = &deviceManagementToolPropertySheet;
	deviceManagementToolPropertySheet.DoModal();

	// Since the dialog has been closed, return FALSE so that we exit the
	//  application, rather than start the application's message pump.
	return FALSE;
}

