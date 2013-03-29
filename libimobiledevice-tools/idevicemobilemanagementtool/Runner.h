#pragma once

// =======================================================
// ================== RunnerArgument class ===============
// =======================================================

class RunnerArgument
{
private:
	CString *m_Key;
	CString *m_Value;

public:
	RunnerArgument(CString *key, CString *value = nullptr) : m_Key(key), m_Value(value) { }

	CString *ToString() const;
};

// =======================================================
// ===================== Runner class ====================
// =======================================================

class Runner
{
public:
	typedef enum RunnerType {
		GetDeviceInfoRunnerType
	} RunnerType_t;

private:
	std::vector<RunnerArgument> *m_Arguments;
	CString *m_FileName;

public:
	static Runner *GetRunnerOfType(RunnerType_t);

	Runner(void);
	virtual ~Runner(void);
	virtual void Run(void) = 0;

protected:
	void SetArguments(std::vector<RunnerArgument> arguments);
};


