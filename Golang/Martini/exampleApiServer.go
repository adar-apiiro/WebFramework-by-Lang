package main

import (
	"log"
	"net/http"
	"os"

	"github.com/codegangsta/inject"
	m "github.com/go-martini/martini"
)

func main() {
	martini := m.New()

	// You can add middleware specific to your API server if needed.

	router := NewRouter()
	martini.MapTo(router, (*Routes)(nil))
	martini.Action(router.Handle)

	port := os.Getenv("PORT")
	if len(port) == 0 {
		port = "3000"
	}

	host := os.Getenv("HOST")

	martini.RunOnAddr(host + ":" + port)
}

// ClassicMartini represents a Martini with a router for the API.
type ClassicMartini struct {
	*Martini
	Router
}

// Classic creates a classic Martini with a router for the API.
func Classic() *ClassicMartini {
	r := NewRouter()
	m := New()
	m.MapTo(r, (*Routes)(nil))
	m.Action(r.Handle)
	return &ClassicMartini{m, r}
}

// ... (rest of the code remains unchanged)
