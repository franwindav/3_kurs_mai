#Ввод полинома
def PolinomInput():
    print("Введите коэффициенты полинома: ")
    PolIn = list(map(float, input().split(',')))
    size = len(PolIn) - 1
    i = 0
    if size != 0:
        while PolIn[i] == 0:
            size = size - 1
            i = i + 1
    print("Степень многочлена:", size)
    return PolIn

#Ввод двумерных
def PolinomInputXY():
    print("Введите коэффициенты полинома: ")
    tmp = list(map(float, input().split()))
    PolIn = []
    while tmp != []:
        PolIn.append(tmp)
        tmp = list(map(float, input().split()))
    return PolIn

#Вывод полинома
def PolinomOutput(polinom):
    s = ""
    if len(polinom) == 1:
        print(polinom[0])
    elif len(polinom) < 1:
        print("0")
    else:
        for i in range(len(polinom)):
            if len(polinom)-1-i == 1:
                if polinom[i] == 1:
                    s += " + " + "x"
                if polinom[i] == -1:
                    s += " - " + "x"
                if polinom[i] < 0 and polinom[i] != -1:
                    s += " - " + str(-1*polinom[i])+ "x"
                elif polinom[i] > 0 and polinom[i] != 1:
                    s += " + " + str(polinom[i]) + "x"
                else: continue

            elif len(polinom)-1-i == 0:
                if polinom[i] < 0:
                    s += " - " + str(-1*polinom[i])
                elif polinom[i] > 0:
                    s += " + " + str(polinom[i])
                else: continue

            else:
                if polinom[i] == 1:
                    s += " + " + "x" + degree(len(polinom)-1-i)
                if polinom[i] == -1:
                    s += " - " + "x" + degree(len(polinom)-1-i)
                if polinom[i] < 0 and polinom[i] != -1:
                    s += " - " + str(-1*polinom[i]) + "x" + degree(len(polinom)-1-i)
                elif polinom[i] > 0 and polinom[i] != 1:
                    s += " + " + str(polinom[i]) + "x" + degree(len(polinom)-1-i)
                else: continue
        if s[1] == '+':
         print(s[3:])
        else: print(s[1:])

#Вывод двумерных
def PolinomOutputXY(polinom):
    s = ""
    for i in range(len(polinom)):
        for j in range(len(polinom[i])):
            #один коэфициент
            if (i == len(polinom) - 1) and (j == len(polinom[i]) - 1):
                if polinom[i][j] > 0:
                    s += " + " + str(polinom[i][j])
                elif polinom[i][j] < 0:
                    s += " - " + str(-1*polinom[i][j])
                else: continue
            #только Х
            elif i == len(polinom) - 1:
                #без степени
                if j == len(polinom[i]) - 2:
                    if polinom[i][j] == 1:
                        s += " + " + "x"
                    elif polinom[i][j] == -1:
                        s += " - " + "x"
                    elif polinom[i][j] > 0:
                        s += " + " + str(polinom[i][j]) + "x"
                    elif polinom[i][j] < 0:
                        s += " - " + str(-1 * polinom[i][j]) + "x"
                    else: continue
                #cо степенью
                else:
                    if polinom[i][j] == 1:
                        s += " + " + "x" + degree(len(polinom[i]) - j - 1)
                    elif polinom[i][j] == -1:
                        s += " - " + "x" + degree(len(polinom[i]) - j - 1)
                    elif polinom[i][j] > 0:
                        s += " + " + str(polinom[i][j]) + "x" + degree(len(polinom[i]) - j - 1)
                    elif polinom[i][j] < 0:
                        s += " - " + str(-1*polinom[i][j]) + "x" + degree(len(polinom[i]) - j - 1)
                    else: continue
            #только У (аналогично)
            elif j == len(polinom[i])-1:
                #без степени
                if i == len(polinom)-2:
                    if polinom[i][j] == 1:
                        s += " + " + "y"
                    elif polinom[i][j] == -1:
                        s += " - " + "y"
                    elif polinom[i][j] > 0:
                        s += " + " + str(polinom[i][j]) + "y"
                    elif polinom[i][j] < 0:
                        s += " - " + str(-1 * polinom[i][j]) + "y"
                    else: continue
                #со степенью
                else:
                    if polinom[i][j] == 1:
                        s += " + " + "y" + degree(len(polinom) - i - 1)
                    elif polinom[i][j] == -1:
                        s += " - " + "y" + degree(len(polinom) - i - 1)
                    elif polinom[i][j] > 0:
                        s += " + " + str(polinom[i][j]) + "y" + degree(len(polinom) - i - 1)
                    elif polinom[i][j] < 0:
                        s += " - " + str(-1 * polinom[i][j]) + "y" + degree(len(polinom) - i - 1)
                    else:
                        continue
           #с ХУ 
            else:
                #без степени
                if (j == len(polinom[i])-2) and (i == len(polinom)-2):
                    if polinom[i][j] == 1:
                        s += " + " + "xy"
                    elif polinom[i][j] == -1:
                        s += " - " + "xy"
                    elif polinom[i][j] > 0:
                        s += " + " + str(polinom[i][j]) + "xy"
                    elif polinom[i][j] < 0:
                        s += " - " + str(-1 * polinom[i][j]) + "xy"
                    else: continue
                #со степенью у У
                elif j == len(polinom[i])-2:
                    if polinom[i][j] == 1:
                        s += " + " + "x" + "y" + degree(len(polinom) - i - 1)
                    elif polinom[i][j] == -1:
                        s += " + " + "x" + "y" + degree(len(polinom) - i - 1)
                    elif polinom[i][j] > 0:
                        s += " + " + str(polinom[i][j]) + "x" + "y" + degree(len(polinom) - i - 1)
                    elif polinom[i][j] < 0:
                        s += " - " + str(-1 * polinom[i][j]) + "x" + "y" + degree(len(polinom) - i - 1)
                    else: continue
                #со степенью у Х
                elif i == len(polinom)-2:
                    if polinom[i][j] == 1:
                        s += " + " + "x" + degree(len(polinom[i]) - j - 1) + "y"
                    elif polinom[i][j] == -1:
                        s += " - " + "x" + degree(len(polinom[i]) - j - 1) + "y"
                    elif polinom[i][j] < 0:
                        s += " - " + str(-1 * polinom[i][j]) + "x" + degree(len(polinom[i]) - j - 1) + "y"
                    elif polinom[i][j] > 0:
                        s += " + " + str(polinom[i][j]) + "x" + degree(len(polinom[i]) - j - 1) + "y"
                    else: continue
                #степень у Х и у У
                else:
                    if polinom[i][j] == 1:
                        s += " + " + "x" + degree(len(polinom[i]) - j - 1) + "y" + degree(len(polinom) - i - 1)
                    elif polinom[i][j] == -1:
                        s += " - " + "x" + degree(len(polinom[i]) - j - 1) + "y" + degree(len(polinom) - i - 1)
                    elif polinom[i][j] < 0:
                        s += " - " + str(-1 * polinom[i][j]) + "x" + degree(len(polinom[i]) - j - 1) + "y" + degree(len(polinom) - i - 1)
                    elif polinom[i][j] > 0:
                        s += " + " + str(polinom[i][j]) + "x" + degree(len(polinom[i]) - j - 1) + "y" + degree(len(polinom) - i - 1)
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

#Cхема Горнера
def Scheme(polinom, a):
    output = [polinom[0]]
    for i in range(len(polinom) - 1):
        output.append(a * output[i] + polinom[i + 1])
    return output

def Gorner_root(polinom, a):
    polinom = Scheme(polinom, a)
    return round(polinom[len(polinom) - 1], 3)

def Gorner_pol(polinom, a):
    polinom = Scheme(polinom, a)
    polinom.pop(len(polinom) - 1)
    return polinom

#Границы корней
def bounds(polinom):
    result = [0, 0]
    #нахождение верхней границы
    if polinom[0] < 0: polinom = [i * -1 for i in polinom]
    for i in range(1000000):
        temp = Scheme(polinom, i)
        f = True
        for j in temp:
            if j < 0:
                f = False
                break
        if f == True:
            result[1] = i
            break
    #нахождение нижней границы
    polinom = [i * (-1) ** (len(polinom) - 1) for i in polinom]
    for i in range(len(polinom)):
        polinom[i] = polinom[i] * (-1) ** (len(polinom) - i - 1)
    for i in range(1000000):
        temp = Scheme(polinom, i)
        f = True
        for j in temp:
            if j < 0:
                f = False
                break
        if f == True:
            result[0] = -1 * i
            break
    return result

#Проверка на наличие корней и нахождение нужного интервала
def CheckRoots(polinom, b):
    result = [0,0,0]
    result[1] = b[1]
    up = Gorner_root(polinom, b[1])
    tmp2 = b[0]
    while tmp2 < b[1]:
        if (Gorner_root(polinom, tmp2) * up > 0):
            tmp2 = tmp2 + 0.0001
        else:
            result[0] = tmp2
            result[2] = 1
            break
    return result

#Вычисления примера 1
def Lab_1(polinom):
    result = []
    for i in range(0, len(polinom) - 1):
        result.append(polinom[i] * (len(polinom) - i - 1))
    return result

#Вычисления примера 2
def Lab_2(polinom):
    result = []
    int = []
    bs = bounds(polinom)
    int = CheckRoots(polinom,bs)
    while int[2] == 1:
        a = int[0]
        b = a + 0.5
        while abs(a - b) >= 0.00001:
            c = ((-1) * (b - a) * Gorner_root(polinom, a)) / (Gorner_root(polinom, b) - Gorner_root(polinom, a))
            tmp = a + c
            if Gorner_root(polinom, a) * Gorner_root(polinom, tmp) < 0:
                b = tmp
            else:
                a = tmp
            if abs(Gorner_root(polinom, tmp)) < 0.00001:
                break
        result.append(tmp)
        polinom = Gorner_pol(polinom, tmp)
        int = CheckRoots(polinom, bs)
    return result

#Вычисления примера 3
def Lab_3(polinom):
    result = []
    int = []
    bs = bounds(polinom)
    int = CheckRoots(polinom,bs)
    while int[2] == 1:
        a = int[0]
        b = a + 0.5
        root = int[0]
        while abs(a - b) >= 0.00001:
            c = Gorner_root(Lab_1(polinom), root)
            if c != 0:
                root = root - Gorner_root(polinom, root) / c
            else:
                root = root - Gorner_root(polinom, root) / 0.00001
            if abs(Gorner_root(polinom, root)) < 0.00001:
                break
        result.append(root)
        polinom = Gorner_pol(polinom, root)
        int = CheckRoots(polinom, bs)
    return result

#Вычисления примера 4
def Lab_4(polinom, x, y):
    tmp = []
    for i in range (len(polinom)):
        tmp.append(Gorner_root(polinom[i], x))
    return Gorner_root(tmp, y)

#Вычисления примера 5 (производная по Х)
def Lab_5X(polinom):
    ans = [[0 for j in range(len(polinom[i]))] for i in range(len(polinom))]
    for i in range (len(polinom)):
        for j in range (len(polinom[i])):
            ans[i][j] = polinom[i][j] * (len(polinom[i]) - j - 1)
    return [[ans[i][j] for j in range(len(ans[i]) - 1)] for i in range(len(ans))]

#Вычисления примера 5 (производная по Y)
def Lab_5Y(polinom):
    ans = [[0 for j in range(len(polinom[i]))] for i in range(len(polinom))]
    for i in range (len(polinom)):
       for j in range (len(polinom[i])):
            ans[i][j] = polinom[i][j] * (len(polinom) - i - 1)
    return ans[:-1]


#Запуск задания 1
def Laba1():
    polinom = PolinomInput()
    print("Введенный полином: ", end='')
    PolinomOutput(polinom)
    ans = Lab_1(polinom)
    print("Производная от полинома: ", end='')
    PolinomOutput(ans)

#Запуск задания 2
def Laba2():
    polinom = PolinomInput()
    print("Введенный полином: ", end='')
    PolinomOutput(polinom)
    print("Корни: ")
    ans = Lab_2(polinom)
    if len(ans) == 0: print("Нет действительных корней")
    else:
        for i in ans:
            print(round(i,2))

#Запуск задания 3
def Laba3():
    polinom = PolinomInput()
    print("Введенный полином: ", end='')
    PolinomOutput(polinom)
    print("Корни: ")
    ans = Lab_3(polinom)
    if len(ans) == 0: print("Нет действительных корней")
    else:
        for i in ans:
            print(round(i,2))

#Запуск задания 4
def Laba4():
    polinom = PolinomInputXY()
    print("Введенный полином: ", end='')
    PolinomOutputXY(polinom)
    a = float(input("Введите x: "))
    b = float(input("Введите у: "))
    answer = Lab_4(polinom, a, b)
    print("Ответ:", answer)

#Запуск задания 5
def Laba5():
    polinom = PolinomInputXY()
    print("Введенный полином: ", end='')
    PolinomOutputXY(polinom)
    print("Производная по Х: ", end='')
    x = Lab_5X(polinom)
    PolinomOutputXY(x)
    print("Производная по Y: ", end='')
    y = Lab_5Y(polinom)
    PolinomOutputXY(y)


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