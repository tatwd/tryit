build: main.o
	cc main.o -o a.out -L./libuv/lib -luv -Wl,-rpath=./libuv/lib

main.o: main.c
	cc main.c -c main.c -I./libuv/include

.PHONY: clean

clean:
	rm -rf *.o *.out