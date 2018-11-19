# show image by opencv

import cv2

img = cv2.imread("data/grass.jpg")
cv2.imshow("Gress Image", img)
cv2.waitKey(0)
cv2.destroyAllWindows()
