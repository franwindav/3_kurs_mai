import numpy as np

def sgn(x):
    return "+" if x > 0 else "-"

def Laba1():
    def get_pow(k):
        if k == 0:
            return ""
        else:
            return f"x{k}"

    # получить запись уравнения (по списку коэффициентов)
    def get_pol_str(coeffs):
        ans = ""
        n = 1
        for i, coeff in enumerate(coeffs):

            if i == len(coeffs) - 1:
                ans += f" = {coeff}"
                break
            if coeff == 0:
                n += 1
                continue
            if abs(coeff) == 1:
                ans += f"{sgn(coeff)} 1" if i == len(coeffs) - 1 else f"{sgn(coeff)} x{n} "
            elif i == len(coeffs) - 1:
                ans += f"{sgn(coeff)} {abs(coeff)} x{n} "
            else:
                ans += f"{sgn(coeff)} {abs(coeff)}*x{n} "
            n += 1

        ans = ans.lstrip("+")
        return (ans)

    # Преобразовать строку в матрицу
    def get_mat(s):
        mat = [line.split() for line in s.split(';')]
        return np.array(mat).astype(float)

    # Перестановка столбцов матрицы
    def swap_columns(mat):
        n = 0
        for i in range(len(mat)):
            if mat[0, i] != 0:
                n = i
                break
        temp = np.copy(mat[:, 0])
        mat[:, 0] = mat[:, n]
        mat[:, n] = temp

    # Приведение матрицы к верхне-треугольному виду
    def triang_mat(mat):
        for k in range(len(mat) - 1):
            for i in range(k + 1, len(mat)):
                if mat[k, i] == 0:
                    swap_columns(mat)
                mat[i, :] = mat[i, :] - mat[k, :] * mat[i, k] / mat[k, k]
        return mat

    # Метод Гаусса
    def solveGauss(mat):
        # Преобразуем матрицу в верхнюю треугольную (прямой ход)
        mat = triang_mat(mat)
        # Обратный ход
        x = []
        x.append(mat[len(mat) - 1, len(mat[0]) - 1] / mat[len(mat) - 1, len(mat[0]) - 2])
        for i in range(1, len(mat)):
            n = 1
            for elem in x:
                mat[len(mat) - 1 - i, len(mat[0]) - 1] -= elem * mat[len(mat) - 1 - i, len(mat[0]) - 1 - n]
                n += 1
            x.append(mat[len(mat) - 1 - i, len(mat[0]) - 1] / mat[len(mat) - 1 - i, len(mat[0]) - 2 - len(x)])
        return list(reversed(x))

    if __name__ == '__main__':
        print("Введите расширенную матрицу системы")
        str = input()
        matrix = get_mat(str)

        # вывод системы уравнений
        print("Система уравнений:")
        for i in range(len(matrix)):
            print(get_pol_str(matrix[i]))

        # вывод решения--------------------------
        print()
        print("Решение системы методом Гаусса:")
        x = solveGauss(np.copy(matrix))
        for i in range(len(x)):
            print(f"x{i + 1} = {x[i]}")

def Laba2():
    def get_pow(k):
        if k == 0:
            return ""
        else:
            return f"x{k}"

    # получить запись полинома (по списку коэффициентов)
    def get_pol_str(coeffs):
        ans = ""
        n = 1
        for i, coeff in enumerate(coeffs):

            if i == len(coeffs) - 1:
                ans += f" = {coeff}"
                break
            if coeff == 0:
                n += 1
                continue
            if abs(coeff) == 1:
                ans += f"{sgn(coeff)} 1" if i == len(coeffs) - 1 else f"{sgn(coeff)} x{n} "
            elif i == len(coeffs) - 1:
                ans += f"{sgn(coeff)} {abs(coeff)} x{n} "
            else:
                ans += f"{sgn(coeff)} {abs(coeff)}*x{n} "
            n += 1

        ans = ans.lstrip("+")
        return (ans)

    # Преобразовать строку в матрицу
    def get_mat(s):
        mat = [line.split() for line in s.split(';')]
        return np.array(mat).astype(float)

    # Метод прогонки
    def solve_pr(mat):
        # Прямой ход
        # Коэффициенты P и Q
        coeffs = np.zeros((len(mat), 2))
        coeffs[0, 0] = (-1) * mat[0, 1] / mat[0, 0]
        coeffs[0, 1] = mat[0, len(mat[0]) - 1] / mat[0, 0]

        for i in range(1, len(mat)):
            coeffs[i, 0] = -mat[i, 1 + i] / (mat[i, i] + mat[i, i - 1] * coeffs[i - 1, 0])
            coeffs[i, 1] = (mat[i, len(mat[0]) - 1] - mat[i, i - 1] * coeffs[i - 1, 1]) / (
                    mat[i, i] + mat[i, i - 1] * coeffs[i - 1, 0])

        # Обратный ход
        x = []
        x.append(coeffs[len(mat) - 1, 1])
        for i in range(1, len(mat)):
            x.append(coeffs[len(coeffs) - 1 - i, 0] * x[i - 1] + coeffs[len(coeffs) - 1 - i, 1])
        return list(reversed(x))

    if __name__ == '__main__':
        print("Введите расширенную матрицу системы")
        str = input()
        matrix = get_mat(str)

        # вывод системы уравнений
        print("Система уравнений:")
        for i in range(len(matrix)):
            print(get_pol_str(matrix[i]))

        # вывод решения--------------------------
        print()
        print("Решение системы методом прогонки:")
        x = solve_pr(np.copy(matrix))
        for i in range(len(x)):
            print(f"x{i + 1} = {x[i]}")

def Laba3():
    # получить запись полинома (по списку коэффициентов)
    def get_pol_str(coeffs):
        ans = ""
        n = 1
        for i, coeff in enumerate(coeffs):
            if i == len(coeffs) - 1:
                ans += f" = {coeff}"
                break
            if coeff == 0:
                n += 1
                continue
            if abs(coeff) == 1:
                ans += f"{sgn(coeff)} 1" if i == len(coeffs) - 1 else f"{sgn(coeff)} x{n} "
            elif i == len(coeffs) - 1:
                ans += f"{sgn(coeff)} {abs(coeff)} x{n} "
            else:
                ans += f"{sgn(coeff)} {abs(coeff)}*x{n} "
            n += 1

        ans = ans.lstrip("+")
        return (ans)

    # Преобразовать строку в матрицу
    def get_mat(s):
        mat = [line.split() for line in s.split(';')]
        return np.array(mat).astype(float)

    # Перестановка строк матрицы в случае если аii=0
    def swap_raws(mat, n):

        k = n + 1
        temp = np.copy(mat[n, :])
        mat[n, :] = mat[k, :]
        mat[k, :] = temp

    # норма матрицы(для метода простой итерации)
    def mat_norm(mat):
        sums = []
        for i in range(len(mat)):
            sum = 0
            for j in range(len(mat[0])):
                sum += abs(mat[i, j])
            sums.append(sum)
        return max(sums)

    # норма вектора
    def vec_norm(vec):
        norm = 0
        for i in range(len(vec)):
            norm += (vec[i]) ** 2
        return norm ** (1 / 2)

    # произведение матрицы и вектора
    def mul(mat, vec):
        res = vec_betta = np.zeros(len(vec))
        for i in range(len(mat)):
            elem = 0
            for j in range(len(mat[0])):
                elem += mat[i, j] * vec[j]
            res[i] = elem
        return res

    # Поиск определителя
    def get_det(mat):
        if len(mat) == 1 and len(mat[0, :]) == 1:
            return mat[0, 0]
        det = 0
        for j in range(len(mat[0, :])):
            det += ((-1) ** (j)) * mat[0, j] * get_det(np.delete(np.delete(mat, 0, axis=0), j, axis=1))
        return det

    # Умножение матриц
    def mul_mats(mat1, mat2):
        res = np.zeros((len(mat1), len(mat2[0])))
        s = 0
        for i in range(len(mat1)):
            for j in range(len(mat2[0])):
                for k in range(len(mat1[0])):
                    s += mat1[i, k] * mat2[k, j]
                res[i, j] = s
                s = 0
        return res

    # нахождение обратной матрицы методом окаймления
    def inv_mat(mat):
        if len(mat) == 1 and len(mat[0]) == 1: return mat / (mat[0, 0] ** 2)
        # если матрица 2х2 то сразу возвращаем обратную:
        if len(mat) == 2 and len(mat[0]) == 2:
            mat_inv = np.zeros((len(mat), len(mat[0])))
            for i in range(len(mat)):
                for j in range(len(mat[0, :])):
                    mat_minor = np.delete(np.delete(mat, i, axis=0), j, axis=1)
                    mat_inv[j, i] = ((-1) ** (j + i)) * get_det(mat_minor)
            return mat_inv / get_det(mat)

        # если больше 2х2 то применяем окаймление,используя обратную матрицу порядка n-1(рекурсия):
        a11_inv = inv_mat(np.delete(np.delete(mat, len(mat) - 1, axis=0), len(mat[0]) - 1, axis=1))
        a22 = np.array([mat[len(mat) - 1, len(mat[0]) - 1]])
        a12 = np.array(mat[0:len(mat) - 1, len(mat[0]) - 1]).reshape(len(mat) - 1, 1)
        a21 = np.array(mat[len(mat) - 1, 0: len(mat[0]) - 1]).reshape(1, len(mat[0]) - 1)

        # находим клетки обратной матрицы(по формулам из Демидовича-Морона)
        x = mul_mats(a11_inv, a12)
        y = mul_mats(a21, a11_inv)
        teta = a22 - mul_mats(a21, x)
        teta_inv = np.array([1 / teta[0, 0]]).reshape(1, 1)

        b11 = a11_inv + mul_mats(mul_mats(x, teta_inv), y)
        b12 = mul_mats(-1 * x, teta_inv)
        b21 = mul_mats(-1 * teta_inv, y)
        b22 = teta_inv

        # Собираем матрицу
        mat_inv = np.concatenate((np.concatenate((b11, b12), axis=1), np.concatenate((b21, b22), axis=1)), axis=0)
        return mat_inv

    # Метод простых итераций
    def solve_iter(mat):
        # проверяем что на главной диагонали нет нулевых элементов(если есть,меняем строки местами)
        for i in range(len(mat)):
            if mat[i, i] == 0:
                swap_raws(mat, i)

        mat_alfa = np.zeros((len(mat), len(mat[0]) - 1))
        for i in range(len(mat_alfa)):
            for j in range(len(mat_alfa[0])):
                if i == j:
                    mat_alfa[i, i] = 0
                else:
                    mat_alfa[i, j] = -mat[i, j] / mat[i, i]

        if mat_norm(mat_alfa) >= 1: raise IOError("Не выполняется условие сходимости")
        # вектор бетта
        vec_betta = np.zeros(len(mat))
        for i in range(len(mat)):
            vec_betta[i] = mat[i, len(mat[0]) - 1] / mat[i, i]

        # найдем решения системы
        x = vec_betta.copy()
        eps = 1
        eps0 = 0.001
        it_count = 1
        while eps > eps0:
            xprev = x.copy()
            x = mul(mat_alfa, xprev) + vec_betta
            # eps = vec_norm(x - xprev)
            eps = mat_norm(mat_alfa) * vec_norm(x - xprev) / (1 - mat_norm(mat_alfa))
            it_count += 1
        return (x, it_count)

    # Метод Зейделя
    def solve_Zey(mat):
        for i in range(len(mat)):
            if mat[i, i] == 0:
                swap_raws(mat, i)

        mat_alfa = np.zeros((len(mat), len(mat[0]) - 1))
        for i in range(len(mat_alfa)):
            for j in range(len(mat_alfa[0])):
                if i == j:
                    mat_alfa[i, i] = 0
                else:
                    mat_alfa[i, j] = -mat[i, j] / mat[i, i]

        if mat_norm(mat_alfa) >= 1: raise IOError("Не выполняется условие сходимости")
        # матрица B нижняя треугольная
        mat_b = np.copy(mat_alfa[:, 0:len(mat[0]) - 1])
        for i in range(len(mat_b)):
            for j in range(len(mat_b[0])):
                if j >= i:
                    mat_b[i, j] = 0

        # матрица C верхняя треугольная
        mat_c = np.copy(mat_alfa[:, 0:len(mat[0]) - 1])
        for i in range(len(mat_b)):
            for j in range(len(mat_b[0])):
                if j < i:
                    mat_c[i, j] = 0

        mat_e = np.diag([1] * len(mat_alfa))

        # вектор бетта
        vec_betta = np.zeros(len(mat_alfa))
        for i in range(len(mat_alfa)):
            vec_betta[i] = mat[i, len(mat[0]) - 1] / mat[i, i]

        # найдем решения системы
        x = vec_betta.copy()
        eps = 1
        eps0 = 0.001
        it_count = 1
        while eps > eps0:
            xprev = x.copy()
            x = mul(mul_mats(inv_mat(mat_e - mat_b), mat_c), xprev) + mul(inv_mat(mat_e - mat_b), vec_betta)
            # eps = vec_norm(x - xprev)
            eps = mat_norm(mat_c) * vec_norm(x - xprev) / (1 - mat_norm(mat_alfa))
            it_count += 1

        return (x, it_count)

    if __name__ == '__main__':
        print("Введите расширенную матрицу системы")
        str = input()
        matrix = get_mat(str)

        # вывод системы уравнений
        print("Система уравнений:")
        for i in range(len(matrix)):
            print(get_pol_str(matrix[i]))

        # вывод решения--------------------------
        print()
        print("Решение системы методом простых итераций:")
        try:
            res, count = solve_iter(np.copy(matrix))
            print(f"количество иитераций: {count}")
            for i in range(len(res)):
                print(f"x{i + 1} = {res[i]}")
        except IOError:
            print("Не выполняется условие сходимости")

        print()
        print("Решение системы методом Зейделя:")
        try:
            res, count = solve_Zey(np.copy(matrix))
            print(f"количество иитераций: {count}")
            for i in range(len(res)):
                print(f"x{i + 1} = {res[i]}")
        except IOError:
            print("Не выполняется условие сходимости")

while True:
    print("\nВведите номер задания:")
    a = input()
    if a == '1': Laba1()
    elif a == '2': Laba2()
    elif a == '3': Laba3()
    elif a == '0': break
    else: print("Неправильный номер.")

