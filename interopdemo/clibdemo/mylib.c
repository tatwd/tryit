#include <stdio.h>
#include <stdlib.h>
#include <locale.h>
#include <wchar.h>
#include <string.h>

#include "mylib.h"

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
    // reset stdout
    // freopen(NULL, "w", stdout);
    setlocale(LC_ALL, "zh_CN.utf8");

    if (str == NULL) {
        printf("mysay: null string\n");
        return 1;
    }

    int len = strlen(str);
    if (len == 0) {
        printf("mysay: empty string\n");
        return 2;
    }

    // convert char to wchar and count length
    wchar_t wstr[len];
    mbstowcs(wstr, str, len);

    int wlen = wcslen(wstr);
    if (wlen == 0) {
        printf("mysay: empty string\n");
        return 2;
    }

    printf("mysay(has %d chars, %d wchars): %s", len, wlen, str);
    return 0;
}