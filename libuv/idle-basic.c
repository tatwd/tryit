#include <stdio.h>
#include <uv.h>

int64_t counter = 0;

void wait_for_while(uv_idle_t *handle)
{
	counter++;

	if (counter >= 10e6) {
		printf("%d\n", *(int*)handle->data);
		uv_idle_stop(handle);
	}
}

int main(void)
{
	uv_idle_t idler;

	uv_idle_init(uv_default_loop(), &idler);
	
	/*idler.data like a context*/
	int d = 2;
	idler.data = (void *)&d;
	uv_idle_start(&idler, wait_for_while);

	printf("ilding...\n");
	uv_run(uv_default_loop(), UV_RUN_DEFAULT);
	uv_loop_close(uv_default_loop());

	return 0;
}
