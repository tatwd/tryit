import tensorflow as tf

# close the warning: Your CPU supports instructions that this TensorFlow binary was not compiled to use: AVX2
import os
os.environ['TF_CPP_MIN_LOG_LEVEL'] = '2'

# 常量
a = tf.constant(2.5)
print(a)
b = tf.constant(2, dtype=tf.int32)
print(b)

# 变量
c = tf.Variable(10, name='var')
print(c)

# use `Session`
session = tf.Session()
val1 = session.run(b)
print(val1)

# must init a variable before using
init = tf.global_variables_initializer()
session.run(init)
val2 = session.run(c)
print(val2)

# close session
session.close()

# use `Session` by `with`
session2 = tf.Session()
with session2:
    print(session2.run(b))

print(session._closed)
print(session2._closed)


"""

tensorflow: tensor (张量) + graphs （计算图)

+---------------------------------------------+
|           +------+       +------+           |
|   tensor  |   A  |       |   B  |  tensor   |
|           +------+       +------+           |
|               \            /                |
|                \ ________ /                 |
|                     |                       |
|                     Y                       |
|                +----------+                 |
|                | operator |                 |
|                +----------+                 |
|                     |                       |
|                     Y                       |
|                +---------+                  |
|                |    C    | graphs           |
|                +---------+                  |
|                                 Session     |
+---------------------------------------------+

"""

# 常量四则运算
res1 = tf.add(a, a)
res2 = tf.subtract(a, a)
res3 = tf.multiply(a, a)
res4 = tf.divide(a, a)
print("Start a session ...")
with tf.Session() as session:
    print(session.run(res1))
    print(session.run(res2))
    print(session.run(res3))
    print(session.run(res4))
print('End!')


# 变量四则运算
x = tf.constant(1)
y = tf.Variable(3)

res1 = tf.add(x, y)
# print(type(res1))

# copy `res1` to `x`
_res = tf.assign(y, res1)  # res1 => y
# print(type(_res))

res2 = tf.subtract(x, y)
res3 = tf.multiply(x, y)
res4 = tf.divide(x, y)
init = tf.global_variables_initializer()
print("Start a session ...")
with tf.Session() as session:
    session.run(init)  # must run init
    print(session.run(res1))
    print(session.run(res2))
    print(session.run(res3))
    print(session.run(res4))

    # run a graph by defferent ways
    print('session.run(_res)', session.run(_res))  # now y is 4
    print('_res.eval()', _res.eval())  # now y is 5
    print('tf.get_default_session().run(_res)',
          tf.get_default_session().run(_res))  # now y is 6

print('End!')


# Use `placeholder`
p1 = tf.placeholder(tf.float32)
p2 = tf.placeholder(tf.float32)
sum = tf.add(p1, p2)
print("Start a session ...")
with tf.Session() as session:
    # add `feed_dict` to init placeholders
    print(session.run(sum, feed_dict={
        p1: 2,
        p2: 3
    }))
print('End!')
