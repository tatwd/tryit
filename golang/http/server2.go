package main

import (
	"log"
	"net/http"
)

// 自定义一个 Handler
type myHandler struct{}

// Implement ServeHTTP
func (*myHandler) ServeHTTP(w http.ResponseWriter, r *http.Request) {
	w.Write([]byte("Server v2: Hello world!"))
}

func server2() {
	mux := http.NewServeMux()

	mux.Handle("/", &myHandler{})
	mux.HandleFunc("/foo", handler1) // handler1 is in server1.go

	log.Println("Server on http://localhost:6060 ... v2!")
	log.Fatal(http.ListenAndServe(":6060", mux))
}
