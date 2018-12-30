package main

import (
	"fmt"
	"log"
	"net/http"
)

func handler1(w http.ResponseWriter, r *http.Request) {
	fmt.Fprintf(w, "Server v1: %v %v OK", r.Method, r.URL.Path)
}

func server1() {
	http.HandleFunc("/", func(w http.ResponseWriter, r *http.Request) {
		w.Write([]byte("Hello world!"))
	})
	http.HandleFunc("/foo", handler1)

	log.Println("Server on http://localhost:6060 ... v1!")
	log.Fatal(http.ListenAndServe(":6060", nil))
}
