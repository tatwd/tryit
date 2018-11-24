#include <stdio.h>

int main(void)
{
	int counter = 1;

	/* while loop */
	while (counter <= 5) {
		printf("while loop: %d\n", counter);
		counter++;
	}

	/* for loop */
	for (int i = 0; i < counter; ++i) {
		printf("for loop: %d\n", i);
	}
	
	/* do-while loop */
	do {
		printf("do-while loop: %d\n", counter);
		counter--;
	} while(counter > 0);

	return 0; 
}