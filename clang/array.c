#include <stdio.h>

int main(void)
{
	/* a int array, length is 6 
	default value is 0 */
	int size = 6;
	int marks[size];
	
	/* init */
	for (int i = 0; i < 6; ++i) {
		marks[i] = i + 1;
	}
	/* print */
	for (int i = 0; i < 6; ++i) {
		printf("%d\n", marks[i]);
	}

	printf("start at %#p, end at %#p\n", marks, &marks[5]);

	return 0; 
}