#include <stdio.h>
#include <ctype.h> /* isspace
                    * isalpha
                    */

#define KEY_COUNT	50

/* just for dev */
static const char *keywords[] =
{
	"break", "continue", "return",
	"if", "else", "switch", "while", "do", "case", "goto",
	"var", "let", "new", "function",
	"unsigned", "static", "const", "volatile",
	"struct", "class",
	"char", "int", "short", "long", "float", "double",
};

static int matched_index[KEY_COUNT] = {0};
static char last = '\0';
static int first_quote = 0;

/* check if `c` is in a string */
int in_string(char c)
{
	if (first_quote == 0) {
		first_quote = c;
		return 1;
	} else if (first_quote == c) {
		first_quote = 0;
		return 0; /* will not in a string */
	} else {
		return 1;
	}
}

/* check if `c` is in the `keywords` */
int in_keywords(char c)
{
	int i, j;
	const char *k;

	for (j = 0; j < KEY_COUNT; j++) {
		i = matched_index[j];
		k = keywords[j];

		if (k == NULL)
			break;

		if (k[i] == c) {
			if (i == 0 && !isalpha(c))
				continue;
			matched_index[j]++;
		} else if (k[i] == '\0') {
			if(isalpha(c) || isspace(last))
				matched_index[j] = 0;
		} else {
			matched_index[j] = 0;
		}
	}

	for (int j = 0; j < KEY_COUNT; j++)
		if (matched_index[j])
			return 1;
	return 0;
}

int main(int argc, char *argv[])
{
	if (argc < 3) {
		printf("%s [input_file_name] [output_file_name]\n", argv[0]);
		return 0;
	}

	FILE *fp_r, *fp_w;

	fp_r = fopen(argv[1], "r");
	if (fp_r == NULL) {
		printf("Not found '%s'!\n", argv[1]);
		return -1;
	}

	fp_w = fopen(argv[2], "w");
	/*
	if (fp_w == NULL) {
		printf("Not found '%s'!\n", argv[2]);
		return -1;
	}
	*/

	int i, is_key, is_quote;
	char c;
	i = 0;
	is_key = 0;
	is_quote = 0;

	int is_macro = 0;
	int is_comment = 0;

	while ((c = fgetc(fp_r)) != EOF) {

		switch (c) {
		case '"': case '\'': case '`':
			is_quote = in_string(c);
			break;
		case '#':
			is_macro = 1; /* in a macro */
			break;
		case '/':
			is_comment = !is_quote; /* FIXME */
			break;
		}

		if (!is_quote && !is_macro && !is_comment) {
			is_key = in_keywords(c);
			if (!is_key && isspace(c)) {
				last = c;
				continue;
			}
		}

		last = c;
		fputc(c, fp_w);
		putchar(c);

		if (c == '\n') {
			if (is_macro) is_macro = 0;
			if (is_comment) is_comment = 0;
			if (is_quote) is_quote = 0;
		}
	}

	fclose(fp_r);
	fclose(fp_w);
	return 0;
}
