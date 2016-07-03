// 20160206_HomeWorkCpp.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "HomeWorkHelper.h"

int _tmain(int argc, _TCHAR* argv[])
{
	HomeWorkHelper homeWorkHelper;

	try
	{
		//homeWorkHelper.PrintHelloWorld(5);
		//homeWorkHelper.Average(1, 5);
		//homeWorkHelper.ReturnNumberOfDigits(15257);
		//homeWorkHelper.WriteNumberRange(45);
		//homeWorkHelper.IsNumberNegative(-10);
		//homeWorkHelper.PlaySound(6);
		//homeWorkHelper.FlipAbsForNumber(-10);
		//homeWorkHelper.ReturnAbsForNumber(-22);
		//homeWorkHelper.IsNumberCanBeDividedByNumber(3, 1);
		//homeWorkHelper.ReturnRandomNumberForRange();
		//homeWorkHelper.ShowDivisionResult(3, 2);
		homeWorkHelper.ReturnModuloForNumbers(5, 4);
	}
	catch (const exception& ignored)
	{
		cout << "General exception occured!\nCause: " << ignored.what() << endl;
	}

	cout << "\nPress any key to quit...";
	_getch();

	return 0;
}

