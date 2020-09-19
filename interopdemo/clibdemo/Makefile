
test: libmy.so test.o cp2cs
	cc test.o -L. -lmy -Wl,-rpath=. -g -o test.out
	./test.out

libmy.so: mylib.c
	cc mylib.c -Wall -fPIC -shared -o libmy.so

test.o: test.c
	cc test.c -Wall -c

cp2cs: libmy.so
	cp libmy.so ../csharpdemo/

.PHONY: clean
clean:
	rm *.o *.so test.out
