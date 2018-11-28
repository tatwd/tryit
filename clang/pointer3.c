#include <stdio.h>
#include <string.h>

void swap1(int *ap, int *bp);
void swap2(void *ap, void *bp, int size);

int main(void)
{
	int a = 1;
	int b = 2;
	swap1(&a, &b);
	printf("[swap1:int] a: %d, b: %d\n", a, b);

	char *s1 = "Hello";
	char *s2 = "World";
	int size = sizeof(*s1);
	swap2(&s1, &s2, size);
	printf("[swap2:char] size: %d, s1: \"%s\", s2: \"%s\"\n", 
		size, s1, s2);
	
	double d1 = 12.1;
	double d2 = 2.31;
	size = sizeof(d1);
	swap2(&d1, &d2, size);
	printf("[swap2:double] size: %d, d1: %f, d2: %f\n",
		size, d1, d2);
/*
output in my machine:

[swap1:int] a: 2, b: 1
[swap2:char] size: 1, s1: "World", s2: "Hello"
[swap2:double] size: 8, d1: 2.310000, d2: 12.100000

*/
	return 0;
}


void swap1(int *ap, int *bp)
{
/*
	int temp = *ap;
	*ap = *bp;
	*bp = temp;
*/	
	*ap = *ap ^ *bp;
	*bp = *ap ^ *bp;
	*ap = *ap ^ *bp;
}

/* size 是 ap 所指地址的数据的大小 */
void swap2(void *ap, void *bp, int size)
{
/*
The value of `ap` equals the address of `var_name`
and `buffer` will store the value of `*ap`(i.e. `data`).

     buffer         ap        var_name
    +------+     +------+     +------+
... | data | ... | 0xa1 | ... | data | ...
    +------+     +------+\    +------+
      0xc1         0xb1   *---> 0xa1

So the `buffer` size must be equals the size of `*ap`.
*/
	char buffer[size];
	memcpy(buffer, ap, size);
	memcpy(ap, bp, size);
	memcpy(bp, buffer, size);
}