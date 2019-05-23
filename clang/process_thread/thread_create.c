#include <unistd.h>  /* sleep */
#include <stdio.h>   /* printf */
#include <pthread.h> /* thread_create
                      * thread_exit
                      */

#define NUM_THREADS	5

struct thread_data{
	int thread_id;
	int sum;
	char *message;
};

struct thread_data thread_data_arr[NUM_THREADS];

void *print_hello(void *arg)
{
	struct thread_data *data;
	long tid;
	int sum;
	char *message;

	sleep(1); /* sleep 1s */

	data = (struct thread_data *)arg;
	tid = data->thread_id;
	sum = data->sum;
	message = data->message;

	printf("tid: #%ld sum: %d message: %s\n", tid, sum, message);
	pthread_exit(NULL);
}

char *message[NUM_THREADS];

int main(void)
{
	pthread_t threads[NUM_THREADS];
	int res, i, sum;

	message[0] = "A";
	message[1] = "B";
	message[2] = "C";
	message[3] = "D";
	message[4] = "E";

	for (i = sum = 0; i < NUM_THREADS; i++) {
		//taskids[i] = i;

		thread_data_arr[i].thread_id = i;
		thread_data_arr[i].sum = ++sum;
		thread_data_arr[i].message = message[i];

		printf("creating thread %d\n", i);
		res = pthread_create(&threads[i], NULL, print_hello,
			(void *) &thread_data_arr[i]);
		if (res) {
			printf("ERROR: %d\n", res);
			return -1;
		}
	}
	pthread_exit(NULL);
}
