#include <stdio.h>

int main(int argc, char *argv[])
{
	FILE *fp = NULL;

	fp = fopen("foo.txt", "r");
	if (fp == NULL) {
		fprintf(stderr, "not found the file\n");
	}
	/*
	fprintf(fp, "this is testing for fprintf ...\n");
	fputs("this is testing for fputs...\n", fp);
	*/

	char buf[255] = "\0";
	int len;

	len = fread(buf, sizeof(char), 255, fp);
	for (int i = 0; i < len; ++i) {
		buf[i] = buf[i] ^ 1111;
	}
	printf("len: %d\n", len);

	FILE *f = fopen("bar.txt", "w+");
	int res = fwrite(buf, sizeof(char), len, f);
	printf("res: %d\n", res);

	fclose(fp);
	fclose(f);

	return 0;
}
