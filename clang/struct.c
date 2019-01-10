#include <stdio.h>
#include <stdlib.h>
#include <assert.h>

typedef struct {
	int id;
	char *data;
} pkg_t;

int main()
{
	pkg_t x = {1, "foo"};
	pkg_t y = {
		.id = 2,
		.data = "bar"
	};
	pkg_t z = {
		id: 3,
		data: "baz"
	};

	pkg_t *p = &x;
	printf("%d %d\n", x.id, p->id);

	pkg_t *pkg = malloc(sizeof(pkg_t));
	assert(pkg != NULL);
	/*
	if (pkg == NULL) {
		fprintf(stderr, "error: cannot malloc memory!\n");
		return -1;
	}
	*/

	pkg->id = 3;
	pkg->data = "hello world";
	printf("%p: {id: %d, data: \"%s\"}\n", &pkg, pkg->id, pkg->data);

	free(pkg);

	return 0;
}
