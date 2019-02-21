package main

import (
	"log"
	"net/http"
)

func server4() {
	http.Handle("/", http.FileServer(http.Dir("static/")))
	log.Println("Server on http://localhost:8080 ... v3!")
	log.Fatal(http.ListenAndServe(":8080", nil))
}
