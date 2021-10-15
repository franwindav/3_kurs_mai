#Ввод матрицы
def MatrixInput():
    print("Введите элементы матрицы:")
    tmp = list(map(float, input().split()))
    M = []
    while tmp != []:
        M.append(tmp)
        tmp = list(map(float, input().split()))
    return M

#Вывод матрицы
def MatrixOutput(M):
    if len(M) == 0:
        return
    # для выравнивая чисел найдем длину, необходимую для записи чисел
    n = 0
    for i in range(len(M)):
        for j in range(len(M[0])):
            if (n < len(str(M[i][j]))):
                n = len(str(M[i][j]))
    #вывод
    print("Полученная матрица:\n")
    for i in range (len(M)):
        for j in range (len(M[0])):
            print('{0:^{size}} '.format(M[i][j], size = n), end = '')
        print()

#Сложение матриц
def MatrixSum(M1, M2):
    if len(M1) != len(M2):
        print("Нельзя сложить!")
        return
    M3 = [[M1[i][j] + M2[i][j] for j in range (len(M1[0]))] for i in range (len(M1))]
    return MatrixOutput(M3)

#Вычитание матриц
def MatrixDiff(M1, M2):
    if len(M1) != len(M2):
        print("Нельзя отнять !")
        return
    M3 = [[M1[i][j] - M2[i][j] for j in range (len(M1[0]))] for i in range(len(M1))]
    return MatrixOutput(M3)

#Перемножение матриц
def MatrixCom(M1, M2):
    if len(M1[0]) != len(M2):
        print("Нельзя перемножить!")
        return
    M3 = [[0 for j in range (len(M2[0]))] for i in range (len(M1))]
    for i in range (len(M1)):
        for j in range (len(M2[0])):
            for k in range (len(M1[0])):
                M3[i][j] += M1[i][k] * M2[k][j]
    return MatrixOutput(M3)

#Нахождение определителя
def MatrixDet(M):
    sw = 1
    el = 1
    while len(M) > 1:
        n = 0
        #меняем строки местами до тех пор, пока перый элемент 0
        while M[0][0] == 0 and n != len(M):
            M[0], M[n + 1] = M[n + 1], M[0]
            n += 1
            sw = sw * (-1)
        #если все первые элементы 0, то определитель 0
        if n == len(M):
            return 0
        else:
            #Если первый элемент не 1
            if M[0][0] != 1:
                el = el * M[0][0]
                M[0] = [M[0][i] / M[0][0] for i in range(len(M))] #делим элементы строки на первый эл
            #записываем опеределитель n-1 порядка
            tmp = [[0 for j in range (len(M) - 1)] for i in range (len(M) - 1)]
            for j in range (1, len(M)):
                for i in range(1, len(M)):
                    tmp[i - 1][j - 1] = M[i][j] - M[i][0] * M[0][j]
            M = tmp
    #результат с округлением
    det = round(el * sw * M[0][0], 3)
    if det == -0.0:
        det = 0.0
    print("Полученный определитель: ", det)


while True:
    print('\nВведите номер задания:\n1)Сложение матриц\n2)Вычитание матриц\n3)Умножение матриц\n4)Нахождение определителя\n5)Выход')
    a = input()
    if a == '1': MatrixSum(MatrixInput(),MatrixInput())
    elif a == '2': MatrixDiff(MatrixInput(),MatrixInput())
    elif a == '3': MatrixCom(MatrixInput(),MatrixInput())
    elif a == '4': MatrixDet(MatrixInput())
    elif a == '5': break
    else: print("Неправильный номер.")
