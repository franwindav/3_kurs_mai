import numpy as np
import math

def mat(p):
    mat = []
    for line in p.split(';'):
        mat.append(line.split())
    return np.array(mat).astype(float)

m = '9 -5 -6 3 -8; 1 -7 1 0 38; 3 -4 9 0 47; 6 -1 9 8 -8'
m = mat(m)
print('Матрица коэффициентов: \n',m)

for k in range(len(m[0]) - 1):
    if m[k, k] == 0:
        for j in range(len(m[1])):
            m[k, j], m[k + 1, j] = m[k + 1, j], m[k, j]
    for i in range(k + 1,len(m[0]) - 1):
        r = m[i, k]
        for j in range(k, len(m[1])):
            m[i, j] = m[i, j] - m[k, j] * r / m[k, k]

for i in range(len(m[0]) - 1):
    for j in range(len(m[1])):
        m[i, j] = round(m[i, j], 4)
Res = np.zeros(len(m[0]) - 1)
s = 0

#отделяем ответы
for i in range(len(m[0]) - 2, -1, -1):
    for j in range(len(m[0]) - 1):
        s += Res[j] * m[i, j]
    Res[i] = round((m[i, len(m[0]) - 1] - s) / m[i, i], 2)
    s = 0
print('Метод Гаусса:')
for i in range(len(Res)):
    print('x' + str(i) + ' = ' + str(Res[i]))