package main

import (
 "github.com/go-chi/chi"
 "github.com/go-chi/chi/middleware"
 "net/http"
)

func main() {
 r := chi.NewRouter()

 // Apply middleware
 r.Use(middleware.Logger)
 r.Use(middleware.Recoverer)
 r.Use(middleware.URLFormat)

 // Define routes
 r.Get("/", func(w http.ResponseWriter, r *http.Request) {
  w.Write([]byte("Hello, Chi!"))
 })

 r.Route("/users", func(r chi.Router) {
  // Handle /users route
  r.Get("/", ListUsers)
  r.Post("/", CreateUser)

  // Handle /users/{id} route
  r.Route("/{id}", func(r chi.Router) {
   r.Get("/", GetUser)
   r.Put("/", UpdateUser)
   r.Delete("/", DeleteUser)
  })
 })

 // Start the server
 http.ListenAndServe(":8080", r)
}
