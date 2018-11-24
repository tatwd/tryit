#include <stdio.h>
#include <conio.h>

int main(void)
{
	printf("%d\n", 1);
	printf("%.1f\n", 4.5);
	printf("%c\n", 'A');
	printf("%s\n", "string");
	printf("%#x\n", 0x29); /* upper use 'X' */
	
	/*
	'\' is a escape char
	\t => tab
	\r => return
	\n => newline 
	*/
	printf("\\\t\"\r\n");

	getch();
	return 0; 
}