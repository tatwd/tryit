build: libmymath.so main.o
	$(CC) main.o -lmymath -L. -Wl,-rpath=.

libmymath.so: libmymath.rs
	rustc libmymath.rs

main.o:
	$(CC) -c main.c

.PHONY: clean
clean:
	rm *.o *.so *.out