#include <stdio.h>

int main(void)
{
	int age;
	float weight;
	printf("Please enter your age and weight: ");
	scanf("%d%f", &age, &weight); /* 空白符分隔 */
	printf("Your are %d years old and %fkg weight!", 
		age, weight);
	return 0; 
}