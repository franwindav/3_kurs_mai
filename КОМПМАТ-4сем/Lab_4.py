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
    #для выравнивая чисел найдем длину, необходимую для записи чисел
    n = 0
    for i in range (len(M)):
        for j in range (len(M[0])):
            if (n < len(str(M[i][j]))):
                n = len(str(M[i][j]))
    #вывод
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
    return M3

#Вычитание матриц
def MatrixDiff(M1, M2):
    if len(M1) != len(M2):
        print("Нельзя отнять !")
        return
    M3 = [[M1[i][j] - M2[i][j] for j in range (len(M1[0]))] for i in range (len(M1))]
    return M3

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
    return M3

#Умножение матрицы на -1
def MatrixNeg(M):
    R = [[0 for j in range (len(M[0]))] for i in range (len(M))]
    for i in range(len(M)):
        for j in range(len(M[i])):
            R[i][j] = -1 * M[i][j]
    return R


#Перемножение матриц блоками
def BlockMatrixCom(A, B):             

    #Если матрицы 1х1
    if len(A) == 1 and len(B) == 1:
        return [[A[0][0]] * B[0][0]]
    
    #Если матрицы 2х2
    elif len(A) == 2 and len(B) == 2:
        C = [[0 for j in range (len(A))] for i in range (len(A))]
        C[0][0] = A[0][0] * B[0][0] + A[0][1] * B[1][0]
        C[0][1] = A[0][0] * B[0][1] + A[0][1] * B[1][1]
        C[1][0] = A[1][0] * B[0][0] + A[1][1] * B[1][0]
        C[1][1] = A[1][0] * B[0][1] + A[1][1] * B[1][1]
        return C

    #добавляем строку и столбец из нулей в случае, когда количество нечетно
    f = 0
    if len(A) % 2 != 0 or len(B) % 2 != 0:
        for row in A:
            row.append(0)
        A.append([0 for i in range (len(A[0]))])
        for row in B:
            row.append(0)
        B.append([0 for i in range (len(A[0]))])
        f += 1
    
    line = int(len(A) / 2) 
    end = len(A)

    #Разбиение А и B на блоки
    A1 = [[A[i][j] for j in range (line)] for i in range (line)]
    A2 = [[A[i][j] for j in range (line, end)] for i in range (line)]
    A3 = [[A[i][j] for j in range (line)] for i in range (line, end)]
    A4 = [[A[i][j] for j in range (line, end)] for i in range (line, end)]

    B1 = [[B[i][j] for j in range (line)] for i in range (line)]
    B2 = [[B[i][j] for j in range (line, end)] for i in range (line)]
    B3 = [[B[i][j] for j in range (line)] for i in range (line, end)]
    B4 = [[B[i][j] for j in range (line, end)] for i in range (line, end)]

    #Перемножение по схеме
    M1 = MatrixSum(BlockMatrixCom(A1, B1), BlockMatrixCom(A2,B3))
    M2 = MatrixSum(BlockMatrixCom(A1, B2), BlockMatrixCom(A2,B4))
    M3 = MatrixSum(BlockMatrixCom(A3, B1), BlockMatrixCom(A4,B3))
    M4 = MatrixSum(BlockMatrixCom(A3, B2), BlockMatrixCom(A4,B4))

    # Финальная матрица М
    M = [[0 for j in range (len(A))] for i in range (len(A))]
    for i in range(len(M1)):
        for j in range(len(M1)):
            M[i][j] = M1[i][j]
    for i in range(len(M2)):
        for j in range(len(M2)):
            M[i][j+len(M2)] = M2[i][j]
    for i in range(len(M3)):
        for j in range(len(M3)):
            M[i+len(M3)][j] = M3[i][j]
    for i in range(len(M4)):
        for j in range(len(M4)):
            M[i+len(M4)][j+len(M4)] = M4[i][j]

    # Убираем лишние нули, если они есть
    if f == 1:
        for i in range (len(M)):
            M[i].pop()
        M.pop()

    return M


#Нахождение обратной матрицы
def MatrixReverse(M):

    #проверка на определитель с помощью третьего задания
    if MatrixDet(M) == 0.0:
        print("\nОбратной матрицы не существует!")
        return

    #Если размер 1х1    
    if (len(M) == 1):
        return [[1/M[0][0]]]

    #Если размер 2х2
    if (len(M) == 2):
        det = M[0][0] * M[1][1] - M[0][1] * M[1][0]
        R = [[0 for j in range (len(M))] for i in range (len(M))]
        R[0][0] = 1 / det * M[1][1] 
        R[0][1] = -1 / det * M[0][1] 
        R[1][0] = -1 / det * M[1][0] 
        R[1][1] = 1 / det * M[0][0] 
        return R    

    #Разбиение на окаймляющие блоки
    line = int(len(M) - 1)
    end = len(M)
    A1 = [[M[i][j] for j in range (line)] for i in range (line)]
    A2 = [[M[i][j] for j in range (line, end)] for i in range (line)]
    A3 = [[M[i][j] for j in range (line)] for i in range (line, end)]
    A4 = [[M[end - 1][end - 1]]]

    #Вычисление нужных блоков
    #Формулы для нужных матриц
    revA1 = MatrixReverse(A1)
    X = MatrixCom(revA1, A2)
    Y = MatrixCom(A3, revA1)
    O = MatrixDiff(A4, MatrixCom(A3, X))
    revO = MatrixReverse(O)

    #Формулы для клеток B
    B1 = MatrixSum(revA1, MatrixCom(MatrixCom(X, revO), Y))
    B2 = MatrixCom(MatrixNeg(X), revO)
    B3 = MatrixCom(MatrixNeg(revO), Y)
    B4 = revO


    for i in range(len(B1)):
        for j in range(len(B1[0])):
            M[i][j] = B1[i][j]
    for i in range(len(B2)):
        for j in range(len(B2[0])):
            M[i][j+len(B2)] = B2[i][j]
    for i in range(len(B3)):
        for j in range(len(B3[0])):
            M[i + len(B3[0])][j] = B3[i][j]
    for i in range(len(B4)):
        for j in range(len(B4[0])):
            M[end - 1][end - 1] = B4[i][j]

    return M


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
    return det


#Запуск задания 1
def Laba1():
    M1 = MatrixInput()
    if len(M1) != len(M1[0]):
        print("Первая матрица не квадратная!")
        return
    M2 = MatrixInput()
    if len(M2) != len(M2[0]):
        print("Вторая матрица не квадратная!")
        return
    print("Введенные матрицы:")
    MatrixOutput(M1)
    print()
    MatrixOutput(M2)
    print()
    if len(M1) != len(M2):
        print("Матрицы не согласованы!")
        return
    print("Произведение матриц:")
    M = BlockMatrixCom(M1, M2)
    if (M != None):
        MatrixOutput(M)

#Запуск задания 2
def Laba2():
    M = MatrixInput()
    print("Введенная матрица")
    MatrixOutput(M)
    print("Обратная матрица:")
    M = MatrixReverse(M)
    if (M != None):
        MatrixOutput(M)

#Запуск задания 3
def Laba3():
    M = MatrixInput()
    print("Введенная матрица")
    MatrixOutput(M)
    print("Определитель: ", MatrixDet(M))


#Мейн
while True:
    print("\nВведите номер задания:")
    a = input()
    if a == '1': Laba1()
    elif a == '2': Laba2()
    elif a == '3': Laba3()
    elif a == '0': break
    else: print("Неправильный номер.")


