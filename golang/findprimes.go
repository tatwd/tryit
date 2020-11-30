package main

import "fmt"

func main() {
	origin, wait := make(chan int), make(chan struct{})
	findprime(origin, wait)
	for num := 2; num < 10; num++ {
		origin <- num
	}
	close(origin)
	<-wait
}

func findprime(seq chan int, wait chan struct{}) {
	go func() {
		prime, ok := <-seq
		if !ok {
			fmt.Println(curGoroutineID(), "close wait")
			close(wait)
			return
		}
		fmt.Println(curGoroutineID(), "prime:", prime)
		out := make(chan int)
		findprime(out, wait)
		for num := range seq {
			fmt.Println(curGoroutineID(), "num:", num, "prime:", prime)
			if num%prime != 0 {
				fmt.Println(curGoroutineID(), "hit num:", num)
				out <- num
			}
		}
		close(out)
	}()
}
