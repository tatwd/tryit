package main

import (
	"context"
	"fmt"
	"time"
)

type traceIDKey string

func main() {
	ctx := context.Background()
	process(ctx)

	ctx = context.WithValue(ctx, traceIDKey("traceId"), "hello:123")
	process(ctx)

	numch := make(chan int)
	cancelCtx, cancel := context.WithCancel(context.Background())
	go (func() {
		var n int
		for {
			select {
			case <-cancelCtx.Done():
				fmt.Println("canceled!")
				return
			case numch <- n:
				n++
				time.Sleep(time.Second)
			}
		}
	})()

	for n := range numch {
		fmt.Println(n)
		if n == 5 {
			cancel()
			break
		}
	}

	defer cancel()
}

func process(ctx context.Context) {
	key := traceIDKey("traceId")
	traceID, ok := ctx.Value(key).(string)
	if ok {
		fmt.Printf("trace_id=%s\n", traceID)
	} else {
		fmt.Printf("process over!\n")
	}
}
