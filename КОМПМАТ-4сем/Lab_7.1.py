import math
import numpy as np
import matplotlib.pyplot as plt
import pylab


# Метод Эйлера
def solve_eyler(y0, x, h, dy):
    y = np.zeros(len(x))
    y[0] = y0
    for i in range(1, len(x)):
        y[i] = y[i - 1] + h * dy(x[i - 1], y[i - 1])
    return y


# Метод Эйлера с пересчетом
def solve_eyler_up(y0, x, h, dy):
    y = np.zeros(len(x))
    y[0] = y0
    for i in range(1, len(x)):
        y[i] = y[i - 1] + (h / 2) * (dy(x[i - 1], y[i - 1]) + dy(x[i], y[i - 1] + h * dy(x[i - 1], y[i - 1])))
    return y


# Метод Рунге-Кутта 4 порядка
def solve_runge(y0, x, h, dy):
    y = np.zeros(len(x))
    y[0] = y0
    for i in range(1, len(x)):
        k1 = h * dy(x[i - 1], y[i - 1])
        k2 = h * dy(x[i - 1] + h / 2, y[i - 1] + k1 / 2)
        k3 = h * dy(x[i - 1] + h / 2, y[i - 1] + k2 / 2)
        k4 = h * dy(x[i - 1] + h / 2, y[i - 1] + k3)
        y[i] = y[i - 1] + (k1 + 2 * k2 + 2 * k3 + k4) / 6
    return y


# Метод Адамса 3 порядка
def solve_adams(y0, x, h, dy):
    y = np.zeros(len(x))
    y[0] = y0
    y[1] = y[0] + h * dy(x[0], y[0])
    y[2] = y[1] + h * dy(x[1], y[1])

    for i in range(3, len(x)):
        k1 = h * dy(x[i - 1], y[i - 1])
        k2 = h * dy(x[i - 2], y[i - 2])
        k3 = h * dy(x[i - 3], y[i - 3])
        y[i] = y[i - 1] + (23 * k1 - 16 * k2 + 5 * k3) / 12
    return y


# точное решение
y = lambda x: math.sin(x) - 1 + math.exp(math.sin(x))
y0 = 0
# точки "точного" сравнения для проверки
y2 = [0, 0.00199885, 0.01344618, 0.03299332, 0.05913347, 0.09027973, 0.12483095, 0.16122497, 0.19798034, 0.23372767,
      0.26723244]
h = 0.1
x = np.arange(0, 1 + h, h)
dy = lambda x1, y1: -(y1 * math.cos(x1)) + 1 / 2 * math.sin(2 * x1)

# Построение графиков
# Метод Эйлера
pylab.subplot(2, 2, 1)
pylab.plot(x, y2, 'b', label="точное решение")
pylab.plot(x, solve_eyler(y0, x, h, dy)[:len(x)], 'r', label="решение методом Эйлера")
plt.legend(loc=3, prop={'size': 8})
plt.xlabel('x')
plt.ylabel('y')

# Метод Эйлера с пересчетом
pylab.subplot(2, 2, 3)
pylab.plot(x, y2, 'b', label="точное решение")
pylab.plot(x, solve_eyler_up(y0, x, h, dy)[:len(x)], 'r', label="решение методом Эйлера с пересчетом")
plt.legend(loc=3, prop={'size': 8})
plt.xlabel('x')
plt.ylabel('y')

# Метод Рунге-Кутта 4 порядка
pylab.subplot(2, 2, 2)
pylab.plot(x, y2, 'b', label="точное решение")
pylab.plot(x, solve_runge(y0, x, h, dy)[:len(x)], 'r', label="решение методом Рунге-Кутта")
plt.legend(loc=3, prop={'size': 8})
plt.xlabel('x')
plt.ylabel('y')

# Метод Адамса 3 порядка
pylab.subplot(2, 2, 4)
pylab.plot(x, y2, 'b', label="точное решение")
pylab.plot(x, solve_adams(y0, x, h, dy)[:len(x)], 'r', label="решение методом Адамса")
plt.legend(loc=3, prop={'size': 8})
plt.xlabel('x')
plt.ylabel('y')

plt.show()
