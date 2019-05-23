#include <unistd.h>
#include <stdio.h>

int main(void)
{
	printf("hello\n");
	pid_t pid = fork();
	pid_t pid2 = fork();
	if (pid < 0)
		printf("has error! %d\n", pid);
	else if (pid == 0)
		printf("it is child process! %d\n", pid);
	else
		printf("it is parent process! %d->%d\n", getpid(), pid);
	return getchar();
}
