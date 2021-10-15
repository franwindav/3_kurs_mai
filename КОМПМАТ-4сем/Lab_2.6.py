from itertools import zip_longest

def sgn(x):
    return "+" if x.real >= 0 else "-"


def get_pow(k, arg):
    if k == 0:
        return ""
    elif k == 1:
        return arg
    else:
        return f"{arg}^{k}"


def parse_complex(number):
    res = {}

    res['all_sgn'] = sgn(number.real)

    if number.real < 0:
        number *= -1

    res['real'] = str(abs(number.real))
    res['imag_sgn'] = sgn(number.imag)
    res['imag'] = str(abs(number.imag))

    return res


def poluch_coeff(coeff: complex, last: bool):
    parsed = parse_complex(coeff)
    res = ''

    if coeff.real != 0:
        res += parsed['all_sgn']

        if coeff != 1 or last:
            res += '('
            res += parsed['real']

        if coeff.imag != 0:
            res += parsed['imag_sgn']
            res += parsed['imag']
            res += 'i'

        if coeff != 1 or last:
            res += ')'
    else:
        res += parsed['imag_sgn']
        res += '('
        res += parsed['imag']
        res += 'i'
        res += ')'
    return res


def print_pol(polynomial, arg='x', add_arg=''):
    res = ''
    degree = len(polynomial) - 1
    for i, coeff in enumerate(polynomial):
        if coeff == 0:
            continue
        res += poluch_coeff(coeff, last=(i == degree))
        res += get_pow(degree - i, arg)
        res += add_arg
    res = res.strip()
    return res


def print_pol_two(polynomial):
    res = ''
    degree = len(polynomial) - 1
    for i, row in enumerate(polynomial):
        res += print_pol(row, add_arg=get_pow(degree - i, arg="y")) + " "
    return res


def transpose(polynomial):
    return [list(i) for i in zip(*polynomial)]

#производная
def proizvod(polynomial):
    ans = []
    degree = len(polynomial) - 1
    if degree < 1:
        return [0]
    for coeff in polynomial[:-1]:
        ans.append(coeff*degree)
        degree -= 1
    return ans

#частная производная двумерн
def chastn_proizvod_two(polynomial, mode='x'):
    ans = []
    if mode == 'y':
        polynomial = transpose(polynomial)
    for row in polynomial:
        ans.append(proizvod(row))
    return ans if mode == 'x' else transpose(ans)


def gorner(polynomial, ksi):
    ans = [polynomial[0]]
    for i in range(len(polynomial) - 1):
        ans.append(polynomial[i + 1] + ans[i] * ksi)
    return ans[-1]

#двумерный горнер
def two_gorner(polynomial, x0, y0):
    coeffs = []
    for row in polynomial:
        coeffs.append(gorner(row, x0))
    return gorner(coeffs, y0)


def newton(real_pol, complex_pol, x, y, epsilon=0.001):
    f1 = lambda x, y: two_gorner(real_pol, x, y)
    f2 = lambda x, y: two_gorner(complex_pol, x, y)

    #найдем частные производные функций
    DFSS = [
        lambda x, y: two_gorner(chastn_proizvod_two(real_pol, mode='x'), x, y),
        lambda x, y: two_gorner(chastn_proizvod_two(real_pol, mode='y'), x, y),
        lambda x, y: two_gorner(chastn_proizvod_two(complex_pol, mode='x'), x, y),
        lambda x, y: two_gorner(chastn_proizvod_two(complex_pol, mode='y'), x, y)
    ]
    #
    x_old = 0
    y_old = 0

    #приближение к корню
    f1x_next = f1(x, y)
    f2x_next = f2(x, y)

    #продолжение приближения с заданной точностью
    while abs(x_old - x) + abs(y_old - y) > epsilon:
        values = []
        for df in DFSS:
            values.append(df(x, y))
        x_old = x
        y_old = y
        #x=x-(f/J)
        x = x + (-f1x_next * values[3] + f2x_next * values[1]) / (values[0] * values[3] - values[1] * values[2])
        y = y + (f1x_next * values[2] - f2x_next * values[0]) / (values[0] * values[3] - values[1] * values[2])
        f1x_next = f1(x, y)
        f2x_next = f2(x, y)
    return round(x, 4), round(y, 4)

print("Введите действительную матрицу:")
real_pol = []
inp = input()
while inp:
    real_pol.append([float(x) for x in inp.split()])
    inp = input()

print("Введите комплексную матрицу:")
complex_pol = []
inp = input()
while inp:
    complex_pol.append([float(x) for x in inp.split()])
    inp = input()

print("Введите примерные корни матрицы:")
x, y = map(float,input().split())

polynom = []
for re_row, comp_row in zip_longest(real_pol, complex_pol, fillvalue=[]):
    result_row = []
    for re, compl in zip_longest(re_row, comp_row, fillvalue=0):
        result_row.append(complex(re, compl))
    polynom.append(result_row)

print("F(x, y) = ", print_pol_two(polynom).lstrip('+'))
print("Ответ: ", newton(real_pol, complex_pol, x, y))