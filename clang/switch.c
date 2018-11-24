#include <stdio.h>

int main(void)
{
	int x = 2;

	switch(x) {
	case 0:
		printf("x is %d\n", x);
		break;
	
	/* range cases */
	case 1 ... 3:
		printf("x is %d\n", x);
		break;
	case 4:
		printf("x is %d\n", x);
		break;
	default:
		printf("default case\n");
	}

	return 0;
}