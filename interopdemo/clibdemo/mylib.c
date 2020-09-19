#include <locale.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <wchar.h>

#include "mylib.h"

// my string length count
static size_t mystrlen(const char *str)
{
	size_t len = strlen(str);
	if (len == 0) {
		return 0;
	}

	// convert char to wchar and count length
	// reset stdout
	// freopen(NULL, "w", stdout);
	setlocale(LC_ALL, "zh_CN.utf8");
	wchar_t wstr[len];
	mbstowcs(wstr, str, len);
	return wcslen(wstr);
}

int myadd(int a, int b)
{
	printf("myadd: now in myadd\n");
	return a + b;
}

int myhello(char str[], int len)
{
	if (str == NULL) {
		printf("myhello: null string\n");
		return 1;
	}
	if (len == 0) {
		printf("myhello: empty string\n");
		return 2;
	}
	printf("myhello(has %d chars): %s", len, str);
	return 0;
}

int mysay(const char *str)
{
	if (str == NULL) {
		printf("mysay: null string\n");
		return 1;
	}

	size_t len = strlen(str);
	size_t wlen = mystrlen(str);
	if (wlen == 0) {
		printf("mysay: empty string\n");
		return 2;
	}

	printf("mysay(has %ld chars, %ld wchars): %s", len, wlen, str);
	return 0;
}
