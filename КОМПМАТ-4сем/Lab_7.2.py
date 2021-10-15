import math

import numpy as np
import matplotlib.pyplot as plt
import pylab


# Метод Эйлера
def solve_eyler(y0, dy0, x, h, ddy):
    y = np.zeros(len(x))
    dy = np.zeros(len(x))
    y[0] = y0
    dy[0] = dy0

    for i in range(1, len(x)):
        y[i] = y[i - 1] + h * dy[i - 1]
        dy[i] = dy[i - 1] + h * ddy(x[i - 1], y[i - 1], dy[i - 1])
    return y


# Метод Эйлера с пересчетом
def solve_eyler_up(y0, dy0, x, h, ddy):
    y = np.zeros(len(x))
    dy = np.zeros(len(x))
    y[0] = y0
    dy[0] = dy0

    for i in range(1, len(x)):
        y[i] = y[i - 1] + (h / 2) * (2 * dy[i - 1] + h * ddy(x[i - 1], y[i - 1], dy[i - 1]))
        dy[i] = dy[i - 1] + (h / 2) * (
                ddy(x[i - 1], y[i - 1], dy[i - 1]) + ddy(x[i], y[i - 1] + h * ddy(x[i - 1], y[i - 1], dy[i - 1]),
                                                         dy[i - 1] + h * ddy(x[i - 1], y[i - 1], dy[i - 1])))
    return y


# Метод Рунге-Кутта 4 порядка
def solve_runge(y0, dy0, x, h, ddy):
    y = np.zeros(len(x))
    dy = np.zeros(len(x))
    y[0] = y0
    dy[0] = dy0

    for i in range(1, len(x)):

        k1 = ddy(x[i - 1], y[i - 1], dy[i - 1])
        k2 = ddy(x[i - 1] + h / 2, y[i - 1] + h * k1 / 2, dy[i - 1] + h * k1 / 2)
        k3 = ddy(x[i - 1] + h / 2, y[i - 1] + h * k2 / 2, dy[i - 1] + h * k2 / 2)
        k4 = ddy(x[i - 1] + h, y[i - 1] + h * k3, dy[i - 1] + h * k3)

        t1 = dy[i - 1]
        t2 = dy[i - 1] + h * k1 / 2
        t3 = dy[i - 1] + h * k2 / 2
        t4 = dy[i - 1] + h * k3

        y[i] = y[i - 1] + h * (t1 + 2 * t2 + 2 * t3 + t4) / 6
        dy[i] = dy[i - 1] + h * (k1 + 2 * k2 + 2 * k3 + k4) / 6

    return y


# Метод Адамса
def solve_adams(y0, dy0, x, h, ddy):
    y = np.zeros(len(x))
    dy = np.zeros(len(x))
    y[0] = y0
    dy[0] = dy0

    for i in range(4):
        k1 = ddy(x[i], y[i], dy[i])
        l1 = dy[i]
        k2 = ddy(x[i] + h / 2, y[i] + l1 / 2, dy[i] + h * k1 / 2)
        l2 = dy[i] + h * k1 / 2
        k3 = ddy(x[i] + h / 2, y[i] + h * l2 / 2, dy[i] + h * k2 / 2)
        l3 = dy[i] + h * k2 / 2
        k4 = ddy(x[i] + h, y[i] + h * l3, dy[i] + h * k3)
        l4 = dy[i] + h * k3

        y[i + 1] = y[i] + h * (l1 + l4 + 2 * l2 + 2 * l3) / 6
        dy[i + 1] = dy[i] + h * (k1 + k4 + 2 * k2 + 2 * k3) / 6

    for i in range(4, len(x)):
        dy[i] = dy[i - 1] + h / 24 * (
                55 * ddy(x[i - 1] - h, y[i - 1], dy[i - 1]) - 59 * ddy(x[i - 2] - 2 * h, y[i - 2],
                                                                       dy[i - 2]) + 37 * ddy(
            x[i - 3] - 3 * h, y[i - 3], dy[i - 3]) - 9 * ddy(x[i - 4] - 4 * h, y[i - 4], dy[i - 4]))
        y[i] = y[i - 1] + h / 24 * (
                55 * dy[i - 1] - 59 * dy[i - 2] + 37 * dy[i - 3] - 9 * dy[i - 4])
    return y



y = lambda x: (1 / x) * (1 + math.exp((x ** 2) / 2))
y2 = [2.39561243, 2.63941244, 2.93781678, 3.2987242, 3.73318016, 4.24035326, 4.85351094, 5.585372, 6.46927026,
      7.54112143, 8.85154461]
y0 = 1 + math.exp(1 / 3)
dy0 = 2 * math.exp(1 / 2) - 1
h = 0.1
x = np.arange(1, 2 + h, h)
ddy = lambda x1, y1, dy1: (x1 * (x1 ** 2 - 1) * dy1 + (x1 ** 2 + 1) * y1) / (x1 ** 2)
f = lambda x1, y1, dy1: dy1

# Метод Эйлера
pylab.subplot(2, 2, 1)
pylab.plot(x, y2, 'b', label="точное решение")
pylab.plot(x, solve_eyler(y0, dy0, x, h, ddy)[:len(x)], 'r', label="решение методом Эйлера")
plt.legend(loc=2, prop={'size': 8})
plt.xlabel('x')
plt.ylabel('y')

# Метод Эйлера с пересчетом
pylab.subplot(2, 2, 3)
pylab.plot(x, y2, 'b', label="точное решение")
pylab.plot(x, solve_eyler_up(y0, dy0, x, h, ddy)[:len(x)], 'r', label="решение методом Эйлера с пересчетом")
plt.legend(loc=2, prop={'size': 8})
plt.xlabel('x')
plt.ylabel('y')

# Метод Рунге-Кутта 4 порядка
pylab.subplot(2, 2, 2)
pylab.plot(x, y2, 'b', label="точное решение")
pylab.plot(x, solve_runge(y0, dy0, x, h, ddy)[:len(x)], 'r', label="решение методом Рунге-Кутта")
plt.legend(loc=2, prop={'size': 8})
plt.xlabel('x')
plt.ylabel('y')

# Метод Адамса
pylab.subplot(2, 2, 4)
pylab.plot(x, y2, 'b', label="точное решение")
pylab.plot(x, solve_adams(y0, dy0, x, h, ddy)[:len(x)], 'r', label="решение методом Адамса")
plt.legend(loc=2, prop={'size': 8})
plt.xlabel('x')
plt.ylabel('y')

plt.show()

