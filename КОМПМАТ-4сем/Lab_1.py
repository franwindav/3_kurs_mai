# Лаба 1
# [-5,-1,3,-2,5],             -1             ответ 6
# [-3,-2,0,-2,1],             1.3            ответ −14.562
# [-0.9,2.1,3.7,-2.4,0.8],     3             ответ 10.7
# Лаба 2
# [3,1,-8,0,8,7,6],                     -2      ответ [3,−5,2,−4,16,−25]
# [8,-7,28,-5,-40,10,-3,-28,-17,-9],     1      ответ [8,1,29,24,−16,−6,−9,−37,−54]
# [1,-1,-6,4,8],                         2      ответ [1,1,−4,−4]
# Лаба 3
# [1,-8,5,2,-7],               2               ответ [1,0,−19,−42,−31]
# [1,-3,-12,52,-48],           3               ответ [1,9,15,7,0]
# [1,13,57,83,-34,-120,0],    -1               ответ [1,7,7,−35,−56,28,48]
# Лаба 4
# [1,0,-12,-16,0]               ответ  -4  4
# [2,-13,1,103,-183,90]         ответ  -3  7
# [-2,-13,-13,28]               ответ  -7  1
# [0,0,5,-16,-45,0]             ответ  -2  5
# Лаба 5
# [1,-7,7,15,0,0,0]             ответ  5, 3, -1, 0, 0, 0
# [4,0,-95,75,226,-120]         ответ  -5, 4, -1.5, 2, 0.5
# [1,3,-14,-30,49,27,-36]       ответ  -4, -3, 3, -1, 1, 1

#Ввод полинома
def polyInput():
    print("Введите коэффициенты полинома: ")
    PolIn = list(map(float, input().split(',')))
    size = len(PolIn) - 1
    i = 0
    while PolIn[i] == 0: 
        size = size - 1
        i = i + 1
    print("Степень многочлена:", size)
    return PolIn


#Схема Горнера
def Scheme(poly, a):
    output = [poly[0]]
    for i in range(len(poly) - 1):
        output.append(a * output[i] + poly[i + 1])
    return output

#Вычисления лабы 1
def Lab_1(poly, a):
    poly = Scheme(poly, a)
    return round(poly[len(poly) - 1], 3)

#Вычисления лабы 2
def Lab_2(poly, a):
    poly = Scheme(poly, a)
    poly.pop(len(poly) - 1)
    return poly

#Вычисления лабы 3
def Lab_3(poly, a):
    poly_out = []
    for j in range(len(poly)):
        temp = Scheme(poly, a)
        poly_out.append(temp[-1])
        poly = temp[0:len(temp) - 1]
    poly_out.reverse()
    return poly_out

#Вычисления лабы 4
def Lab_4(poly):
    answer = [0, 0]

    if poly[0] < 0: poly = [i * -1 for i in poly]
    for i in range(1000000):
        temp = Scheme(poly, i)
        f = True
        for j in temp:
            if j < 0:
                f = False
                break
        if f == True:
            answer[1] = i
            break

    poly = [i * (-1) ** (len(poly) - 1) for i in poly]
    for i in range(len(poly)):
        poly[i] = poly[i] * (-1) ** (len(poly) - i - 1)
    for i in range(1000000):
        temp = Scheme(poly, i)
        f = True
        for j in temp:
            if j < 0:
                f = False
                break
        if f == True:
            answer[0] = -1 * i
            break

    return answer


#Проверка на наличие корней и нахождение нужного интервала
def CheckRoots(poly, b):
    result = [0,0,0]
    result[1] = b[1]
    up = Lab_1(poly, b[1])
    tmp2 = b[0]
    while tmp2 < b[1]:
        if (Lab_1(poly, tmp2) * up > 0):
            tmp2 = tmp2 + 0.0001
        else:
            result[0] = tmp2
            result[2] = 1
            break
    return result

#Вычисления лабы 5
def Lab_5(poly):
    result = []
    bs = Lab_4(poly)
    int = CheckRoots(poly, bs)
    while int[2] == 1:
        a = bs[0]
        b = bs[1]
        c = a
        eps = 0.00000001
        if abs(a) == abs(b):
            c = a
        if Lab_1(poly, 0) == 0:
            result.append(0)
            poly = Lab_2(poly, 0)
            int = CheckRoots(poly, bs)
            continue
        if Lab_1(poly, int[0]) == 0:
            result.append(int[0])
            poly = Lab_2(poly, int[0])
            int = CheckRoots(poly, bs)
            continue
        if Lab_1(poly, int[1]) == 0:
            result.append(int[1])
            poly = Lab_2(poly, int[1])
            int = CheckRoots(poly, bs)
            continue
        if int[2] != 1:
            break
    #метод дихотомии
        while abs(b - a) >= eps:
            c = (a + b) / 2
            if Lab_1(poly, c) == 0:
                break
            elif (Lab_1(poly, a) * Lab_1(poly, c)) < 0:
                b = c
            else:
                a = c
        result.append(c)
        poly = Lab_2(poly, c)
        int = CheckRoots(poly, bs)
    return result

#Вывод полинома
def polyOutput(poly):
    s = ""
    for i in range(len(poly)):

        if len(poly)-1-i == 1:
            if poly[i] == 1:
                s += " + " + "x"
            if poly[i] == -1:
                s += " - " + "x"
            if poly[i] < 0 and poly[i] != -1:
                s += " - " + str(-1*poly[i])+ "x"
            elif poly[i] > 0 and poly[i] != 1:
                s += " + " + str(poly[i]) + "x"
            else: continue

        elif len(poly)-1-i == 0:
            if poly[i] < 0:
                s += " - " + str(-1*poly[i])
            elif poly[i] > 0:
                s += " + " + str(poly[i])
            else: continue

        else:
            if poly[i] == 1:
                s += " + " + "x" + degree(len(poly)-1-i)
            if poly[i] == -1:
                s += " - " + "x" + degree(len(poly)-1-i)
            if poly[i] < 0 and poly[i] != -1:
                s += " - " + str(-1*poly[i]) + "x" + degree(len(poly)-1-i)
            elif poly[i] > 0 and poly[i] != 1:
                s += " + " + str(poly[i]) + "x" + degree(len(poly)-1-i)
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


#Запуск лабы 1
def Laba1():
    poly = polyInput()
    print("Введенный полином: ", end='')
    polyOutput(poly)
    a = float(input("Введите a: "))
    ans = Lab_1(poly, a)
    print("Ответ:", ans)

#Запуск лабы 2
def Laba2():
    poly = polyInput()
    print("Введенный полином: ", end='')
    polyOutput(poly)
    a = float(input("Введите a: "))
    ans = Lab_2(poly, a)
    print("Ответ: ", end='')
    polyOutput(ans)

#Запуск лабы 3
def Laba3():
    poly = polyInput()
    print("Введенный полином: ", end='')
    polyOutput(poly)
    a = float(input("Введите a: "))
    ans = Lab_3(poly, a)
    print("Ответ: ", end='')
    polyOutput(ans)

#Запуск лабы 4
def Laba4():
    poly = polyInput()
    print("Введенный полином: ", end='')
    polyOutput(poly)
    answer = Lab_4(poly)
    print("Вверхняя граница:", answer[1])
    print("Нижняя граница:", answer[0])

#Запуск лабы 5
def Laba5():
    poly = polyInput()
    print("Введенный полином: ", end='')
    polyOutput(poly)
    print("Корни: ")
    ans = Lab_5(poly)
    if len(ans) == 0: print("Нет действительных корней")
    else:
        for i in ans:
            print(round(i,2))

#Мейн
while True:
    print("\nВведите номер задания:")
    a = input()
    if a == '1': Laba1()
    elif a == '2': Laba2()
    elif a == '3': Laba3()
    elif a == '4': Laba4()
    elif a == '5': Laba5()
    elif a == '0': break
    else: print("Неправильный номер.")
