import numpy as np

x = np.array([[1, 2], [3, 4]], dtype=np.float64)
y = np.array([[5, 6], [7, 8]], dtype=np.float64)


print(x + y)
print(np.add(x, y))

print(x - y)
print(np.subtract(x, y))

# Elementwise product; both produce the array
# 不是矩阵的乘法运算
print(x * y)
print(np.multiply(x, y))

# 使用 dot 方法算乘法结果
# dot 内积或点积
print(np.dot(x, y))

print(x / y)
print(np.divide(x, y))

print(np.sqrt(x))

# Compute sum of all elements
print(np.sum(x))

# Compute sum of each column
print(np.sum(x, axis=0))

# Compute sum of each row
print(np.sum(x, axis=1))

# 矩阵转置
print(x.T)
