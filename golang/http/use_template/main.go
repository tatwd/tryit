package main

import (
	"fmt"
	"html/template"
	"log"
	"net/http"
	"os"
)

func main() {
	// to stdout
	// v1()

	// to web client
	v2()
}

// Payload some info
type Payload struct {
	Name     string
	NumFuncs int
	NumVars  int
}

func v1() {
	tmpl, err := template.New("go-web").Parse(`
Package name: {{.Name}}
Number of functions: {{.NumFuncs}}
Number of variable: {{.NumVars}}`)
	if err != nil {
		log.Fatalf("Parse: %v", err)
	}

	err = tmpl.Execute(os.Stdout, &Payload{
		Name:     "go-web",
		NumFuncs: 12,
		NumVars:  1200,
	})
	if err != nil {
		log.Fatalf("Execute: %v", err)
	}
}

func v2() {
	http.HandleFunc("/", func(w http.ResponseWriter, r *http.Request) {
		tmpl, err := template.ParseFiles("index.tmpl")
		if err != nil {
			fmt.Fprintf(w, "Parse: %v", err)
			return
		}

		// res := &Payload{
		// 	Name:     "go-web",
		// 	NumFuncs: 12,
		// 	NumVars:  1200,
		// }
		res := r
		err = tmpl.Execute(w, res)
		if err != nil {
			fmt.Fprintf(w, "Execute: %v", err)
			return
		}
	})

	log.Print("Starting server at http://localhost:6060 ...")
	log.Fatal(http.ListenAndServe(":6060", nil))
}
