﻿#include <stdio.h>

int main(void)
{
    int arr[5];

    arr[0] = 1;
    arr[4] = 5;
    printf("%d ... %d\n", arr[1], arr[4]);

    arr[-1] = 0;
    arr[5] = 6;
    printf("arr[-1]: %d, arr[5]: %d\n", arr[-1], arr[5]);

    arr[3] = 128;
/*
Now:
         高位 <------------------------- 低位
arr[0]:  00000000 00000000 00000000 00000001  <- 0X60F0   低位
arr[1]:  00000000 00000000 00000000 00000000  <- 0X60F4    |
arr[2]:  00000000 00000000 00000000 00000000  <- 0X60F8    |
arr[3]:  00000000 00000000 00000000 10000000  <- 0X60FC    V
arr[4]:  00000000 00000000 00000000 00000111  <- 0X60FF   高位

*/

    ((short *)arr)[6] = 2;
/*
Now:
                    高位 <------- 低位
((short *)arr)[0]:  00000000 00000001  <- 0X60F0   低位
((short *)arr)[1]:  00000000 00000000               |
((short *)arr)[2]:  00000000 00000000  <- 0X60F4    |
((short *)arr)[3]:  00000000 00000000               |
((short *)arr)[4]:  00000000 00000000  <- 0X60F8    |
((short *)arr)[5]:  00000000 00000000               |
((short *)arr)[6]:  00000000 00000010  <- 0X60FC    |
((short *)arr)[7]:  00000000 00000000               |
((short *)arr)[8]:  00000000 00000111  <- 0X60FF    V
((short *)arr)[9]:  00000000 00000000              高位

So, the `arr[3]` is `2`.
*/
    printf("arr[3]: %d\n", arr[3]);

    return 0;
}