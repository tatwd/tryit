#include <stdio.h>

int main(void)
{
	int age = 20;

	/* if-else */
	if (age >= 18) {
		printf("You are a adult!\n");
	} else {
		printf("You are a child!\n");
	}
	
	/* ternary operator */
	age >= 18 ? 
		printf("You are a adult!\n"): 
		printf("You are a child!\n");
	
	int isAdult = age >= 18 ? 1 : 0;

	return 0; 
}