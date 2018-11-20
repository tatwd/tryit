import numpy as np

a = np.array([1, 2, 3])

print(type(a))
print(a.shape)
print(a[0], a[1], a[2])

a[0] = 5
print(a)

"""
    1   4
    2   5
    3   6
or
    1   2   3
    4   5   6
"""
b = np.array([[1, 2, 3], [4, 5, 6]])

# 先列后行或先行后列
print(b.shape)  # (2, 3)
print(b[1, 2])
print(b[0, 0], b[1, 1], b[0, 2])

# Create an array of all zeros
c1 = np.zeros((2, 2))
print(c1)

# Create an array of all ones
c2 = np.ones((1, 2))
print(c2)

# Create a constant array
c3 = np.full((2, 2), 7)
print(c3)

# N 阶单位矩阵
# Create a 2x2 identity matrix
c4 = np.eye(2)
print(c4)

c5 = np.random.random((2, 3))
print(c5)

"""
Indexing Array
"""

d1 = np.array(
    [
        [1,  2,  3,  4],
        [5,  6,  7,  8],
        [9, 10, 11, 12]
    ]
)

d2 = d1[:2, 1:3]
print(d2)

print(d1[0, 1])  # 2
d2[0, 0] = 77  # will change the next column (d2[0, 1]) value
print(d1[0, 0], d1[0, 1])
print(d1)

row_r1 = d1[1, :]
row_r2 = d1[1:2, :]
print(row_r1, row_r1.shape)
print(row_r2, row_r2.shape)

col_r1 = d1[:, 1]
col_r2 = d1[:, 1:2]
print(col_r1, col_r1.shape)
print(col_r2, col_r2.shape)
