#include <stdio.h>   /* printf */
#include <math.h>    /* sin
                      * tan
                      */
#include <pthread.h> /* thread_create
                      * thread_exit
                      * thread_join
                      * thread_attr_init
                      * thread_attr_setdetachstate
                      * thread_attr_destory
                      */

#define NUM_THREADS	5

void *busy_work(void *arg)
{
	long tid;
	int i;
	double result;

	tid = (long)arg;
	result = 0.0;

	printf("Thread %ld starting...\n", tid);
	for (i = 0; i < 1000000; i++) {
		result = result + sin(i) * tan(i);
	}
	printf("Thread %ld done, result = %e\n", tid, result);
	tid++;
	pthread_exit((void *)tid);
}

int main(void)
{
	pthread_t threads[NUM_THREADS];
	pthread_attr_t attr;
	int res;
	long i;
	void *status;

	/* Initialize and set thread detached attribute */
	pthread_attr_init(&attr);
	pthread_attr_setdetachstate(&attr, PTHREAD_CREATE_JOINABLE);

	for (i = 0; i < NUM_THREADS; i++) {
		printf("Main: creating thread %ld\n", i);
		res = pthread_create(&threads[i], &attr, busy_work, (void *) i);
		if (res) {
			printf("ERROR: %d\n", res);
			return -1;
		}
	}

	/* Free attribute and wait for the other threads */
	pthread_attr_destroy(&attr);
	for (i = 0; i < NUM_THREADS; i++) {
		res = pthread_join(threads[i], &status);
		if (res) {
			printf("ERROR: code from pthread_join is %d\n", res);
			return -1;
		}
		printf("Main: completed join with" 
		       "thread %ld and status is %ld\n", i, (long)status);
	}

	printf("Main: program completed. Exiting.\n");
	pthread_exit(NULL);
}
