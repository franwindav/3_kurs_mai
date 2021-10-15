#include <iostream>
#include <random>
#include <conio.h>

const double fRAND_MIN = -100.0;
const double fRAND_MAX = 100.0;

double GetRandomNum(double fMin, double fMax)
{
	std::random_device rd;
	std::mt19937 eng(rd());
	std::uniform_real_distribution<> distr(fMin, fMax);

	return distr(eng);
}

double GetMaxArrayElement(double Array[], int size)
{
	double max = fRAND_MIN - 1.0;

	for (int i = 0; i < size; i++)
		if (Array[i] > max)
			max = Array[i];

	return max;
}

int main()
{
	double A[4][6] = {0}, C[4] = {0};

	do
	{
		system("cls");
		for (int i = 0; i < 4; i++)
			for(int k = 0; k < 6; k++){
				A[i][k] = GetRandomNum(fRAND_MIN, fRAND_MAX);
				printf("A[%2d][%2d] = %-.2f\n", i, k, A[i][k]);
			}

		printf("\n");
	
		for (int i = 0; i < 4; i++)
		{
			if (A[i][5] > 0)
				C[i] = GetMaxArrayElement(A[i], 6);
			else
				C[i] = 0;

			printf("C[%2d] = %-.2f\n", i, C[i]);
		}
	} while (_getch() != 27);

	return 0;
}