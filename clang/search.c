#include <stdio.h>
#include <string.h>

/*
Linear Search
*/

/* only for int */
int lsearch1(int key, int arr[], int n);

/* use `memcmp` as default compare function */
int lsearch2(void *key, void *base, 
	    int n, int element_size);

/* need to provide a compare function */
int lsearch3(void *key, void *base,
	    int n, int element_size,
	    int (*cmpfn)(void *, void *));

int main(void)
{
	int arr[6] = { 1, 2, 3, 4, 5, 6 };
	int key = 3;
	int index = -1;
	
	index = lsearch1(key, arr, 6);
	printf("[search1:int] index: %d\n", index);

	index = lsearch2(&key, arr, 6, sizeof(int));
	printf("[search2:int] index: %d\n", index);
	
	/* find a string in a string */
	char *str = "Hello World!";
	char *key1 = "Wo";
	index = lsearch2(key1, str, strlen(str), sizeof(char));
	printf("[search2:char] index: %d\n", index);

	int int_cmp(void *ap, void *bp);
	index = lsearch3(&key, arr, 6, sizeof(int), int_cmp);
	printf("[search3:int] index: %d\n", index);

	/* find a string in a string array */
	char *names[] = { "Jack", "Leo", "Bob", "Jaron", "Tom" };
	char *me = "Jaron";
	int str_cmp(void *ap, void *bp);
	index = lsearch3(&me, names, 5, sizeof(char *), str_cmp); /* must pass `&me` */
	printf("[search3:char *] index: %d\n", index);

/*
output in my machine:

[search1:int] index: 2
[search2:int] index: 2
[search2:char] index: 6
[search3:int] index: 2
[search3:char *] index: 3

*/
	return 0;
}

int lsearch1(int key, int arr[], int n)
{
	for (int i = 0; i < n; ++i) {
		if (arr[i] == key) {
			return i;
		}
	}
	return -1;
}

int lsearch2(void *key, void *base, 
	    int n, int element_size)
{
	for (int i = 0; i < n; ++i) {
		void *ptr = (char *)base + i * element_size;
		if (memcmp(ptr, key, element_size) == 0) {
			return i;
		}
	}
	return -1;
}

int lsearch3(void *key, void *base, 
	    int n, int element_size,
	    int (*cmpfn)(void *, void *))
{
	for (int i = 0; i < n; ++i) {
		void *ptr = (char *)base + i * element_size;
		if (cmpfn(ptr, key) == 0) {
			return i;
		}
	}
	return -1;
}

/* a example `cmpfn` for int */
int int_cmp(void *ap, void *bp)
{
	int *p1 = ap;
	int *p2 = bp;
	return *p1 -*p2;
}

/* a example `cmpfn` for string 
while `ap` and `bp` is `char **` pointer
*/
int str_cmp(void *ap, void *bp)
{
	char *s1 = *(char **)ap;
	char *s2 = *(char **)bp;
	return strcmp(s1, s2);
}