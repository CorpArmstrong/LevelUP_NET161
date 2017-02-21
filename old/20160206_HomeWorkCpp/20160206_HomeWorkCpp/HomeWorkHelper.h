#pragma once

/*
 * This is homework helper.
 * Most of numbers are integers for simplicity.
 */
class HomeWorkHelper
{
public:
	HomeWorkHelper();
	~HomeWorkHelper();
	
	void PrintHelloWorld(int num);

	void Average(int num1, int num2);

	void ReturnNumberOfDigits(int num);

	void WriteNumberRange(int num);

	bool IsNumberNegative(int num);

	void PlaySound(int num);

	void FlipAbsForNumber(int num);

	int ReturnAbsForNumber(int num);

	bool IsNumberCanBeDividedByNumber(int num1, int num2);

	int ReturnRandomNumberForRange();

	void ShowDivisionResult(int num1, int num2);

	int ReturnModuloForNumbers(int num1, int num2);
};

