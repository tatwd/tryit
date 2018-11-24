#include <stdio.h>

/*

[return_type] [function_name] ([paramters]) 
{
	[function_body]
}

*/

void show();
int add(int, int);


/*
Call Stack:
	| called	main()
	Y called	show()
	| called	add()
	| finished	add()
	Y finished	show() 
	| finished	main()
*/
int main(void)
{
	int sum;

	show();

	sum = add(1, 2);	
	printf("1 + 2 = %d\n", sum);

	return 0; 
}

void show()
{
	printf("Hello Function!\n");
}

int add(int a, int b) 
{
	return a + b;
}