package main

import (
	"log"
	"net/http"
	"time"
)

func handler2(w http.ResponseWriter, r *http.Request) {
	time.Sleep(2 * time.Second)
	w.Write([]byte("Server v3: Hello world!"))
}

func server3() {
	// config a server
	server := &http.Server{
		Addr:         ":6060",
		WriteTimeout: 3 * time.Second,
	}

	mux := http.NewServeMux()
	mux.Handle("/", &myHandler{})    // myHandler is in server2.go
	mux.HandleFunc("/foo", handler1) // handler1 is in server1.go
	mux.HandleFunc("/bar", handler2)

	server.Handler = mux

	log.Println("Server on http://localhost:6060 ... v3!")
	log.Fatal(server.ListenAndServe())
}
