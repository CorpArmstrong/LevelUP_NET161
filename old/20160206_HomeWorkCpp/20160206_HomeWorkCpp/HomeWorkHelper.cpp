#include "stdafx.h"
#include "HomeWorkHelper.h"

HomeWorkHelper::HomeWorkHelper() {}

HomeWorkHelper::~HomeWorkHelper() {}

void HomeWorkHelper::PrintHelloWorld(int num)
{
	for (int i = 0; i < num; i++)
	{
		cout << "Hello, world!" << endl;
	}
}

void HomeWorkHelper::Average(int num1, int num2)
{
	printf("The average for '%d' and '%d' is '%d'.", num1, num2, (num1 + num2) / 2);
}

void HomeWorkHelper::ReturnNumberOfDigits(int num)
{
	int digitsCounter = 0;
	int tempNumber = num;
	bool isEnded = false;

	while (!isEnded)
	{
		if ((tempNumber / 10) >= 0 && (tempNumber % 10) > 0)
		{
			tempNumber /= 10;
			digitsCounter++;
		}
		else
		{
			isEnded = true;
		}
	}

	printf("The number of digits for number '%d' is '%d'.", num, digitsCounter);
}

void HomeWorkHelper::WriteNumberRange(int num)
{
	for (int i = 0; i < num; i++)
	{
		cout << i << " ";
	}
}

bool HomeWorkHelper::IsNumberNegative(int num)
{
	bool isNegativeNumber = false;

	if (num == 0)
	{
		printf("The number '%d' is zero.", num);
		return false;
	}

	if (num < 0)
	{
		isNegativeNumber = true;
	}

	printf("The number '%d' negative? '%s'.", num, isNegativeNumber ? "true" : "false");	
	return isNegativeNumber;
}

void HomeWorkHelper::PlaySound(int num)
{
	const char beep = '\a';
	for (int i = 0; i < num; i++)
	{
		cout << beep;
	}
}

void HomeWorkHelper::FlipAbsForNumber(int num)
{
	if (num <= 0)
	{
		cout << abs(num) << endl;
	}

	if (num > 0)
	{
		cout << (num *= -1) << endl;
	}
}

int HomeWorkHelper::ReturnAbsForNumber(int num)
{
	int absNum = abs(num);
	printf("Abs for number '%d' is '%d'.", num, absNum);
	return absNum;
}

bool HomeWorkHelper::IsNumberCanBeDividedByNumber(int num1, int num2)
{
	bool result = false;

	if (num2 != 0)
	{
		result = num1 / num2 > 0;
		printf("The number '%d' can be divided by number '%d'? '%s'.", num1, num2, result ? "true" : "false");
	}
	else
	{
		throw exception("Division by zero error!\nCheck your data!");
	}

	return result;
}

int HomeWorkHelper::ReturnRandomNumberForRange()
{
	srand((unsigned)time(NULL));
	int result = rand() % 13 + 1;
	printf("Random number for range from '%d' to '%d' is '%d'.", 1, 13, result);

	return result;
}

void HomeWorkHelper::ShowDivisionResult(int num1, int num2)
{
	if (num2 != 0)
	{
		printf("Division result for numbers: '%d' and '%d' is '%f'.", num1, num2, ((float)num1 / num2));
	}
	else
	{
		throw exception("Divide by zero error!\nCheck your data!");
	}
}

int HomeWorkHelper::ReturnModuloForNumbers(int num1, int num2)
{
	int result = 0;

	if (num1 == num2 && num1 == 0)
	{
		printf("Modulo for numbers: '%d' and '%d' is '%d'.", num1, num2, 0);
		return 0;
	}

	if (num1 > num2)
	{
		if (num2 != 0)
		{
			result = num1 % num2;
		}
		else
		{
			throw exception("Divide by zero error!\nCheck your data!");
		}
	}

	if (num2 > num1)
	{
		if (num1 != 0)
		{
			result = num2 % num1;
		}
		else
		{
			throw exception("Divide by zero error!\nCheck your data!");
		}
	}

	printf("Modulo for numbers: '%d' and '%d' is '%d'.", num1, num2, result);
	return result;
}