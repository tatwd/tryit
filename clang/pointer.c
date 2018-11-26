#include <stdio.h>

typedef struct fraction {
	int num;
	int denom;
} frac;



int main(void)
{
/*
  f--> +------+
       | 0xf1 | num
       +------+
       | 0xf2 | denom
       +------+
*/
	frac f;
	printf("f: %p\n", &f); /* equals &(f.num) */
	
	f.num = 10;
	f.denom = 11;
	printf("f.num: %p, %d\n", &(f.num), f.num);
	printf("f.denom: %p, %d\n", &(f.denom), f.denom);

	/* (&f)[0] is f */
	printf("\n(&f)[0]: %p, {num:%d,denom:%d}\n", 
		&(&f)[0], (&f)[0].num, (&f)[0].denom);

/*
  f--> +------+
       | 0xf1 | f.num
  p--> +------+
       | 0xf2 | f.denom (p->num)
       +------+
       | 0xf3 | p->denom
       +------+
*/
	frac *p = (frac *)&(f.denom);
	p->num = 20;
	p->denom = 21;

	printf("\nf.num: %p, %d\n", &(f.num), f.num);
	printf("f.denom: %p, %d\n", &(f.denom), f.denom);
	
	/* Donot use `p` to access the memory. ? */
	printf("p->num: %d\n", ((frac *)&(f.denom))->num);
	printf("p->num: %d\n", ((frac *)&(f.denom))[0].denom); /* or (&f)[1].num */
	
	return 0; 
}