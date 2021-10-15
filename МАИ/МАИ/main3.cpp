/**
	����� ������� ������:

	��� �������� ������� ����������� ���������� �������
	����� ����� ���������� ���������� � ������� Blablabla, ��� ������ �� ������ ���� ��������
	� ����� �������������� ���-�� � ����� ��������� � ������ �������� �������
	��� ������ ������������ � ���������� �� ������ ����������
	- ��� (�������� ���� ����������) � ���� ������� ������

**/

// # - ��������������� ���������
// ���������� ����������� ������������ �����
#include <iostream>
#include <time.h>
#include <conio.h>

// ��� �������� ������ ���������� ������ �������� �� ������
const int ARRAYSIZE = 5;

/*
	������� ���� VOID (�� ������ ���������� ��������) ��� ...

	@Array	- ������������ ������
	@size	- ������������� ���������� �������� ������ ������� Array, ������������ ��� ��������� ������ �����
	@count	- ������ �� ���������� ��� ������� ���-�� ���������� ���������
	@amount	- ������ �� ���������� ��� ����� ���������� ���������
*/ 
void Blablabla(double Array[], int size, int &count, int &amount)
{
	for (int i = 0; i < size; i++)
	{
		// % - ��� ������� �� ������. � ������ ������ �� ������ ��� (���������, ��� ������� ������)
		// � ������� ������� ������ ����
		if (i % 2 == 0 && Array[i] > 0)
		{
			// ���������� � �������� �������� ���������� amount �������� �������� �������� ������� Array
			// � ����������� �������� ���������� count �� �������
			amount += Array[i];
			count++;
		}
	}

	return;
}


// ����� ����� � ���������
int main()
{
	// �������� ������� srand �� ������������� ����� time.h � �������� � �������� ��������� ������� TIMESTAMP
	srand(time(NULL));

	// ������� � ����� �� ������������� ������ ��� ������������� �������
	int count[2] = {0}, amount[2] = {0};

	// ������� � ����� �� ������������� ������ ��� ������������ �������
	double A[ARRAYSIZE] = {0}, D[ARRAYSIZE] = {0};

	// ���� � ������������
	do
	{
		// ������� �������
		system("cls");

		// ��������� ��� ������� �������� �������� ������ ���������� �������
		// � ������� �������� ��� ������� � ���������� �������� ����������� 
		for (int i = 0; i < ARRAYSIZE; i++)
		{
			A[i] = rand() - rand();
			D[i] = rand() - rand();
			printf("%8.1f | %8.1f\n", A[i], D[i]);
		}

		// �������� ������� Blablabla � �������� � ��:
		// - ������ ��������� �����
		// - ������ �������
		// - ���������� ��� ������� ��� �������� ���-�� ������������� ��������� � ������ �������� �������
		// - ���������� ��� �������� ����� ������������� ��������� � ������ �������� �������
		// �� ������ � ������� iTemp �������� ���-�� ������ ������������� ������������� ����� � ������� A
		// --------

		Blablabla(A, ARRAYSIZE, count[0], amount[0]);
		Blablabla(D, ARRAYSIZE, count[1], amount[1]);

		// ������� ���������� �� �������
		printf("\ncount[0] = %d\namount[0] = %d\n\ncount[1] = %d\namount[1] = %d\n\n", count[0], amount[0], count[1], amount[1]);

	// ����: ���� ������� �� ���������� ������ �� ESC - �������� ���� �� �����
	} while (_getch() != 27);

	// ����� ������. ��������� ��������� � ����� 0 (������ �� ���������� ������)
	return 0;
}