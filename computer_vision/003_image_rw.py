"""
RGB, BGR, aipha

    R: red, 0~255
    G: green, 0~255
    B: blue, 0~255
    alpha: 透明度, 0~1

image size:
    image_size = image_width x image_height x 3 x 8 bit
i.e.
    640 x 359 x 3 x 8 = 5514240 bit
    5514240 / 8  = 689280 byte
    689280 / 1024 = 673.125 kb
    673.125 / 1024 = 0.657 mb
"""
import cv2

# read a image
img = cv2.imread("data/grass.jpg")
print("The size of grass.jpg: ", img.size)

"""

# write a jpg
# 有损
cv2.imwrite('grass2.jpg', img, [cv2.IMWRITE_JPEG_QUALITY, 50])

# write a png
# 无损
cv2.imwrite('grass2.png', img, [cv2.IMWRITE_PNG_COMPRESSION, 0])

"""

# col is x value
# row is y value

"""
图像矩阵结构:

  (0, 0)
    +-----------> x(col)
    |
    |    · (x, y)
    |
    V
    y(row)

读取像数点的方向: 先行后列
Mat[<row>, <col>] or [<y>, <x>]
"""

# BGR
(b, g, r) = img[50, 50]
print(b, g, r)

# draw a blue line in the image
# from (100, 50) and length is 100px
for i in range(1, 100):
    img[100, 50+i] = (255, 0, 0)

cv2.imshow("Draw a blue line", img)
cv2.waitKey(0)
