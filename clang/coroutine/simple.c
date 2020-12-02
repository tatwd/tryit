#include <stdio.h>
#include <stdlib.h>
#include <ucontext.h>

/*
//获取当前 ucontext_t
int getcontext(ucontext_t *ucp);

//切换到指定 ucontext_t
int setcontext(const ucontext_t *ucp);

//设置函数指针和堆栈到对应 ucontext_t 保存的 sp 和 pc 寄存器中
void makecontext(ucontext_t *ucp, void (*func)(), int argc, ...);

//保存当前环境到 oucp，并且切换到指定 ucp
int swapcontext(ucontext_t *oucp, ucontext_t *ucp);
*/

static ucontext_t uctx_main, uctx_foo, uctx_bar;

#define handle_error(msg)                                                      \
	do {                                                                       \
		perror(msg);                                                           \
		exit(EXIT_FAILURE);                                                    \
	} while (0)

static void foo(void)
{
	printf("foo: started!\n");

	// goto bar()
	// 切到 uctx_bar 上下文
	if (swapcontext(&uctx_foo, &uctx_bar) == -1) {
		handle_error("swapcontext(&uctx_foo, &uctx_bar)");
	}

	// 从 uctx_bar 回到当前上下文
	printf("foo: finished!\n");
}

static void bar(void)
{
	printf("bar: started!\n");

	// goto foo()
	// 切到 uctx_foo 上下文
	if (swapcontext(&uctx_bar, &uctx_foo) == -1) {
		handle_error("swapcontext(&uctx_bar, &uctx_foo)");
	}

	// 如果 uctx_bar.uc_link 未指向 uctx_foo
	// 则当 bar 执行完，将不会切换到 foo
	if (uctx_bar.uc_link == NULL) {
		printf("bar: goto foo context!\n");
		setcontext(&uctx_foo);
	}

	// 从 uctx_foo 回到当前上下文
	printf("bar: finished!\n");
}

int main(int argc, char *argv[])
{
	char foo_stack[16384];
	char bar_stack[16384];

	// 先配置各 routine 的 context
	if (getcontext(&uctx_foo) == -1) {
		handle_error("getcontext");
	}
	uctx_foo.uc_stack.ss_sp = foo_stack;
	uctx_foo.uc_stack.ss_size = sizeof(foo_stack);

	// uctx_foo 的上下文链接到 uctx_main
	uctx_foo.uc_link = &uctx_main;
	makecontext(&uctx_foo, foo, 0);

	if (getcontext(&uctx_bar) == -1) {
		handle_error("getcontext");
	}
	uctx_bar.uc_stack.ss_sp = bar_stack;
	uctx_bar.uc_stack.ss_size = sizeof(bar_stack);
	uctx_bar.uc_link =
		(argc > 1) ? NULL : &uctx_foo; // uctx_bar 的上下文链接到 uctx_foo
	makecontext(&uctx_bar, bar, 0);

	printf("main: swapcontext(&uctx_main, &uctx_bar)\n");
	if (swapcontext(&uctx_main, &uctx_bar) == -1) {
		handle_error("swapcontext"); // 切到 uctx_bar 上下文
	}

	// 需要 foo 执行完成才能回到 main
	// 原因：uctx_foo.uc_link = &uctx_main
	printf("main: exiting!\n");
	return 0;
}
