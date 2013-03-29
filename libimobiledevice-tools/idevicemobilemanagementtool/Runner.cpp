#include "stdafx.h"
#include "Runner.h"


CString *RunnerArgument::ToString(void) const
{
	if (m_Value == nullptr || m_Value->IsEmpty()) {
		// Key-only
		return new CString(*m_Key);
	} else {
		// Key-Value pair
		return new CString(*m_Key + _T(" ") + *m_Value);
	}
}

Runner::Runner(void)
{
	m_Arguments = new std::vector<RunnerArgument>();
}

Runner::~Runner(void)
{
	delete m_Arguments;
}

void Runner::SetArguments(std::vector<RunnerArgument> arguments)
{
	// Not implemented
}

