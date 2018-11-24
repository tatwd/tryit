#include <stdio.h>

int main(void)
{
	/* init a string */
	char first_name[6] = {}; /* fill with '\0' */
	char last_name[] = { 'K', 'i', 'n', 'g' };
	char name[] = "Jaron King";
	
	name[0] = 'J';
	name[1] = 'a';
	name[2] = 'r';
	name[3] = 'o';
	name[4] = 'n';

	printf("first name: %s last name: %s name: %s\n", 
		first_name, last_name, name);

	return 0; 
}