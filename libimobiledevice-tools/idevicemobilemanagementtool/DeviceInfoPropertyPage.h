#pragma once
#include "afxwin.h"


// CDeviceInfoPropertyPage dialog

class CDeviceInfoPropertyPage : public CMFCPropertyPage
{
	DECLARE_DYNAMIC(CDeviceInfoPropertyPage)

public:
	CDeviceInfoPropertyPage();
	virtual ~CDeviceInfoPropertyPage();

// Dialog Data
	enum { IDD = IDD_PROPPAGE_DEVICE_INFO };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	virtual BOOL OnInitDialog();

	DECLARE_MESSAGE_MAP()

public:
	CComboBox m_DeviceIDCombo;
	CString m_DomainName;
	CString m_Key;
	BOOL m_SimpleMode;
	BOOL m_XmlOutput;
	BOOL m_Debug;
	CButton m_GoButton;

	afx_msg void OnBnClickedDeviceInfoSubmitButton();
	void FillDeviceIDCombo();
};
