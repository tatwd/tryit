VPATH = ./include

OBJS = main.o test.o

CINCLUDES = -I ./include
CFLAGS = -Wall $(CINCLUDES)

hello: $(OBJS)
	$(CC) $(CFLAGS) $^ -o $@
	./hello

.PHONY: clean

clean:
	rm -rf $(OBJS) hello