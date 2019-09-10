#include <stdio.h>
#include <math.h> /* -lm */
#include <assert.h>

/* 获取皮尔森相关系数 */
double get_pearson_correlation_coefficient(double x_arr[], double y_arr[], 
                                           unsigned int len)
{	
	assert(len != 0);

	double ret;
	double xy_sum = 0, x_sum = 0, y_sum = 0, x2_sum = 0, y2_sum = 0;

	for (int i = 0; i < len; i++) {
		xy_sum += x_arr[i] * y_arr[i];

		x_sum += x_arr[i];
		y_sum += y_arr[i];

		x2_sum += x_arr[i] * x_arr[i];
		y2_sum += y_arr[i] * y_arr[i];
	}

	/* compute the result */
	ret = (len * xy_sum - x_sum * y_sum) / 
          (sqrt(len*x2_sum - x_sum*x_sum) * sqrt(len*y2_sum - y_sum*y_sum));

	return ret;
}


int main(void)
{
	/* 数据来源: https://www.shuxuele.com/data/correlation.html */
	double temp[] = { 14.2, 16.4, 11.9, 15.2, 18.5, 22.1,
                      19.4, 25.1, 23.4, 18.1, 22.6, 17.2 };
	double sales[] = { 215, 325, 185, 332, 406, 522, 
                       412, 614, 544, 421, 445, 408 };
	double ret = get_pearson_correlation_coefficient(temp, sales, 12);
	printf("%g", ret);
	return 0;
}
