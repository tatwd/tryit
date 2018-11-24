#include <stdio.h>
#include <conio.h>

int main(void)
{
	/* data type */
	int age;
	float weight; /* 32bit */
	double height; /* 64bit */
	char sex;

	age = 23;
	weight = 50.5;
	height = 181.1;
	sex = 'M';
	
	printf("age=%d, weight=%f, height=%g, sex=%c\n",
		age, weight, height, sex);
	printf("Size of float is %d bytes.\n", sizeof(double));
	
	getch();
	return 0; 
}