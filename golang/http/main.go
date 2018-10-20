package main

import (
	"fmt"
	"log"
	"net/http"
)

func handle(w http.ResponseWriter, r *http.Request) {
	fmt.Fprintf(w, "%v %v OK", r.Method, r.URL.Path)
}

func main() {
	http.HandleFunc("/", handle)
	log.Fatal(http.ListenAndServe(":6060", nil))
}
