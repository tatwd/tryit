#include <stdio.h>

extern int add(int, int);

int main(void)
{
	int ret = add(1, 2);
	printf("%d\n", ret);
}
