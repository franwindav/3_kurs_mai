#define _CRT_SECURE_NO_WARNINGS

#include <iostream>
#include <random>
#include <conio.h> 
#include <time.h>

const char gc_cProfession[12][32] = {"Начальник отдела", "Администратор", "Менеджер", "Бухгалтер", "Продавец", "Секретарь", "Водитель", "Монтажник", "Канцеляр", "Уборщик", "Охранник", "Патологоанатом"};

const char gc_cLastName[17][16] = {"Андреев", "Ахмедова", "Винокуров", "Головков", "Горячев", "Демура", "Дубицкий", "Загрыценко", "Зинкевич", "Иванников", "Левшин", "Лысов", "Моисеев", "Москалев", "Севрюков", "Царева", "Шатохин"};
const char gc_cInitials[17][4] = {"И.М", "А.В", "А.Р", "П.Х", "А.А", "С.В", "И.В", "С.К", "С.Ю", "А.А", "В.Ю", "М.Х", "А.А", "А.К", "А.М", "И.Е", "И.М"};

struct WORKER
{
	char cFIO[64];
	char cProfession[32];
	int iDate[3];

	WORKER *Next, *Head;
};

int GetRandomNum(int iMin, int iMax)
{
	std::random_device rd;
	std::mt19937 eng(rd());
	std::uniform_int_distribution<> distr(iMin, iMax);

	return distr(eng);
}

void Show(WORKER *MyList, char *FIO)
{
	int index = 1;

	WORKER *temp = MyList->Head;
	while (temp != NULL)
	{
		printf("%s vs %s\n", temp->cFIO, FIO);
		if (strcmp(temp->cFIO, FIO) == 0)
		{
			printf("%2d. | %02d.%02d.%d | %s\t| %s\n", index, temp->iDate[0], temp->iDate[1], temp->iDate[2], temp->cProfession, temp->cFIO);
			index++;
		}
		temp=temp->Next;
	}
}

void Show(WORKER *MyList)
{
	int index = 1;

	WORKER *temp = MyList->Head;
	while (temp != NULL)
	{
		printf("%2d. | %02d.%02d.%d | %s\t| %s\n", index, temp->iDate[0], temp->iDate[1], temp->iDate[2], temp->cProfession, temp->cFIO);
		index++;
		temp=temp->Next;
	}
}

void Add(int bd_d, int bd_m, int bd_y, char cFIO[], char Profession[], WORKER **MyList)
{
	WORKER *temp = new WORKER;

	temp->iDate[0] = bd_d;
	temp->iDate[1] = bd_m;
	temp->iDate[2] = bd_y;

	sprintf_s(temp->cFIO, cFIO);
	sprintf_s(temp->cProfession, Profession);

	temp->Next = (*MyList)->Head;
	(*MyList)->Head = temp;
}

void Randomize(struct WORKER *List, int count)
{
	time_t ttime;
	char cBuf[3][16] = {0}, c_Buf2[2][64] = {0};

	for (int i = 0; i < count; i++)
	{
		ttime = GetRandomNum(0, 1423602138);
		strftime(cBuf[0], sizeof(cBuf), "%d", localtime(&ttime));
		strftime(cBuf[1], sizeof(cBuf), "%m", localtime(&ttime));
		strftime(cBuf[2], sizeof(cBuf), "%Y", localtime(&ttime));

		sprintf(c_Buf2[0], "%10s %s", gc_cLastName[GetRandomNum(0, 16)], gc_cInitials[GetRandomNum(0, 16)]);
		sprintf(c_Buf2[1], "%s",  gc_cProfession[GetRandomNum(0, 11)]);

		Add(atoi(cBuf[0]), atoi(cBuf[1]), atoi(cBuf[2]), c_Buf2[0], c_Buf2[1], &List);
	}

	printf("\n");
}

int main()
{
	char cFIO[64] = {0};

	setlocale(LC_ALL, "Russian");

	do{
		printf("Поиск...\n");
		WORKER *MyList = new WORKER;
		MyList->Head = NULL;

		Randomize(MyList, 500);
		Show(MyList);

		printf("Введите фамилию и инициалы для поиска: ");
		scanf("%[^\n\r]", cFIO);

		
		Show(MyList, cFIO);

	} while (_getch() != 27);

	return 0;
}