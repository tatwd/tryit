#include <stdio.h>

#include "mylib.h"

int main(void)
{
	int a = 1;
	int b = 2;
	int sum = myadd(a, b);
	printf("myadd(sum): %d\n", sum);

	char s[] = "hell,world!\n";
	myhello(s, sizeof(s));
	myhello(NULL, 1);
	myhello(s, 0);

	const char *str = "你好!\n";
	mysay(str);
	mysay(NULL);
	mysay("");

	return 0;
}
