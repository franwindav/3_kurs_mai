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

#Вывод полинома
def PolinomOutput(poly):
    s = ""
    if len(poly) == 1:
        print(poly[0])
    elif len(poly) < 1:
        print("0")
    else:
        for i in range(len(poly)):
            if len(poly)-1-i == 1:
                if poly[i] == 1:
                    s += " + " + "\u03BB"
                if poly[i] == -1:
                    s += " - " + "\u03BB"
                if poly[i] < 0 and poly[i] != -1:
                    s += " - " + str(-1*poly[i])+ "\u03BB"
                elif poly[i] > 0 and poly[i] != 1:
                    s += " + " + str(poly[i]) + "\u03BB"
                else: continue

            elif len(poly)-1-i == 0:
                if poly[i] < 0:
                    s += " - " + str(-1*poly[i])
                elif poly[i] > 0:
                    s += " + " + str(poly[i])
                else: continue

            else:
                if poly[i] == 1:
                    s += " + " + "\u03BB" + degree(len(poly)-1-i)
                if poly[i] == -1:
                    s += " - " + "\u03BB" + degree(len(poly)-1-i)
                if poly[i] < 0 and poly[i] != -1:
                    s += " - " + str(-1*poly[i]) + "\u03BB" + degree(len(poly)-1-i)
                elif poly[i] > 0 and poly[i] != 1:
                    s += " + " + str(poly[i]) + "\u03BB" + degree(len(poly)-1-i)
                else: continue
        if s[1] == '+':
         print(s[3:])
        else: print(s[1:])

#Работа со степенями
indexes = {"0": "\u2070",
           "1": "\u00B9",
           "2": "\u00B2",
           "3": "\u00B3",
           "4": "\u2074",
           "5": "\u2075",
           "6": "\u2076",
           "7": "\u2077",
           "8": "\u2078",
           "9": "\u2079",
           }
def degree(a: int):
    degrees = ""
    s = str(a)
    for char in s:
        degrees += indexes[char] or ""
    return degrees

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


#Характеристический полином
def Laverie(M):
    #итоговый массив
    p = [1.0]
    #массив матриц
    Ms = [M]
    #заполняем его матрицами в степенях
    for i in range(len(M) - 1):
        A_k = MatrixCom(Ms[-1], M)
        Ms.append(A_k)
    #нахождение чисел s
    s = [0 for i in range(len(Ms))]
    i = 0
    for m in Ms:
        for j in range(len(Ms)):
            s[i] += m[j][j]
        i += 1
    #нахождение чисел 
    for i in range(1, len(s) + 1):
        p_i = 0
        for j in range(i):
            p_i += s[i - j - 1] * p[j]
        tmp = (-1/i) * p_i
        p.append(tmp)

    return p

#Максимально собственное значение матрицы 3х3
def MatrixSZ(A):
    e = 0.001  #точность
    y = [[1], [1], [1]]     #начальный вектор
    
    #Находим А^2у, Ау и собств значение
    Ay1 = MatrixCom(A, y)
    A_st = MatrixCom(A, A)
    Ay2 = MatrixCom(A_st, y)
    lyam1 = (Ay2[0][0] / Ay1[0][0] + Ay2[1][0] / Ay1[1][0] + Ay2[2][0] / Ay1[2][0]) / 3

    #Находим А^3у, А^2уи собств значение
    Ay1 = Ay2
    A_st = MatrixCom(A_st, A)
    Ay2 = MatrixCom(A_st, y)
    lyam2 = (Ay2[0][0] / Ay1[0][0] + Ay2[1][0] / Ay1[1][0] + Ay2[2][0] / Ay1[2][0]) / 3

    while lyam2 - lyam1 > e:
        e1 = lyam2 - lyam1
        lyam1 = lyam2
        Ay1 = Ay2
        A_st = MatrixCom(A_st, A)
        Ay2 = MatrixCom(A_st, y)
        lyam2 = (Ay2[0][0] / Ay1[0][0] + Ay2[1][0] / Ay1[1][0] + Ay2[2][0] / Ay1[2][0]) / 3
        e2 = lyam2 - lyam1
        e = (e1 + e2) / 2
    return round(lyam2, 3)


#Запуск задания 1
def Laba1():
    M = MatrixInput()
    print("Введенная матрица:")
    MatrixOutput(M)
    print("Характеристический полином: ", end = '')
    PolinomOutput(Laverie(M))

#Запуск задания 2
def Laba2():
    M = MatrixInput()
    print("Введенная матрица:")
    MatrixOutput(M)
    print("Максимальное собственное значение: ", MatrixSZ(M))


    #Мейн
while True:
    print("\nВведите номер задания:")
    a = input()
    if a == '1': Laba1()
    elif a == '2': Laba2()
    elif a == '0': break
    else: print("Неправильный номер.")